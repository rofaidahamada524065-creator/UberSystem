using System.ComponentModel.DataAnnotations;

namespace UberSystem.DTOs.Ride
{
    public class ReportDTo
    {
        public int TotalRides { get; set; }
        public int CompletedRides { get; set; }
        public int CancelledRides { get; set; }
        public int ActiveRides { get; set; }
        public decimal TotalRevenue { get; set; }
        public double AverageFare { get; set; }

    }
}
