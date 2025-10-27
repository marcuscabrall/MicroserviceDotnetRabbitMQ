using SalesAndInventorySystem.InventoryAPI.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesAndInventorySystem.InventoryAPI.Data.ValueObjects
{
    public class ProductVO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityInInventory { get; set; }
        public StatusType Status { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
