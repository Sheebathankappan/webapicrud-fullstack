using Microsoft.EntityFrameworkCore;
using WebAPICRUD.Models;

namespace WebAPICRUD.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        { 

        }

        public DbSet<Product> Products { get; set; }    

    }
}
