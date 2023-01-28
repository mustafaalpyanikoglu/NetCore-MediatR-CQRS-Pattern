using Microsoft.EntityFrameworkCore;
using Web_API.Models;

namespace Web_API.Data.Context
{
    public class MediatorContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=ALP;Database=MediatrDB; Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
