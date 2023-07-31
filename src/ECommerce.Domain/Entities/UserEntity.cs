using ECommerce.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Domain.Entities
{
    [Table("user")]
    public class UserEntity : BaseEntity
    {
        [Column("username")]
        public string Username { get; set; } = string.Empty;

        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Column("balance")]
        public decimal Balance { get; set; }
    }
}
