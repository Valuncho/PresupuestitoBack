using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.Models;

namespace PresupuestitoBack.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
<<<<<<< HEAD


        public DbSet<Person> Persons { get; set; }
<<<<<<< HEAD
=======
=======
>>>>>>> ae33ac3b1da52f35ae86f10bfc6ba2e3b76509fd
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
<<<<<<< HEAD

>>>>>>> 29122568a473bcb76fc8acfb3a42b22589cfb67c
=======
>>>>>>> ae33ac3b1da52f35ae86f10bfc6ba2e3b76509fd
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<SupplierHistory> SupplierHistories { get; set; }
        public DbSet<Material> Materials { get; set; }
<<<<<<< HEAD
<<<<<<< HEAD
=======


>>>>>>> 29122568a473bcb76fc8acfb3a42b22589cfb67c
=======
>>>>>>> ae33ac3b1da52f35ae86f10bfc6ba2e3b76509fd
    }
}
