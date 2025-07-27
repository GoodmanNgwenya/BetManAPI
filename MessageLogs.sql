CREATE TABLE MessageLogs (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Timestamp DATETIME2 NOT NULL DEFAULT GETDATE(),
    ExternalSystem NVARCHAR(100) NOT NULL,
    Endpoint NVARCHAR(255) NOT NULL,
    RequestPayload NVARCHAR(MAX),
    ResponsePayload NVARCHAR(MAX),
    HttpStatusCode INT,
    IsSuccess BIT,
    ErrorMessage NVARCHAR(MAX)
);
