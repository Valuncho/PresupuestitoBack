using AutoMapper;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
    public class SupplierHistoryService
    {
        private readonly ISupplierHistoryRepository supplierHistoryRepository;
        private readonly IMapper mapper;

        public SupplierHistoryService(ISupplierHistoryRepository supplierHistoryRepository, IMapper mapper)
        {
            this.supplierHistoryRepository = supplierHistoryRepository;
            this.mapper = mapper;
        }
     
        public async Task CreateSupplierHistory(SupplierHistoryDto supplierHistoryDto)
        {
            var supplierHistory = mapper.Map<SupplierHistory>(supplierHistoryDto);
            await supplierHistoryRepository.Insert(supplierHistory);
        }

        public async Task UpdateSupplierHistory(SupplierHistoryDto supplierHistoryDto)
        {
            var existingSupplierHistory = await supplierHistoryRepository.GetById(s => s.SupplierHistoryId == supplierHistoryDto.SupplierHistoryId);
            if (existingSupplierHistory == null)
            {
                throw new KeyNotFoundException("El historial del proovedor no existe.");
            }
        }

        public async Task<SupplierHistoryDto> GetSupplierHistoryById(int id)
        {
            var supplierHistory = await supplierHistoryRepository.GetById(s => s.SupplierHistoryId == id);
            if (supplierHistory == null)
            {
                throw new KeyNotFoundException("El historial del proovedor no fue encontrado.");
            }
            else
            {
                return mapper.Map<SupplierHistoryDto>(supplierHistory);
            }
        }

        public async Task<List<SupplierHistoryDto>> GetSupplierHistories()
        {
            var supplierHistories = await supplierHistoryRepository.GetAll();
            return mapper.Map<List<SupplierHistoryDto>>(supplierHistories);
        }
    }
}
