using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UberSystem.Model
{
    public class Ride
    {
        public int Id { get; set; }
        [MaxLength(150)]
        [Required]
        public string PickupLocation { get; set; }
        [MaxLength(150)]
        [Required]
        public string DropOffLocation { get; set; }
        [Range(20,5000)]
        public int Fare { get; set; }
        [Required]
        public string  status { get; set; }

        public int RiderId { get; set; }
        [ForeignKey("RiderId")]
        public User? Rider { get; set; }
       
        
        public int DriverId { get; set; }
        [ForeignKey("DriverId")]
        public User? Driver { get; set; }

        public Payment ?payment { get; set; }
        public Rating ?rating { get; set; }


    }
}
