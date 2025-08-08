using System.ComponentModel.DataAnnotations;

namespace ShopMate.Domain.Entities
{
    public class ShoppingListItem : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        
        public int Quantity { get; set; } = 1;
        
        [StringLength(50)]
        public string? Unit { get; set; }
        
        public bool IsCompleted { get; set; } = false;
        
        public decimal? Price { get; set; }
        
        public string? Notes { get; set; }
        
        public DateTime? CompletedAt { get; set; }
        
        // Foreign keys
        public Guid ShoppingListId { get; set; }
        public Guid? ProductId { get; set; }
        
        // Navigation properties
        public virtual ShoppingList ShoppingList { get; set; } = null!;
        public virtual Product? Product { get; set; }
    }
}
