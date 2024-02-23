using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppMobileBackEnd.Entity
{
    [Table("SearchHistory")]
    public class SearchHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSearchHistory {  get; set; }

        public int IdAccount {  get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Không được để trống")]
        public string Search {  get; set; }

        public DateTime TimeSearch {  get; set; }

        public Account account { get; set; }
    }
}
