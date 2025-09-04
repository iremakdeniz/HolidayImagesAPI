using HolidayImagesAPI.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace HolidayImagesAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Images> Images { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.SubCategories)
                .WithOne(c => c.ParentCategory)
                .HasForeignKey(c => c.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Images)
                .WithOne(i => i.Category)
                .HasForeignKey(i => i.CategoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
