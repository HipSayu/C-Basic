using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AppMobileBackEnd.Entity.EntityMoreMore;

namespace AppMobileBackEnd.Entity
{
    [Table("Artist")]
    public class Artist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdArtist { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Không được để trống")]
        [MaxLength(255, ErrorMessage = "Tên không quá 255 ký tự")]
        public string NameArtist { get; set; }

        public string ImageArtist { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Không được để trống")]
        [MaxLength(100, ErrorMessage = "quốc tịch không quá 100 ký tự")]
        public string Country { get; set; }
        public int Follower { get; set; } = 0;

        public int Following { get; set; } = 0;
        public bool blueTick { get; set; } = false;

        public string Story { get; set; }

        public DateTime BirthOfDate { get; set; }

        public List<AccountFollowArtist> accountFollowArtists { get; set; } = null;

        public List<ArtistMusic> artistMusics { get; set; } = null;


    }
        
}
