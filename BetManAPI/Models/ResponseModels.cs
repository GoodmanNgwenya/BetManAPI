namespace BetManAPI.Models
{
    public class AuthenticateResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class BalanceResponse
    {
        public decimal Balance { get; set; }
    }

    public class DebitResponse
    {
        public bool Success { get; set; }
    }

    public class CreditResponse
    {
        public bool Success { get; set; }
    }

    public class RefundResponse
    {
        public bool Success { get; set; }
    }

}
