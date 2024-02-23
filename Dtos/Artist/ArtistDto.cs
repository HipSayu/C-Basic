using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppMobileBackEnd.Dtos.Artist
{
    public class ArtistDto
    {
        public int IdArtist { get; set; }

        public string NameArtist { get; set; }

        public string ImageArtist { get; set; }

        public string Country { get; set; }
        public int Follower { get; set; } = 0;

        public int Following { get; set; } = 0;
        public bool blueTick { get; set; } = false;

        public string Story { get; set; }

        public DateTime BirthOfDate { get; set; }
    }
}
