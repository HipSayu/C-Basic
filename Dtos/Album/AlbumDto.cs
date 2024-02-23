using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppMobileBackEnd.Dtos.Album
{
    public class AlbumDto
    {
        public int IdAlbum { get; set; }

        public string ImageAlbum { get; set; }

        public string GenreAlbum { get; set; }

        public string NameAlbum { get; set; }
    }
}
