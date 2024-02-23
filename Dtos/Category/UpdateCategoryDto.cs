using System.ComponentModel.DataAnnotations;

namespace AppMobileBackEnd.Dtos.Category
{
    public class UpdateCategoryDto : CreateCategoryDto
    {
        public int IdCategory { get; set; }
    }
}
