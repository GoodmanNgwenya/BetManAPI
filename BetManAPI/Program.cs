using BetManAPI.Interfaces;
using BetManAPI.Logging;
using BetManAPI.Services;
using Microsoft.EntityFrameworkCore;
using System;

// SOLID Principle Summary:
// S - Each service and logger has a single responsibility.
// O - New vendors can be added without modifying existing services.
// L - All wallet services can replace each other without breaking functionality.
// I - Interfaces are lean and can be split if responsibilities grow.
// D - Services are injected via interfaces (constructor injection).


var builder = WebApplication.CreateBuilder(args);

//DbContext configuration
builder.Services.AddDbContext<LoggingDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DIP: Higher-level modules depend on abstractions (interfaces), not concrete implementations.
builder.Services.AddScoped<IWalletService, VendorAService>();
builder.Services.AddScoped<IMessageLogger, DatabaseLogger>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
