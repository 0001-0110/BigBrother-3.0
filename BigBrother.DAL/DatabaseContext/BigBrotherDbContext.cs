using Microsoft.EntityFrameworkCore;
using BigBrother.DAL.Utilities;

namespace BigBrother.DAL.DatabaseContext
{
    public class BigBrotherDbContext : DbContext
    {
        public BigBrotherDbContext()
            : base(new DbContextOptionsBuilder<BigBrotherDbContext>()
                  .UseSqlServer(ConfigurationUtility.GetConnectionString()).Options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TODO Add all models for the database initialisation
        }
    }
}
