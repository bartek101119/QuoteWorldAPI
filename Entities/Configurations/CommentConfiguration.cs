using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuoteWorldAPI.Entities.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(t => t.Text)
                .HasMaxLength(500);

            builder.Property(c => c.CreatedAt)
               .HasDefaultValueSql("getutcdate()");
        }
    }
}
