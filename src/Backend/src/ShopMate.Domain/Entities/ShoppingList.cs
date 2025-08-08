using System.ComponentModel.DataAnnotations;

namespace ShopMate.Domain.Entities
{
    public class ShoppingList : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(1000)]
        public string? Description { get; set; }
        
        public bool IsCompleted { get; set; } = false;
        
        public DateTime? CompletedAt { get; set; }
        
        // Foreign key for owner
        public Guid OwnerId { get; set; }
        
        // Navigation properties
        public virtual User Owner { get; set; } = null!;
        public virtual ICollection<User> SharedUsers { get; set; } = new List<User>();
        public virtual ICollection<ShoppingListItem> Items { get; set; } = new List<ShoppingListItem>();
    }
}
