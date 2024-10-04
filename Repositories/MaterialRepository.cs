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
            this.context = context;
        }

        public override async Task<bool> Insert(Material material)
        {
            await context.Materials.AddAsync(material);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Update(Material material)
        {
            context.Materials.Update(material);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<Material> GetById(int id)
        {
            return await context.Materials.Include(o => o.OSubcategoryMaterial)
                .Where(o => o.Status == true && o.MaterialId == id).FirstAsync();
        }

        public override async Task<List<Material>> GetAll(Expression<Func<Material, bool>>? filter = null)
        {
            return await context.Materials.Include(m => m.OSubcategoryMaterial) // Incluir la entidad Subcategory
            .ToListAsync();
        }

        public async Task<InvoiceItem?> GetMaterialPrice(int MaterialId)
        {          
            return await context
                   .InvoiceItems
                   .Where(i => i.MaterialId == MaterialId)
                   .Include(i => i.OMaterial)
                   .FirstOrDefaultAsync();
        }

    }
}
