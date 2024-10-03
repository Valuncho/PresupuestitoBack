using AutoMapper;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Models;

namespace PresupuestitoBack
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            // Budget
            CreateMap<Budget, BudgetResponseDto>().ReverseMap();
            CreateMap<BudgetRequestDto, Budget>().ReverseMap();

            // Category
            CreateMap<Category, CategoryResponseDto>().ReverseMap();
            CreateMap<CategoryRequestDto, Category>().ReverseMap();

            // Client
            CreateMap<Client, ClientResponseDto>()
                .ForMember(dest => dest.IdPerson, opt => opt.MapFrom(src => src.OPerson));
            CreateMap<ClientRequestDto, Client>().ReverseMap();

            // ClientHistory
            CreateMap<ClientHistory, ClientHistoryResponseDto>()
                .ForMember(dest => dest.IdClient, opt => opt.MapFrom(src => src.Oclient))
                .ForMember(dest => dest.IdBudgets, opt => opt.MapFrom(src => src.Budgets)); ;
            CreateMap<ClientHistoryRequestDto, ClientHistory>().ReverseMap();

            // Cost
            CreateMap<Cost, CostResponseDto>().ReverseMap();
            CreateMap<CostRequestDto, Cost>().ReverseMap();

            // Employee
            CreateMap<Employee, EmployeeResponseDto>()
                .ForMember(dest => dest.IdPerson, opt => opt.MapFrom(src => src.OPerson));
            CreateMap<EmployeeRequestDto, Employee>().ReverseMap();

            // EmployeeHistory
            CreateMap<EmployeeHistory, EmployeeHistoryResponseDto>()
                .ForMember(dest => dest.IdEmployee, opt => opt.MapFrom(src => src.OEmployee));
            CreateMap<EmployeeHistoryRequestDto, EmployeeHistory>().ReverseMap();

            // FixedCost
            CreateMap<FixedCost, FixedCostResponseDto>().ReverseMap();
            CreateMap<FixedCostRequestDto, FixedCost>().ReverseMap();

            // Invoice
            CreateMap<Invoice, InvoiceResponseDto>().ReverseMap();
            CreateMap<InvoiceRequestDto, Invoice>().ReverseMap();

            // InvoiceItem
            CreateMap<InvoiceItem, InvoiceItemResponseDto>().ReverseMap();
            CreateMap<InvoiceItemRequestDto, InvoiceItem>().ReverseMap();

            // Material
            CreateMap<Material, MaterialResponseDto>()
                .ForMember(dest => dest.IdSubCategory, opt => opt.MapFrom(src => src.OSubcategory));
            CreateMap<MaterialRequestDto, Material>().ReverseMap();

            // Item
            CreateMap<Item, ItemResponseDto>().ReverseMap();
            CreateMap<ItemRequestDto, Item>().ReverseMap();

            // Payment
            CreateMap<Payment, PaymentResponseDto>().ReverseMap();
            CreateMap<PaymentRequestDto, Payment>().ReverseMap();

            // Person
            CreateMap<Person, PersonResponseDto>().ReverseMap();
            CreateMap<PersonRequestDto, Person>().ReverseMap();

            // Salary
            CreateMap<Salary, SalaryResponseDto>().ReverseMap();
            CreateMap<SalaryRequestDto, Salary>().ReverseMap();

            // SubCategoryMaterial
            CreateMap<SubCategoryMaterial, SubCategoryMaterialResponseDto>()
                .ForMember(dest => dest.categoryId, opt => opt.MapFrom(src => src.OCategory));
            CreateMap<SubCategoryMaterialRequestDto, SubCategoryMaterial>().ReverseMap();

            // Supplier
            CreateMap<Supplier, SupplierResponseDto>()
            .ForMember(dest => dest.IdPerson, opt => opt.MapFrom(src => src.OPerson));
            CreateMap<SupplierRequestDto, Supplier>().ReverseMap();

            // SupplierHistory
            CreateMap<SupplierHistory, SupplierHistoryResponseDto>().ReverseMap();
            CreateMap<SupplierHistoryRequestDto, SupplierHistory>().ReverseMap();

            // Work
            CreateMap<Work, WorkResponseDto>()
                .ForMember(dest => dest.IdItems, opt => opt.MapFrom(src => src.OMaterials))
                .ForMember(dest => dest.IdWork, opt => opt.MapFrom(src => src.IdWork));
            CreateMap<WorkRequestDto, Work>().ReverseMap();
        }
    }
}
