namespace AppMobileBackEnd.Dtos.Artist
{
    public class CreateArtistDto
    {
        public string NameArtist { get; set; }

        public string ImageArtist { get; set; }

        public string Country { get; set; }
       
        public bool blueTick { get; set; } = false;

        public string Story { get; set; }

        public DateTime BirthOfDate { get; set; }
    }
}
