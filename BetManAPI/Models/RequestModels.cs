namespace BetManAPI.Models
{
    public class AuthenticateRequest
    {
        public string PlayerId { get; set; }
    }

    public class BalanceRequest
    {
        public string PlayerId { get; set; }
    }

    public class DebitRequest
    {
        public string PlayerId { get; set; }
        public decimal Amount { get; set; }
    }

    public class CreditRequest
    {
        public string PlayerId { get; set; }
        public decimal Amount { get; set; }
    }

    public class RefundRequest
    {
        public string PlayerId { get; set; }
        public decimal Amount { get; set; }
    }

}
