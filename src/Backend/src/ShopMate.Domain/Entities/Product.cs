using System.ComponentModel.DataAnnotations;

namespace ShopMate.Domain.Entities
{
    public class Product : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(1000)]
        public string? Description { get; set; }
        
        [StringLength(100)]
        public string? Brand { get; set; }
        
        [StringLength(50)]
        public string? Unit { get; set; } // kg, units, liters, etc.
        
        public decimal? Price { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        // Foreign key
        public Guid CategoryId { get; set; }
        
        // Navigation properties
        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<ShoppingListItem> ShoppingListItems { get; set; } = new List<ShoppingListItem>();
        public virtual ICollection<PurchaseHistory> PurchaseHistory { get; set; } = new List<PurchaseHistory>();
    }
}
