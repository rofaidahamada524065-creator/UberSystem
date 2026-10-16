using System.ComponentModel.DataAnnotations;

namespace UberSystem.DTOs.User
{
    public class CreateUpdateUser
    {
        public int DriverId { get; set; }
        public int RiderId { get; set; }
        [Required, StringLength(100, MinimumLength = 3)]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
