using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuoteWorldAPI.Entities.Configurations
{
    public class QuoteConfiguration : IEntityTypeConfiguration<Quote>
    {
        public void Configure(EntityTypeBuilder<Quote> builder)
        {
            builder.HasMany(c => c.Comments)
                .WithOne(q => q.Quote)
                .HasForeignKey(c => c.QuoteId);

            builder.HasMany(r => r.Ratings)
                .WithOne(q => q.Quote)
                .HasForeignKey(c => c.QuoteId);

            builder.Property(t => t.Text)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(c => c.CreatedAt)
                .HasDefaultValueSql("getutcdate()");
        }
    }
}
