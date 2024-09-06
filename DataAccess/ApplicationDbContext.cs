using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.Models;

namespace PresupuestitoBack.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<Person> Persons { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientHistory> ClientsHistorys { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoicesItems { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Salary> Salarys { get; set;}
        public DbSet<FixedCost> FixedCosts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeHistory> EmployeeHistorys { get; set; }
    }
}
