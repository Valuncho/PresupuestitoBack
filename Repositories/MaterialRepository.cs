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

        public override async Task<Material> GetById(Expression<Func<Material, bool>>? filter = null, bool tracked = true)
        {
            return await base.GetById(filter, tracked);
        }

        public override async Task<List<Material>> GetAll(Expression<Func<Material, bool>>? filter = null)
        {
            return await base.GetAll(filter);
        }

    }
}
