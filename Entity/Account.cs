using AppMobileBackEnd.Entity.EntityMoreMore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppMobileBackEnd.Entity
{
    [Table("Account")]
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAccount { get; set; }

        private string _username;

        [Required(AllowEmptyStrings = false, ErrorMessage = "Tài khoản không được bỏ trống")]
        [MaxLength(50, ErrorMessage = "Tài khoản dài tối đa 50 ký tự")]
        [MinLength(3, ErrorMessage = "Tài khoản dài tối thiểu 3 ký tự")]
        public string Username
        {
            get => _username;
            set => _username = value?.Trim();
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Mật khẩu không được bỏ trống")]
        [MinLength(8, ErrorMessage = "Mật khẩu dài tối thiểu 8 ký tự")]
        private string _password { get; set; }
        public string Password
        {
            get => _password;
            set => _password = value?.Trim();
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email không được bỏ trống")]
        [RegularExpression(
            "^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$",
            ErrorMessage = "Email định dạng không hợp lệ"
        )]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "PhoneNumber không được bỏ trống")]
        [RegularExpression(
            "/\\(?([0 - 9]{3})\\)? ([ .-]?) ([0 - 9]{3})\\2([0 - 9]{ 4})/",
            ErrorMessage = "Email định dạng không hợp lệ"
        )]
        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Không được để trống")]
        public string NameUser { get; set; }

        public DateTime BirthOfDate { get; set; }
        public string ImageUser { get; set; }
        public int VIP { get; set; }

        public ICollection<AccountFollowArtist> accountFollowArtists { get; set; }
        public ICollection<AccountListenMusic> accountListenMusics { get; set; }

        public ICollection<SearchHistory> searchHistorys { get; set; }


        public Account ()
        {
            accountFollowArtists = new List<AccountFollowArtist> ();
            searchHistorys = new List <SearchHistory> ();
            accountListenMusics = new List<AccountListenMusic> ();  
        }
    }
}
