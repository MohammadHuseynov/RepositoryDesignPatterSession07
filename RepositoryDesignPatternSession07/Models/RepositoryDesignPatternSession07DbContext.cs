using Microsoft.EntityFrameworkCore;
using RepositoryDesignPatternSession07.Models.DomainModels.ProductAggregates;

namespace RepositoryDesignPatternSession07.Models
{
    public class RepositoryDesignPatternSession07DbContext : DbContext

    {
        public RepositoryDesignPatternSession07DbContext()
        {

        }

        public RepositoryDesignPatternSession07DbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Product> Product { get; set; }
    }
}