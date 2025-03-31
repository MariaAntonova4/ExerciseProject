using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class DBMovie:DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public DBMovie(DbContextOptions<DBMovie> options) : base(options) { 
        
        }
    }
}
