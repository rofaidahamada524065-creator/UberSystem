namespace UberSystem.DTOs.payments
{
    public class PaymentStatistic
    {
        public int TotalPayments { get; set; }
        public decimal TotalAmount { get; set; }
        public int SuccessfulPayments { get; set; }
        public int FailedPayments { get; set; }
    }
}
