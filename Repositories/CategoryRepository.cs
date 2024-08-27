using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

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
    }
}
