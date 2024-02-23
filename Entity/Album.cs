using AppMobileBackEnd.Entity.EntityMoreMore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppMobileBackEnd.Entity
{
    [Table("Album")]
    public class Album
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAlbum { get; set; }

        public string ImageAlbum { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Không được để trống")]
        public string NameAlbum { get; set; }

        public string GenreAlbum { get; set; }

        public List<AlbumMusic> albumMusics { get; set; } = null;

        
    }
}
