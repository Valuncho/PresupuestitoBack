using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext context;

        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
        
        public override async Task<bool> Insert(Category category)
        {
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Update(Category category)
        {
            context.Categories.Update(category);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<Category?> GetById(Expression<Func<Category, bool>>? filter = null, bool tracked = true)
        {
            return await base.GetById(filter, tracked);
        }

        public override async Task<List<Category>> GetAll(Expression<Func<Category, bool>>? filter = null)
        {
            return await base.GetAll(filter);
        }

    }
}
