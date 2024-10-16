using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Repositories
{
    public class SubCategoryMaterialRepository : Repository<SubCategoryMaterial>, ISubCategoryMaterialRepository
    {

        private readonly ApplicationDbContext context;

        public SubCategoryMaterialRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<bool> Insert(SubCategoryMaterial subCategoryMaterial)
        {
            await context.SubCategoryMaterials.AddAsync(subCategoryMaterial);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Update(SubCategoryMaterial subCategoryMaterial)
        {
            context.SubCategoryMaterials.Update(subCategoryMaterial);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<SubCategoryMaterial> GetById(int id)
        {
            return await context.SubCategoryMaterials.Include(o => o.OCategory)
                .Where(o => o.Status == true && o.SubCategoryMaterialId == id).FirstAsync();
        }

        public override async Task<List<SubCategoryMaterial>> GetAll(Expression<Func<SubCategoryMaterial, bool>>? filter = null)
        {
            return await context.SubCategoryMaterials.Include(s => s.OCategory)
            .ToListAsync();
        }

    }
}
