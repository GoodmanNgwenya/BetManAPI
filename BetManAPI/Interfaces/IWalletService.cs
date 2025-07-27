using BetManAPI.Models;

namespace BetManAPI.Interfaces
{
    //ISP: If needed, this interface can be split into smaller interfaces like IAuthenticateService, ITransactionService, etc.
    //OCP: You can add new wallet providers (e.g., VendorBService) without changing this interface.
    public interface IWalletService
    {
        Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest request);
        Task<BalanceResponse> GetBalanceAsync(BalanceRequest request);
        Task<DebitResponse> DebitAsync(DebitRequest request);
        Task<CreditResponse> CreditAsync(CreditRequest request);
        Task<RefundResponse> RefundAsync(RefundRequest request);
    }
}
