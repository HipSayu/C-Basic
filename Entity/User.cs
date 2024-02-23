using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppMobileBackEnd.Entity
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUser { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không được để trống")]
        public string NameUser { get; set; }
        public DateTime BirthOfDate { get; set; }

        public int VIP { get; set; }



    }
}
