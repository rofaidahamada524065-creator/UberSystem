using System.ComponentModel.DataAnnotations;

namespace UberSystem.DTOs.Rating
{
    public class CreateUpdateRating
    {
        [Range(1, 5)]
        public int Score { get; set; }
        [MaxLength(250)]
        public string Comment { get; set; }
        public int RideId { get; set; }
    }
}
