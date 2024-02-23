using AppMobileBackEnd.Dtos.Music;

namespace AppMobileBackEnd.Services.Interfaces
{
    public interface IMusciServices
    {
        List<MusicDto> GetAll();

        List<MusicDto> GetByName(string name);

        MusicDto GetBySingerName(string name);

        void Create(CreateMusicDto input);

        void Update(UpdateMusicDto input);

        void Delete(int IdMusic);

    }
}
