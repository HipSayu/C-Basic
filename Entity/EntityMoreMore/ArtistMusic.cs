using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppMobileBackEnd.Entity.EntityMoreMore
{
    [Table("ArtistMusic")]
    public class ArtistMusic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdArtistMusic { get; set; }

        public int IdArtist { get; set; }

        public int IdMusic { get; set; }

        public Music music { get; set; }

        public Artist artist { get; set; }


    }
}
