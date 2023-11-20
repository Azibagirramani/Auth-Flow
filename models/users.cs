using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NgGold.Models
{

    [Table("users")]
    public class Users
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("email")]
        public string? Email { get; set; }

        [Column("reset_token")]
        public string? ResetToken { get; set; }

        [Required]
        [Column("password")]
        public string? Password { get; set; }

        [Column("salt")]
        public string? Salt { get; set; }

        [Column("role")]
        public int Role { get; set; }

        [Column("is_verified")]
        public bool IsVerified { get; set; } = false;

        [Column("createdBy")]
        public Guid? CreatedBy { get; set; }

        [Column("account_status")]
        public int AccountStatus { get; set; } = 0;

        public Business? User_business { get; set; }
    }
}