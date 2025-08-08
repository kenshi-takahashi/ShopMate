using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopMate.Domain.Entities;

namespace ShopMate.Persistence.Data.Configuration
{
    public class ShoppingListConfiguration : IEntityTypeConfiguration<ShoppingList>
    {
        public void Configure(EntityTypeBuilder<ShoppingList> builder)
        {
            builder.ToTable("ShoppingLists");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(l => l.Description)
                .HasMaxLength(1000);

            builder.Property(l => l.IsCompleted)
                .HasDefaultValue(false);

            builder.Property(l => l.CreatedAt).IsRequired();
            builder.Property(l => l.UpdatedAt).IsRequired();

            builder.HasIndex(l => l.OwnerId);

            builder.HasOne(l => l.Owner)
                .WithMany(u => u.ShoppingLists)
                .HasForeignKey(l => l.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Many-to-many для SharedUsers настраивается зеркально в UserConfiguration
            builder.HasMany(l => l.SharedUsers)
                .WithMany(u => u.SharedShoppingLists)
                .UsingEntity<Dictionary<string, object>>(
                    "ShoppingListUser",
                    j => j
                        .HasOne<User>()
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<ShoppingList>()
                        .WithMany()
                        .HasForeignKey("ShoppingListId")
                        .OnDelete(DeleteBehavior.Cascade))
                .ToTable("ShoppingListUsers");
        }
    }
}
