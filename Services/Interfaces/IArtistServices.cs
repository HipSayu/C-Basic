using AppMobileBackEnd.Dtos.Artist;

namespace AppMobileBackEnd.Services.Interfaces
{
    public interface IArtistServices
    {
        List<ArtistDto> GetAll();
        ArtistDto GetByName (string name);

        void Create(CreateArtistDto input);

        void Update (UpdateArtistDto input);

        void Delete(int IdArtist);
    }
}
