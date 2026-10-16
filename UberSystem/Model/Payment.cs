using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UberSystem.Model
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        [Range(20,500)]
        public int Amount{ get; set; }
        [Required]
        public string  PaymentMethod { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public string status { get; set; }
        public int RideId { get; set; }
        [ForeignKey("RideId")]
        public Ride ?ride { get; set; }
        
    }
}
