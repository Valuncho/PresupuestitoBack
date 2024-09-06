using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Repositories
{
    public class MaterialRepository : Repository<Material>, IMaterialRepository
    {
        private readonly ApplicationDbContext context;
        public MaterialRepository(ApplicationDbContext context) : base(context)
        {
           
        }

        /*
        public async Task<Category?> getCategoryByName(string name)
        {
            
        }
        */
        

        
        
    }
}
