using System.ComponentModel.DataAnnotations;

namespace UberSystem.DTOs.payments
{
    public class createupdateDTO
    {
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
