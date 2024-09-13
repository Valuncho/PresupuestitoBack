using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
    public class SupplierService
    {
        private readonly ISupplierRepository supplierRepository;
        private readonly IMapper mapper;

        public SupplierService(ISupplierRepository supplierRepository, IMapper mapper)
        {
            this.supplierRepository = supplierRepository;
            this.mapper = mapper;
        }

        public async Task CreateSupplier(SupplierRequestDto supplierRequestDto)
        {
            var supplier = mapper.Map<Supplier>(supplierRequestDto);
            supplier.Status = true;
            await supplierRepository.Insert(supplier);
        }

        public async Task UpdateSupplier(int id, SupplierRequestDto supplierRequestDto)
        {
            var existingSupplier = await supplierRepository.GetById(s => s.IdSupplier == id);
            if (existingSupplier == null)
            {
                throw new KeyNotFoundException("El proveedor no existe.");
            }
            else
            {
                var supplier = mapper.Map<Supplier>(supplierRequestDto);
                await supplierRepository.Update(supplier);
            }
        }

        public async Task<ActionResult<SupplierResponseDto>> GetSupplierById(int id)
        {
            var supplier = await supplierRepository.GetById(s => s.IdSupplier == id);
            if (supplier == null)
            {
                throw new KeyNotFoundException("El proveedor no fue encontrado.");
            }
            else
            {
                return mapper.Map<SupplierResponseDto>(supplier);
            }
        }

        public async Task<ActionResult<List<SupplierResponseDto>>> GetAllSuppliers()
        {
            var suppliers = await supplierRepository.GetAll();
            if (suppliers == null)
            {
                throw new Exception("Proveedores no encontrados.");
            }
            else
            {
                return mapper.Map<List<SupplierResponseDto>>(suppliers);
            }
        }

        public async Task DeleteSupplier(int id)
        {
            var supplier = await supplierRepository.GetById(s => s.IdSupplier == id);
            if (supplier == null)
            {
                throw new KeyNotFoundException("El proveedor no fue encontrado.");
            }
            else
            {
                supplier.Status = false;
                await supplierRepository.Update(supplier);
            }
        }

    }
}
