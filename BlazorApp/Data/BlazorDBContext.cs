using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace BlazorApp.Data
{
    public class BlazorDBContext : DbContext
    {
        public BlazorDBContext(DbContextOptions<BlazorDBContext> options)
            : base(options)
        {
            
        }

        public DbSet<EventRegistration> eventRegistration { get; set; }
    }
}
