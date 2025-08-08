using System.ComponentModel.DataAnnotations;

namespace ShopMate.Domain.Entities
{
    public class User : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Username { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        [StringLength(255)]
        public string PasswordHash { get; set; } = string.Empty;
        
        [StringLength(100)]
        public string? FirstName { get; set; }
        
        [StringLength(100)]
        public string? LastName { get; set; }
        
        public DateTime? LastLoginAt { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        // Navigation properties
        public virtual ICollection<ShoppingList> ShoppingLists { get; set; } = new List<ShoppingList>();
        public virtual ICollection<ShoppingList> SharedShoppingLists { get; set; } = new List<ShoppingList>();
        public virtual ICollection<PurchaseHistory> PurchaseHistory { get; set; } = new List<PurchaseHistory>();
    }
}
