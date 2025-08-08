using System.ComponentModel.DataAnnotations;

namespace ShopMate.Domain.Entities
{
    public class PurchaseHistory : BaseEntity
    {
        public int Quantity { get; set; }
        
        public decimal? Price { get; set; }
        
        public DateTime PurchasedAt { get; set; } = DateTime.UtcNow;
        
        [StringLength(500)]
        public string? Notes { get; set; }
        
        // Foreign keys
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        
        // Navigation properties
        public virtual User User { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
