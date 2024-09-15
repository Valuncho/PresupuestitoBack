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
            CreateMap<Client, ClientResponseDto>().ReverseMap();
            CreateMap<ClientRequestDto, Client>().ReverseMap();

            // ClientHistory
            CreateMap<ClientHistory, ClientHistoryResponseDto>().ReverseMap();
            CreateMap<ClientHistoryRequestDto, ClientHistory>().ReverseMap();

            // Cost
            CreateMap<Cost, CostResponseDto>().ReverseMap();
            CreateMap<CostRequestDto, Cost>().ReverseMap();

            // Employee
            CreateMap<Employee, EmployeeResponseDto>().ReverseMap();
            CreateMap<EmployeeRequestDto, Employee>().ReverseMap();

            // EmployeeHistory
            CreateMap<EmployeeHistory, EmployeeHistoryResponseDto>().ReverseMap();
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
            CreateMap<Material, MaterialResponseDto>().ReverseMap();
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
            CreateMap<SubCategoryMaterial, SubCategoryMaterialResponseDto>().ReverseMap();
            CreateMap<SubCategoryMaterialRequestDto, SubCategoryMaterial>().ReverseMap();

            // Supplier
            CreateMap<Supplier, SupplierResponseDto>().ReverseMap();
            CreateMap<SupplierRequestDto, Supplier>().ReverseMap();

            // SupplierHistory
            CreateMap<SupplierHistory, SupplierHistoryResponseDto>().ReverseMap();
            CreateMap<SupplierHistoryRequestDto, SupplierHistory>().ReverseMap();

            // Work
            CreateMap<Work, WorkResponseDto>().ReverseMap();
            CreateMap<WorkRequestDto, Work>().ReverseMap();
        }
    }
}
