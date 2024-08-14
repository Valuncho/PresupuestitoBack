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
    }
}
