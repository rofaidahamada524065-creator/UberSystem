using System.ComponentModel.DataAnnotations;

namespace UberSystem.Model
{
    public class User
    {
        [Key]
       
        public int Id { get; set; }

        public int DriverId { get; set; }
        public int RiderId { get; set; }
        [Required,StringLength(100,MinimumLength =3)]
        public string FullName { get; set; }
        [Required ]
        [EmailAddress]  
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string Role { get; set; }

        public Vehicle? vehicle { get; set; }

        public ICollection<Ride> Riderrides { get; set; } = new List<Ride>();
        public ICollection<Ride> DriverRide { get; set; } = new List<Ride>();


    }
}
