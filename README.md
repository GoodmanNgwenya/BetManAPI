# BetManAPI
This is a scalable and extensible .NET 8 API project for integrating with multiple third-party wallet providers for virtual sports betting transactions. The system is designed with SOLID principles in mind and is containerized for modern deployment workflows.

# Features

- Vendor-agnostic integration architecture
- Supports operations:
  - Authenticate Player
  - Get Player Balance
  - Debit, Credit, Refund
- Logs request/response messages to a SQL Server database
- Implements Dependency Injection
- Unit tested with xUnit and Moq
- Swagger-enabled for testing endpoints
- Containerized via Docker

# Architecture Overview

# Presentation Layer  
- 'WalletController' (API endpoints)

# Application Layer  
 - 'IWalletService', 'VendorAService', 'DatabaseLogger'

# Infrastructure/Data Layer  
- SQL Server for transaction logs ('MessageLogs' table)

# External  
- Third-Party Wallet APIs (e.g., VendorA)

# SOLID Principles Applied

| Principle | Application |
|----------|-------------|
| S – Single Responsibility | 'VendorAService' only handles wallet logic; 'DatabaseLogger' only logs. |
| O – Open/Closed | New vendors (e.g., VendorBService) can be added without modifying existing code. |
| L – Liskov Substitution | All services implement 'IWalletService', so can be substituted freely. |
| I – Interface Segregation | Interface remains focused; separate interfaces can be added if needed. |
| D – Dependency Inversion | Controller depends on `IWalletService`, not concrete classes. Logger depends on 'IMessageLogger'. |
