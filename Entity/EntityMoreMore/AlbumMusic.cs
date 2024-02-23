using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppMobileBackEnd.Entity.EntityMoreMore
{
    [Table("MusicAlbum")]
    public class AlbumMusic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAlbumMusic {  get; set; }

        public int IdAlbum { get; set; }

        public int IdMusic {  get; set; }

        public Music music { get; set; }

        public Album album { get; set; }

    }
}
