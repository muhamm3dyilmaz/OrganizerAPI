using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repository.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateCategoryAsync(Category category) => Create(category);

        public void DeleteCategoryAsync(Category category) => Delete(category);

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public async Task<Category> GetCategoryByIdAsync(int categoryId, bool trackChanges) =>
            await FindByCondition(c => c.CategoryID.Equals(categoryId), trackChanges).SingleOrDefaultAsync();

        public void UpdateCategoryAsync(Category category) => Update(category);
    }
}
