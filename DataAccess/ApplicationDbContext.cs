using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.Models;

namespace PresupuestitoBack.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<Person> Persons { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<SupplierHistory> SupplierHistories { get; set; }
        public DbSet<Material> Materials { get; set; }
    }
}
