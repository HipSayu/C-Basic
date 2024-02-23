using System.ComponentModel.DataAnnotations.Schema;

namespace AppMobileBackEnd.Entity.EntityMoreMore
{
    [Table("CategoryMusic")]
    public class CategoryMusic
    {
        public int IdCategoryMusic { get; set; }

        public int IdCategory {  get; set; }

        public int IdMusic { get; set; }

        public Category category { get; set; }

        public Music music { get; set; }
    }
}
