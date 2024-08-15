using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.Models;

namespace PresupuestitoBack.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<Person> Persons { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Work> Works { get; set; }
    }
}
