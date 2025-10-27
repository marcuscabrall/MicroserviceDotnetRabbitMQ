using SalesAndInventorySystem.InventoryAPI.Model.Base;
using SalesAndInventorySystem.InventoryAPI.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace SalesAndInventorySystem.InventoryAPI.Model
{
    [Table("inventory")]
    public class Product : BaseEntity
    {
        [Column("product_name")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Column("description")]
        [StringLength(500)]
        public string Description { get; set; }

        [Column("price")]
        [Required]
        [Range(1, 10000)]
        public decimal Price { get; set; }

        [Column("quantity")]
        [Required]
        public int QuantityInInventory { get; set; }

        [Column("product_status")]
        [Required]
        public StatusType Status { get; set; } = StatusType.Available; // Disponível por padrão

        [Column("created_at")]
        [Required]
        public DateTimeOffset CreatedAt { get; private set; } = DateTimeOffset.UtcNow; // Preservando o fuso
    }
}
