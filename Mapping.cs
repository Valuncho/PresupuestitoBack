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
<<<<<<< HEAD
            CreateMap<SupplierHistory, SupplierHistoryDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<SubCategory, SubCategoryDto>().ReverseMap();
            CreateMap<Material, MaterialDto>().ReverseMap();
=======
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Budget, BudgetDto>().ReverseMap();
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<ClientHistory, ClientHistoryDto>().ReverseMap();
            CreateMap<Invoice, InvoiceDto>().ReverseMap();
            CreateMap<InvoiceItem, InvoiceItemDto>().ReverseMap();
            CreateMap<Payment, PaymentDto>().ReverseMap();

            //CreateMap<Supplier, SupplierDto>().ReverseMap();
            //CreateMap<SupplierHistory, SupplierHistoryDto>().ReverseMap();
            //CreateMap<Work, WorkDto>().ReverseMap();
            //CreateMap<Item, ItemDao>().ReverseMap();
            //CreateMap<Cost, CostDto>().ReverseMap();

            //CreateMap<SupplierHistory, SupplierHistoryDto>().ReverseMap();
            //CreateMap<Category, CategoryDto>().ReverseMap();
            //CreateMap<SubCategory, SubCategoryDto>().ReverseMap();
            //CreateMap<Material, MaterialDto>().ReverseMap();

>>>>>>> 29122568a473bcb76fc8acfb3a42b22589cfb67c
        }
    }
}