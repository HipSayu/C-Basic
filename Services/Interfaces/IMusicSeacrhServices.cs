using AppMobileBackEnd.Dtos.Music;
using AppMobileBackEnd.Entity;
using static AppMobileBackEnd.Entity.Music;

namespace AppMobileBackEnd.Services.Interfaces
{
    public interface IMusicSeacrhServices
    {

        List<SearchMusicDto> GetAllByNameArtist(string NameArtist);

        List<SearchMusicDto> GetAllByCagetory(string NameCagetory);

        List<SearchMusicDto> SearchByArtist(string NameArtist, int? from, int? to, int page);



    }
}
