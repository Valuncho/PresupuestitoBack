namespace PresupuestitoBack.DTOs.Request
{
    public class EmployeeHistoryRequestDto
    {
        public decimal Quantity { get; set; }
        public DateTime Date { get; set; }
        public int IdEmployee {  get; set; }
    }
}
