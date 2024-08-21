using PresupuestitoBack.Models;

namespace PresupuestitoBack.DTOs.RequestDTOs
{
    public class PaymentRequestDto
    {
        public Invoice OInvoice { get; set; }
        public Budget OBudget { get; set; }
    }
}
