using AppMobileBackEnd.Entity.EntityMoreMore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppMobileBackEnd.Entity
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int IdCategory { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Không được để trống")]
        public string NameCategory { get; set; }

        public List<CategoryMusic> categoryMusics { get; set; } = null ;

       
    }
}
