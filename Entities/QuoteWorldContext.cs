using Microsoft.EntityFrameworkCore;

namespace QuoteWorldAPI.Entities
{
    public class QuoteWorldContext : DbContext
    {
        public QuoteWorldContext(DbContextOptions<QuoteWorldContext> options) : base(options) { }

        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Rating> Rating { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
