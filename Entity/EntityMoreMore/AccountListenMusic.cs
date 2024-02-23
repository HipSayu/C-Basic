namespace AppMobileBackEnd.Entity.EntityMoreMore
{
    public class   AccountListenMusic
    {
        public int IdAccountListenMusic { get; set; }

        public int IdAccount {  get; set; }

        public int IdMusic { get; set; }

        public Account account { get; set; }

        public Music music { get; set; }


    }
}
