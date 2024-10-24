using Microsoft.EntityFrameworkCore;
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

        public override async Task<Category> GetById(int id)
        {
            return await context.Categories
                .Where(c => c.Status == true && c.CategoryId == id).FirstAsync();
        }

        public override async Task<List<Category>> GetAll(Expression<Func<Category, bool>>? filter = null)
        {
            return await context.Categories
                .Where(o => o.Status == true)
                .ToListAsync();
        }

    }
}
