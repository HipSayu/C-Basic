using AppMobileBackEnd.Entity.EntityMoreMore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppMobileBackEnd.Entity
{
    [Table("Music")]
    public class Music
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMusic { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Không được để trống")]
        [MaxLength(100, ErrorMessage ="Tên bài hát không quá 100 ký tự")]
        public string NameMusic { get; set; }

        public string LyrcsMusic { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Không được để trống")]
        public string DataMusic { get; set; }

        public string DesriptionMusic { get; set; }

        public int NumberLike { get; set; } = 0;

        public string ImageMusic { get; set; }

        public List<AccountListenMusic> accountListenMusics { get; set; } = null;

        public List<ArtistMusic> artistMusics { get; set; } = null;

        public List<AlbumMusic> albumMusics { get; set; } = null;

        public List<CategoryMusic> categoryMusics { get; set; } = null;
        


        public class MusicVM : Music
        {
            public string Cagetory { get; set; }
        }

        public class MusicArtis  : Music
        {
            public Artist artists { get; set; }
        }
    }
}
