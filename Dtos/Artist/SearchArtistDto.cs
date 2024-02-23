namespace AppMobileBackEnd.Dtos.Artist
{
    public class SearchArtistDto
    {
        public string NameArtist { get; set; }

        public string ImageArtist { get; set; }

        public string Country { get; set; }
        public int Follower { get; set; } = 0;

        public int Following { get; set; } = 0;
        public bool blueTick { get; set; } = false;

        public string Story { get; set; }

        public DateTime BirthOfDate { get; set; }
    }
}
