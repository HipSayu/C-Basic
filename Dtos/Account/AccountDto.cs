using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppMobileBackEnd.Dtos.Account
{
    public class AccountDto
    {
        public int IdAccount { get; set; }
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
