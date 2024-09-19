using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
    public class WorkService
    {
        private readonly IWorkRepository workRepository;
        private readonly IMapper mapper;

        public WorkService(IWorkRepository workRepository, IMapper mapper)
        {
            this.workRepository = workRepository;
            this.mapper = mapper;
        }

        public async Task CreateWork(WorkRequestDto workRequestDto)
        {
            var work = mapper.Map<Work>(workRequestDto);
            work.Status = true;
            await workRepository.Insert(work);
        }

        public async Task UpdateWork(int id, WorkRequestDto workRequestDto)
        {
            var existingWork = await workRepository.GetById(w => w.IdWork == id);
            if (existingWork == null)
            {
                throw new Exception("El trabajo no existe");
            }
            else
            {
                mapper.Map(workRequestDto, existingWork);
                await workRepository.Update(existingWork);
            }
        }

        public async Task<ActionResult<WorkResponseDto>> GetWorkById(int id)
        {
            var work = await workRepository.GetById(w => w.IdWork == id);
            if (work == null)
            {
                throw new KeyNotFoundException("El trabajo no fue encontrado.");
            }
            else
            {
                return mapper.Map<WorkResponseDto>(work);
            }
        }

        public async Task<ActionResult<List<WorkResponseDto>>> GetAllWorks()
        {
            var works = await workRepository.GetAll();
            if (works == null)
            {
                throw new Exception("Trabajos no encontrados.");
            }
            else
            {
                return mapper.Map<List<WorkResponseDto>>(works);
            }
        }

        public async Task DeleteWork(int id)
        {
            var work = await workRepository.GetById(w => w.IdWork == id);
            if (work == null)
            {
                throw new KeyNotFoundException("El trabajo no fue encontrado.");
            }
            else
            {
                work.Status = false;
                await workRepository.Update(work);
            }
        }

        public async Task<decimal> CalculateTotalWorkPrice(int WorkId)
        {
            decimal WorkPrice = 0;
            var work = await workRepository.GetById(w => w.IdWork == WorkId);
            foreach(var item in work.Materials)
            {
                int MaterialId = item.IdMaterial;
                decimal MaterialQuantity = item.Quantity;
                WorkPrice += await MaterialService.CalculateSubTotal(MaterialId, MaterialQuantity);
            }
            return WorkPrice;
        }

    }
}
