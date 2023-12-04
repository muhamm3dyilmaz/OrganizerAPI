using AutoMapper;
using Entity.DataTransferObjects.Categories;
using Entity.Model;
using Repository.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public CategoryManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryDtoInsertion categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            _manager.CategoryRepo.CreateCategoryAsync(category);
            await _manager.SaveAsync();
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task DeleteCategoryAsync(int categoryId, bool trackChanges)
        {
            var category = await GetCategoryByIdAndCheckExists(categoryId, trackChanges);
            _manager.CategoryRepo.DeleteCategoryAsync(category);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(bool trackChanges)
        {
            var categories = await _manager.CategoryRepo.GetAllCategoriesAsync(trackChanges);
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int categoryId, bool trackChanges)
        {
            var category = await GetCategoryByIdAndCheckExists(categoryId, trackChanges);
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task UpdateCategoryAsync(int categoryId, bool trackChanges, CategoryDtoUpdate categoryDto)
        {
            var category = await GetCategoryByIdAndCheckExists(categoryId, trackChanges);
            category = _mapper.Map<Category>(category);
            _manager.CategoryRepo.UpdateCategoryAsync(category);
            await _manager.SaveAsync();
        }

        private async Task<Category> GetCategoryByIdAndCheckExists(int categoryId, bool trackChanges)
        {
            var category = await _manager.CategoryRepo.GetCategoryByIdAsync(categoryId, trackChanges);

            if (category is null)
            {
                throw new Exception($"Category Not Found With {categoryId} ID Number!");
            }

            return category;
        }
    }
}
