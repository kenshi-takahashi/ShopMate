using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopMate.Domain.Entities;

namespace ShopMate.Persistence.Data.Configuration
{
    public class PurchaseHistoryConfiguration : IEntityTypeConfiguration<PurchaseHistory>
    {
        public void Configure(EntityTypeBuilder<PurchaseHistory> builder)
        {
            builder.ToTable("PurchaseHistories");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Price)
                .HasPrecision(18, 2);

            builder.Property(p => p.PurchasedAt)
                .IsRequired();

            builder.Property(p => p.Notes)
                .HasMaxLength(500);

            builder.Property(p => p.CreatedAt).IsRequired();
            builder.Property(p => p.UpdatedAt).IsRequired();

            builder.HasIndex(p => new { p.UserId, p.PurchasedAt });

            builder.HasOne(p => p.User)
                .WithMany(u => u.PurchaseHistory)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Product)
                .WithMany(pr => pr.PurchaseHistory)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
