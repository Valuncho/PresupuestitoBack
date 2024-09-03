using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Repositories
{
    public class SubCategoryRepository : Repository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(ApplicationDbContext context) : base(context)
        {
            
        }

        /*
        public async public async Task<SubCategory?> GetSubCategoryByNameAsync(string name)
        {

        }
        */

    }
}
