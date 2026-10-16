using System.ComponentModel.DataAnnotations;

namespace UberSystem.DTOs.payments
{
    public class paymentsDTO
    {
        public int Id { get; set; }
        [Range(20, 500)]
        public int Amount { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public string status { get; set; }
        public int RideId { get; set; }
    }
}
