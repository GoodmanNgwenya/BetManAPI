using BetManAPI.Controllers;
using BetManAPI.Interfaces;
using BetManAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BetManAPI.Tests
{
    public class WalletControllerTests
    {
        private readonly Mock<IWalletService> _walletServiceMock;
        private readonly WalletController _controller;

        public WalletControllerTests()
        {
            _walletServiceMock = new Mock<IWalletService>();
            _controller = new WalletController(_walletServiceMock.Object);
        }

        // -------------------------
        // Authenticate Tests
        // -------------------------
        [Fact]
        public async Task Authenticate_ReturnsOk()
        {
            // Arrange: Prepare input and expected output
            var request = new AuthenticateRequest { PlayerId = "player1" };
            var expected = new AuthenticateResponse { Success = true, Message = "OK" };

            // Set up the mocked service to return expected output
            _walletServiceMock
                .Setup(s => s.AuthenticateAsync(request))
                .ReturnsAsync(new AuthenticateResponse { Success = true, Message = "OK" });

            // Act: Call the controller method
            var result = await _controller.Authenticate(request);

            // Assert: Check that the result is an OkObjectResult
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actual = Assert.IsType<AuthenticateResponse>(okResult.Value);

            // Assert: Check that the value returned matches expected output
            //Assert.Equal(expected, okResult.Value);
            Assert.Equal(expected.Success, actual.Success);
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public async Task Authenticate_ReturnsFailure()
        {
            // Arrange
            var request = new AuthenticateRequest { PlayerId = "invalidPlayer" };
            var expected = new AuthenticateResponse { Success = false, Message = "Authentication failed" };

            _walletServiceMock
                .Setup(s => s.AuthenticateAsync(request))
                .ReturnsAsync(expected);

            // Act
            var result = await _controller.Authenticate(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actual = Assert.IsType<AuthenticateResponse>(okResult.Value);
            Assert.False(actual.Success);
            Assert.Equal(expected.Message, actual.Message);
        }

        // -------------------------
        // GetBalance Tests
        // -------------------------
        [Fact]
        public async Task GetBalance_ReturnsOk()
        {
            // Arrange
            var request = new BalanceRequest { PlayerId = "player1" };
            var expected = new BalanceResponse { Balance = 1200 };

            _walletServiceMock
                .Setup(s => s.GetBalanceAsync(request))
                .ReturnsAsync(new BalanceResponse { Balance=1200});

            // Act
            var result = await _controller.GetBalance(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actual = Assert.IsType<BalanceResponse>(okResult.Value);

            // Only assert the Balance value for simplicity
            //Assert.Equal(expected.Balance, ((BalanceResponse)okResult.Value).Balance);
            Assert.Equal(expected.Balance, actual.Balance);
        }

        [Fact]
        public async Task GetBalance_ReturnsZeroBalance()
        {
            // Arrange
            var request = new BalanceRequest { PlayerId = "player1" };
            var expected = new BalanceResponse { Balance = 0 };

            _walletServiceMock
                .Setup(s => s.GetBalanceAsync(request))
                .ReturnsAsync(expected);

            // Act
            var result = await _controller.GetBalance(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actual = Assert.IsType<BalanceResponse>(okResult.Value);
            Assert.Equal(0, actual.Balance);
        }

        // -------------------------
        // Debit Tests
        // -------------------------
        [Fact]
        public async Task Debit_ReturnsOk()
        {
            // Arrange
            var request = new DebitRequest { PlayerId = "player1", Amount = 50 };
            var expected = new DebitResponse { Success = true };

            _walletServiceMock
                .Setup(s => s.DebitAsync(request))
                .ReturnsAsync(expected);

            // Act
            var result = await _controller.Debit(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expected.Success, ((DebitResponse)okResult.Value).Success);
        }

        [Fact]
        public async Task Debit_ReturnsFailure()
        {
            // Arrange
            var request = new DebitRequest { PlayerId = "player1", Amount = 9999 }; // unrealistic amount
            var expected = new DebitResponse { Success = false };

            _walletServiceMock
                .Setup(s => s.DebitAsync(request))
                .ReturnsAsync(expected);

            // Act
            var result = await _controller.Debit(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.False(((DebitResponse)okResult.Value).Success);
        }

        // -------------------------
        // Credit Tests
        // -------------------------
        [Fact]
        public async Task Credit_ReturnsOk()
        {
            // Arrange
            var request = new CreditRequest { PlayerId = "player1", Amount = 100 };
            var expected = new CreditResponse { Success = true };

            _walletServiceMock
                .Setup(s => s.CreditAsync(request))
                .ReturnsAsync(expected);

            // Act
            var result = await _controller.Credit(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expected.Success, ((CreditResponse)okResult.Value).Success);
        }

        [Fact]
        public async Task Credit_ReturnsFailure()
        {
            // Arrange
            var request = new CreditRequest { PlayerId = "player1", Amount = -100 }; // invalid amount
            var expected = new CreditResponse { Success = false };

            _walletServiceMock
                .Setup(s => s.CreditAsync(request))
                .ReturnsAsync(expected);

            // Act
            var result = await _controller.Credit(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.False(((CreditResponse)okResult.Value).Success);
        }

        // -------------------------
        // Refund Tests
        // -------------------------
        [Fact]
        public async Task Refund_ReturnsOk()
        {
            // Arrange
            var request = new RefundRequest { PlayerId = "player1", Amount = 25 };
            var expected = new RefundResponse { Success = true };

            _walletServiceMock
                .Setup(s => s.RefundAsync(request))
                .ReturnsAsync(expected);

            // Act
            var result = await _controller.Refund(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expected.Success, ((RefundResponse)okResult.Value).Success);
        }

        [Fact]
        public async Task Refund_ReturnsFailure()
        {
            // Arrange
            var request = new RefundRequest { PlayerId = "player1", Amount = 0 }; // invalid amount
            var expected = new RefundResponse { Success = false };

            _walletServiceMock
                .Setup(s => s.RefundAsync(request))
                .ReturnsAsync(expected);

            // Act
            var result = await _controller.Refund(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.False(((RefundResponse)okResult.Value).Success);
        }

    }
}
