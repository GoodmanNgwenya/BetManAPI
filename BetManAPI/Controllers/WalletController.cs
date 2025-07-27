using BetManAPI.Interfaces;
using BetManAPI.Models;
using BetManAPI.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BetManAPI.Controllers
{
    // DIP: The controller depends on the IWalletService abstraction, not a specific vendor class.
    //LSP: Any IWalletService implementation(e.g., VendorAService, VendorBService) can be used here.
    [ApiController]
    [Route("api/[controller]")]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;

        // Applying SOLID: This follows the Dependency Inversion Principle (DIP)
        /// <summary>
        /// Initializes the WalletController with a wallet service.
        /// </summary>
        /// <param name="walletService">Injected implementation of IWalletService (e.g., VendorAService).</param>
        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        /// <summary>
        /// Authenticates a player with the configured wallet provider.
        /// </summary>
        /// <param name="request">Authentication request object.</param>
        /// <returns>200 OK with authentication response.</returns>
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequest request)
        {
            var result = await _walletService.AuthenticateAsync(request);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves the player's wallet balance from the external wallet provider.
        /// </summary>
        /// <param name="request">Balance request including player ID or token.</param>
        /// <returns>200 OK with current balance.</returns>
        [HttpPost("balance")]
        public async Task<IActionResult> GetBalance([FromBody] BalanceRequest request)
        {
            var result = await _walletService.GetBalanceAsync(request);
            return Ok(result);
        }

        /// <summary>
        /// Debits the specified amount from the player's wallet.
        /// </summary>
        /// <param name="request">Debit request including amount and player details.</param>
        /// <returns>200 OK with debit status.</returns>
        [HttpPost("debit")]
        public async Task<IActionResult> Debit([FromBody] DebitRequest request)
        {
            var result = await _walletService.DebitAsync(request);
            return Ok(result);
        }

        /// <summary>
        /// Credits the specified amount to the player's wallet.
        /// </summary>
        /// <param name="request">Credit request including amount and player details.</param>
        /// <returns>200 OK with credit status.</returns>
        [HttpPost("credit")]
        public async Task<IActionResult> Credit([FromBody] CreditRequest request)
        {
            var result = await _walletService.CreditAsync(request);
            return Ok(result);
        }

        /// <summary>
        /// Refunds a previous debit transaction back to the player's wallet.
        /// </summary>
        /// <param name="request">Refund request with original transaction details.</param>
        /// <returns>200 OK with refund status.</returns>

        [HttpPost("refund")]
        public async Task<IActionResult> Refund([FromBody] RefundRequest request)
        {
            var result = await _walletService.RefundAsync(request);
            return Ok(result);
        }
    }
}
