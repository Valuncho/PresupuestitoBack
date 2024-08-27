using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepositories;

namespace PresupuestitoBack.Repositories
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {


        public PaymentRepository(ApplicationDbContext context) : base(context)
        {
        }


        public override async Task<bool> Insert(Payment newPayment)
        {
            try
            {
                await base.Insert(newPayment);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override async Task<bool> Update(Payment updateService)
        {
            return await base.Update(updateService);
        }

        public override async Task<bool> Delete(int id)
        {
            return await base.Delete(id);
        }

    }
}


