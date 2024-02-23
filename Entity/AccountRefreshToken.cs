using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppMobileBackEnd.Entity
{
    [Table("AccountRefreshToken")]
    public class AccountRefreshToken
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdAccount { get; set; }
        [ForeignKey(nameof(IdAccount))]
        public Account account { get; set; }

        public string Token { get; set; }
        public string JwtId { get; set; }

        public bool IsUsed { get; set; }

        public bool IsRevoked { get; set; }

        public DateTime IssuedAt { get; set; }

        public DateTime ExpiredAt { get; set; }
    }
}
