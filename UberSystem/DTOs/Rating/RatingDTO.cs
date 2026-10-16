using System.ComponentModel.DataAnnotations;

namespace UberSystem.DTOs.Rating
{
    public class RatingDTO
    {
        public int Id { get; set; }
        [Range(1, 5)]
        public int Score { get; set; }
        [MaxLength(250)]
        public string Comment { get; set; }
        public int RideId { get; set; }
    }
}
