using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Repositories
{
    public class WorkRepository : Repository<Work>, IWorkRepository
    {
        public WorkRepository(ApplicationDbContext context) : base(context)
        {

        }
        public override async Task<bool> Update(Work updateService)
        {
            var Service = await _context.Works.FirstOrDefaultAsync(x => x.IdWork == updateService.IdWork);
            if (Service == null) { return false; }

            Service.CostPrice = updateService.CostPrice;
            Service.Status = updateService.Status;
            Service.StatusSerialized = updateService.StatusSerialized;
            Service.Materials = updateService.Materials;
            Service.EstimatedHoursWorked = updateService.EstimatedHoursWorked;
            Service.DeadLine = updateService.DeadLine;
            Service.Notes = updateService.Notes;
            Service.Image = updateService.Image;

            _context.Works.Update(Service);
            await _context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Delete(int id)
        {
            var work = await _context.Works.Where(x => x.IdWork == id).FirstOrDefaultAsync();
            if (work != null)
            {
                _context.Works.Remove(work);
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public override async Task<bool> Insert(Work newWork)
        {
            try
            {
                var workExisting = await _context.Works.FirstOrDefaultAsync(x => x.IdWork == newWork.IdWork);

                if (workExisting != null)
                {
                    return false;
                }

                _context.Works.Add(newWork);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
