using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppMobileBackEnd.Dtos.Music
{
    public class CreateMusicDto
    {
        public string NameMusic { get; set; }

        public string LyrcsMusic { get; set; }

        public string DataMusic { get; set; }

        public string DesriptionMusic { get; set; }

        public int NumberLike { get; set; } = 0;

        public string ImageMusic { get; set; }
    }
}
