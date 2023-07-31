using ECommerce.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Domain.Entities
{
    [Table("order")]
    public class OrderEntity : BaseEntity
    {
        [Column("user_id")]
        public Guid UserId { get; set; }

        [Column("product_id")]
        public Guid ProductId { get; set; }

        [Column("is_approved")]
        public bool IsApproved { get; set; } = false;

        [ForeignKey("UserId")]
        public UserEntity? User { get; set; } = null;

        [ForeignKey("ProductId")]
        public ProductEntity? Product { get; set; } = null;
    }
}
