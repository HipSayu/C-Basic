namespace AppMobileBackEnd.Dtos.Music
{
    public class SearchMusicDto
    {
        public string NameMusic { get; set; }

        public string LyrcsMusic { get; set; }

        public string DataMusic { get; set; }

        public string DesriptionMusic { get; set; }

        public int NumberLike { get; set; } = 0;

        public string ImageMusic { get; set; }
        public string[] Artists {  get; set; }
        public string[] Cagetory { get; set; }
    }
}
