using Microsoft.EntityFrameworkCore;
using ImageBinaryConvert.Models;

namespace ImageBinaryConvert.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Client { get; set; }
    }
}