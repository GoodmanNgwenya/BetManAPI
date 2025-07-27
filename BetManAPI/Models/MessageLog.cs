namespace BetManAPI.Models
{
    public class MessageLog
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string ExternalSystem { get; set; }
        public string Endpoint { get; set; }
        public string RequestPayload { get; set; }
        public string ResponsePayload { get; set; }
        public int HttpStatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}
