using BetManAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace BetManAPI.Logging
{
    public class LoggingDbContext : DbContext
    {
        public LoggingDbContext(DbContextOptions<LoggingDbContext> options) : base(options) { }

        public DbSet<MessageLog> MessageLogs { get; set; }
    }
}
