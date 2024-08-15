using AutoMapper;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;

namespace PresupuestitoBack
{
    public class Mapping : Profile
    {
        public Mapping() 
        {
            CreateMap<Work, WorkDto>().ReverseMap();
            CreateMap<Item, ItemDao>().ReverseMap();
            CreateMap<Cost, CostDto>().ReverseMap();
        }
    }
}
