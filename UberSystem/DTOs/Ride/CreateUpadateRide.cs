using System.ComponentModel.DataAnnotations;

namespace UberSystem.DTOs.Ride
{
    public class CreateUpadateRide
    {
        [MaxLength(150)]
        [Required]
        public string PickupLocation { get; set; }
        [MaxLength(150)]
        [Required]
        public string DropOffLocation { get; set; }
        [Range(20, 5000)]
        public int Fare { get; set; }
        [Required]
        public string status { get; set; }

        public int RiderId { get; set; }



        public int DriverId { get; set; }
    }
}
