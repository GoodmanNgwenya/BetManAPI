using BetManAPI.Models;

namespace BetManAPI.Logging
{
    // SRP (Single Responsibility Principle):
    // This class is solely responsible for logging request/response data to the database.
    // It does not handle business logic or transformation of the data.

    // DIP (Dependency Inversion Principle):
    // The logger depends on the abstract `LoggingDbContext` (injected), rather than managing its own connection logic.

    public class DatabaseLogger : IMessageLogger
    {
        private readonly LoggingDbContext _context;

        /// <summary>
        /// Constructor with dependency injection of the logging database context.
        /// </summary>
        /// <param name="context">EF Core DbContext for logging purposes.</param>
        public DatabaseLogger(LoggingDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Logs the details of an external API call to the database.
        /// </summary>
        /// <param name="externalSystem">The name of the external system (e.g., "VendorA").</param>
        /// <param name="endpoint">The specific endpoint that was called.</param>
        /// <param name="requestPayload">The JSON-formatted request data.</param>
        /// <param name="responsePayload">The JSON-formatted response data.</param>
        /// <param name="httpStatusCode">The HTTP status code returned from the external API.</param>
        /// <param name="isSuccess">Indicates if the call was successful or not.</param>
        /// <param name="errorMessage">Optional error message if the call failed.</param>
        public async Task LogAsync(
            string externalSystem,
            string endpoint,
            string requestPayload,
            string responsePayload,
            int httpStatusCode,
            bool isSuccess,
            string errorMessage = null
        )
        {
            var log = new MessageLog
            {
                ExternalSystem = externalSystem,
                Endpoint = endpoint,
                RequestPayload = requestPayload,
                ResponsePayload = responsePayload,
                HttpStatusCode = httpStatusCode,
                IsSuccess = isSuccess,
                ErrorMessage = errorMessage
            };

            // Add the log entry to the EF Core DbContext and persist it to the database
            _context.MessageLogs.Add(log);
            await _context.SaveChangesAsync();
        }
    }

}
