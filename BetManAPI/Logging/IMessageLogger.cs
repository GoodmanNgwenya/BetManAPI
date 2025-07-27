namespace BetManAPI.Logging
{
    public interface IMessageLogger
    {
        Task LogAsync(
            string externalSystem,
            string endpoint,
            string requestPayload,
            string responsePayload,
            int httpStatusCode,
            bool isSuccess,
            string errorMessage = null
        );
    }

}
