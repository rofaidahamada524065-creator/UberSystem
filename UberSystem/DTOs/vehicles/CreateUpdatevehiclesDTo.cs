using System.ComponentModel.DataAnnotations;

namespace UberSystem.DTOs.vehicles
{
    public class CreateUpdatevehiclesDTo
    {
        [Required]
        [MaxLength(20)]
        public string PlateNumber { get; set; }
        [Required]
        public string color { get; set; }
        [Required]
        public int DriverId { get; set; }
    }
}
