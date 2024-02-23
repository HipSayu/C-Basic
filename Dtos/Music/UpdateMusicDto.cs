using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppMobileBackEnd.Dtos.Music
{
    public class UpdateMusicDto : CreateMusicDto
    {
        public int IdMusic { get; set; }
    }
}
