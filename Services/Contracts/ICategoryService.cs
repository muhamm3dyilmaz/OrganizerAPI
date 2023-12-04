using Entity.DataTransferObjects.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(bool trackChanges);
        Task<CategoryDto> GetCategoryByIdAsync(int categoryId, bool trackChanges);
        Task<CategoryDto> CreateCategoryAsync(CategoryDtoInsertion categoryDto);
        Task UpdateCategoryAsync(int categoryId, bool trackChanges, CategoryDtoUpdate categoryDto);
        Task DeleteCategoryAsync(int categoryId, bool trackChanges);
    }
}
