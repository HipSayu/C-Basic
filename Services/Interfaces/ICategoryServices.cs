using AppMobileBackEnd.Dtos.Category;

namespace AppMobileBackEnd.Services.Interfaces
{
    public interface ICategoryServices
    {
        List<CategoryDto> GetAll();

        CategoryDto GetByName (string NameCategory);
        void Create(CreateCategoryDto input);

        void Update(UpdateCategoryDto input);

        void Delete(string NameCategory);
    }
}
