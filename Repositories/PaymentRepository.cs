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

        public override async Task<bool> Update(Payment updateService)
        {
            var Service = await _context.Payments.FirstOrDefaultAsync(x => x.IdPayment == updateService.IdPayment);
            if (Service == null) { return false; }

            Service.Date = updateService.Date;
            Service.Amount = updateService.Amount;
            Service.DescriptionPayment = updateService.DescriptionPayment;
            //Service.Salary = updateService.Salary;
            Service.IdInvoice = updateService.IdInvoice;
            Service.IdBudget = updateService.IdBudget;
            
            _context.Payments.Update(Service);
            await _context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Delete(int id)
        {
            var payment = await _context.Payments.Where(x => x.IdPayment == id).FirstOrDefaultAsync();
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public override async Task<bool> Insert(Payment newPayment)
        {
            try
            {
                var paymentExisting = await _context.Payments.FirstOrDefaultAsync(x => x.IdPayment == newPayment.IdPayment);

                if (paymentExisting != null)
                {
                    return false;
                }

                _context.Payments.Add(newPayment);
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


