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

        public async Task<User?> ValidateUserAsync(string name, string password)
        {
            return await Users.FirstOrDefaultAsync(u => u.Name == name && u.Password == password);
        }
    }
}
