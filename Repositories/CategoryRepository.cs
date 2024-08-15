using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Repositories
{
    public class CategoryRepository<T> : ICategoryRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;

        public CategoryRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        protected DbSet<T> EntitySet
        {
            get
            {
                return context.Set<T>();
            }
        }

        public async Task<T> InsertCategory(T entity);

    }
}
