using AppMobileBackEnd.DbContexts;
using AppMobileBackEnd.Dtos.Artist;
using AppMobileBackEnd.Dtos.Category;
using AppMobileBackEnd.Entity;
using AppMobileBackEnd.Services.Interfaces;

namespace AppMobileBackEnd.Services.Implements
{
    public class ArtistServices : IArtistServices
    {
        private readonly ApplicationMyDBContext _context;

        public ArtistServices(ApplicationMyDBContext context)
        {
            _context = context;
        }

        public void Create(CreateArtistDto input)
        {
            _context.artists.Add(
                new Artist
                {
                    NameArtist = input.NameArtist,
                    BirthOfDate = input.BirthOfDate,
                    ImageArtist = input.ImageArtist,
                    Story = input.Story,
                    blueTick = input.blueTick,
                    Country = input.Country,
                }
            );
            _context.SaveChanges();
        }

        public void Delete(int IdArtist)
        {
            var artist = _context.artists.SingleOrDefault(a => a.IdArtist == IdArtist);
            if (artist == null)
            {
                throw new NotImplementedException($"Không Artist có  nào có id {IdArtist}");
            }
            _context.artists.Remove(artist);
            _context.SaveChanges();
        }

        public List<ArtistDto> GetAll()
        {
            var Artist = _context.artists.Select(a => new ArtistDto
            {
                IdArtist = a.IdArtist,
                NameArtist = a.NameArtist,
                BirthOfDate = a.BirthOfDate,
                ImageArtist = a.ImageArtist,
                Story = a.Story,
                blueTick = a.blueTick,
            });
            return Artist.ToList();
        }

        public ArtistDto GetByName(string name)
        {
            var artist = _context.artists.SingleOrDefault(a => a.NameArtist == name);
            if (artist == null)
            {
                throw new NotImplementedException($"Không Artist có  nào có id {name}");
            }
            return new ArtistDto
            {
                NameArtist = artist.NameArtist,
                BirthOfDate = artist.BirthOfDate,
                ImageArtist = artist.ImageArtist,
                Story = artist.Story,
                blueTick = artist.blueTick,
            };
        }

        public void Update(UpdateArtistDto input)
        {
            var artist = _context.artists.SingleOrDefault(a => a.IdArtist == input.IdArtist);
            if (artist == null)
            {
                throw new NotImplementedException($"Không category có  nào có id {input.IdArtist}");
            }
            artist.NameArtist = input.NameArtist;
            artist.BirthOfDate = input.BirthOfDate;
            artist.ImageArtist = input.ImageArtist;
            artist.Story = input.Story;
            artist.blueTick = input.blueTick;
            _context.SaveChanges();
        }
    }
}
