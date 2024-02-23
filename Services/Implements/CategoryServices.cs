using AppMobileBackEnd.DbContexts;
using AppMobileBackEnd.Dtos.Category;
using AppMobileBackEnd.Dtos.Music;
using AppMobileBackEnd.Entity;
using AppMobileBackEnd.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppMobileBackEnd.Services.Implements
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ApplicationMyDBContext _context;

        public CategoryServices(ApplicationMyDBContext context) 
        {
            _context = context;    
        }
        public void Create(CreateCategoryDto input)
        {
            _context.categories.Add(
                new Category
                {
                    NameCategory = input.NameCategory,
                    
                }
            );
            _context.SaveChanges();
            
        }

        public void Delete(string NameCategory)
        {
            var category = _context.categories.SingleOrDefault(c => c.NameCategory == NameCategory);
            if (category == null)
            {
                throw new NotImplementedException($"Không category có  nào có id {NameCategory}");
            }
            _context.categories.Remove(category);
            _context.SaveChanges();
        }

        public List<CategoryDto> GetAll()
        {
            var category = _context.categories.Select(c => new CategoryDto
            {
                NameCategory = c.NameCategory,
                IdCategory = c.IdCategory
            });
            return category.ToList(); 
        }

        public CategoryDto GetByName(string NameCategory)
        {

            var category = _context.categories.SingleOrDefault(c => c.NameCategory == NameCategory);
            if (category == null)
            {
                throw new NotImplementedException($"Không category có  nào có id {NameCategory}");
            }
            return new CategoryDto
            {
                IdCategory = category.IdCategory,
                NameCategory   = category.NameCategory
            };
        }

        public void Update(UpdateCategoryDto input)
        {
            var category = _context.categories.SingleOrDefault(m => m.IdCategory == input.IdCategory);
            if (category == null)
            {
                throw new NotImplementedException($"Không category có  nào có id {input.IdCategory}");
            }
            category.NameCategory = input.NameCategory;
            _context.SaveChanges();
        }
    }
}
