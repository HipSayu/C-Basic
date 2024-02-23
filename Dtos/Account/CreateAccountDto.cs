namespace AppMobileBackEnd.Dtos.Account
{
    public class CreateAccountDto
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string ImageUser { get; set; }
        public string PhoneNumber { get; set; }

        public string NameUser { get; set; }
        public DateTime BirthOfDate { get; set; }

        public int VIP { get; set; }
    }
}
