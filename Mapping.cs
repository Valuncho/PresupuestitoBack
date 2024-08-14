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
            CreateMap<SupplierHistory, SupplierHistoryDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<SubCategory, SubCategoryDto>().ReverseMap();
            CreateMap<Material, MaterialDto>().ReverseMap();
        }
    }
}