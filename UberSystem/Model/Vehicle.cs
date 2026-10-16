using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UberSystem.Model
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string PlateNumber { get; set; }
        [Required]
        public string color { get; set; }
        [Required]
        public int DriverId { get; set; }
        [ForeignKey("DriverId")]
        public User Driver { get; set; }
    }
}
