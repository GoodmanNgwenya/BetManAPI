using Azure;
using BetManAPI.Interfaces;
using BetManAPI.Logging;
using BetManAPI.Models;
using System.Text.Json;

namespace BetManAPI.Services
{
    //SRP: This service only handles logic related to VendorA wallet operations.
    //OCP: This class extends behavior by implementing IWalletService for a new vendor.
    public class VendorAService : IWalletService
    {
        private readonly IMessageLogger _logger;

        public VendorAService(IMessageLogger logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Authenticates a player with VendorA.
        /// Simulates an authentication response and logs the request and response details.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest request)
        {
            var requestPayload = JsonSerializer.Serialize(request);

            var response = new AuthenticateResponse { Success = true, Message = "Authenticated by VendorA" };
            var responsePayload = JsonSerializer.Serialize(response);

            await _logger.LogAsync("VendorA", "Authenticate", requestPayload, responsePayload, 200, true);

            return response;
        }

        /// <summary>
        /// Retrieves the balance of a player from VendorA.
        /// Simulates a balance query and logs the request and response.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BalanceResponse> GetBalanceAsync(BalanceRequest request)
        {
            var requestPayload = JsonSerializer.Serialize(request);
            var response = new BalanceResponse { Balance = 1500.75m };
            var responsePayload = JsonSerializer.Serialize(response);

            await _logger.LogAsync("VendorA", "GetBalance", requestPayload, responsePayload, 200, true);

            return response;
        }

        /// <summary>
        /// Debits a specified amount from a player's wallet via VendorA.
        /// Simulates a debit operation and logs the transaction.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DebitResponse> DebitAsync(DebitRequest request)
        {
            var requestPayload = JsonSerializer.Serialize(request);
            var response = new DebitResponse { Success = true };
            var responsePayload = JsonSerializer.Serialize(response);

            await _logger.LogAsync("VendorA", "Debit", requestPayload, responsePayload, 200, true);

            return response;
        }

        /// <summary>
        /// Credits a specified amount to a player's wallet via VendorA.
        /// Simulates a credit operation and logs the transaction.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CreditResponse> CreditAsync(CreditRequest request)
        {
            var requestPayload = JsonSerializer.Serialize(request);
            var response = new CreditResponse { Success = true };
            var responsePayload = JsonSerializer.Serialize(response);

            await _logger.LogAsync("VendorA", "Credit", requestPayload, responsePayload, 200, true);

            return response;
        }

        /// <summary>
        /// Refunds a previously debited transaction to the player's wallet via VendorA.
        /// Simulates a refund operation and logs the transaction.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<RefundResponse> RefundAsync(RefundRequest request)
        {
            var requestPayload = JsonSerializer.Serialize(request);
            var response = new RefundResponse { Success = true };
            var responsePayload = JsonSerializer.Serialize(response);

            await _logger.LogAsync("VendorA", "Refund", requestPayload, responsePayload, 200, true);

            return response;
        }
    }
}
