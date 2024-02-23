using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppMobileBackEnd.Entity.EntityMoreMore
{
    [Table("AccountFollowArtist")]
    public class AccountFollowArtist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAccountFollowArtist { get; set; }

        public int IdAccount { get; set; }

        public int IdArtist { get; set; }

        public Account Account { get; set; }

        public Artist Artist { get; set; }
    }
}
