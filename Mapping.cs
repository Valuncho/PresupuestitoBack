using AutoMapper;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Services;

namespace PresupuestitoBack
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Budget, BudgetDto>().ReverseMap();
            //CreateMap<Supplier, SupplierDto>().ReverseMap();
            //CreateMap<SupplierHistory, SupplierHistoryDto>().ReverseMap();
        }
    }
}