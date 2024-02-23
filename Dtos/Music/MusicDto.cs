using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppMobileBackEnd.Dtos.Music
{
    public class MusicDto
    {
        public int IdMusic { get; set; }

        public string NameMusic { get; set; }

        public string LyrcsMusic { get; set; }

        public string DataMusic { get; set; }

        public string DesriptionMusic { get; set; }

        public int NumberLike { get; set; } = 0;

        public string ImageMusic { get; set; }
    }
}
