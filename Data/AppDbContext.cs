using Microsoft.EntityFrameworkCore;
using AskeOgViktorProjekt.Models;
using AskeOgViktorProjekt.Pages;


namespace AskeOgViktorProjekt.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }


        public DbSet<User> Users { get; set; } = default!;
    }
}
