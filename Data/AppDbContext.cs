
using Microsoft.EntityFrameworkCore;
using AskeOgViktorProjekt.Models;

namespace AskeOgViktorProjekt.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Image> Images { get; set; } = default!;

        // Simple helper for login (example only; consider hashing passwords)
        public async Task<User?> ValidateUserAsync(string name, string password)
        {
            return await Users.FirstOrDefaultAsync(u => u.Name == name && u.Password == password);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ---- User ----
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .HasMaxLength(200);

            // Optional: index on Name if you use it for lookups
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Name);

            // ---- Image ----
            modelBuilder.Entity<Image>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<Image>()
                .Property(i => i.OriginalFileName)
                .HasMaxLength(255);

            modelBuilder.Entity<Image>()
                .Property(i => i.ContentType)
                .HasMaxLength(100);

            modelBuilder.Entity<Image>()
                .Property(i => i.RelativePath)
                .HasMaxLength(500);

            // Relationship: many Images can belong to one User (optional)
            modelBuilder.Entity<Image>()
                .HasOne(i => i.User)
                .WithMany(u => u.Images)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
