using System.ComponentModel.DataAnnotations;

namespace UberSystem.DTOs.vehicles
{
    public class vehiclesDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string PlateNumber { get; set; }
        [Required]
        public string color { get; set; }
        [Required]
        public int DriverId { get; set; }
    }
}
