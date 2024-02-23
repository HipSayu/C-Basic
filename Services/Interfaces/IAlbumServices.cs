using AppMobileBackEnd.Dtos.Album;

namespace AppMobileBackEnd.Services.Interfaces
{
    public interface IAlbumServices
    {
        List<AlbumDto> GetAll ();

        AlbumDto GetAlbum(string NameAlbum);

        void Create(CreateAlbumDto input);

        void Update(UpdateAlbumDto input);

        void Delete(UpdateAlbumDto input);    
    }
}
