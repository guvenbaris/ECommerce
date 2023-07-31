using ECommerce.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Domain.Entities
{
    [Table("product")]
    public class ProductEntity : BaseEntity
    {
        [Column("product_name")]
        public string ProductName { get; set; } = string.Empty;

        [Column("stock_quantity")]
        public long StockQuantity { get; set; }

        [Column("price")]
        public decimal Price { get; set; }
    }
}
