using Repositories.Contracts;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IAuthorRepository _authorRepository;
        private readonly ICategoryRepository _categoryRepository;

        public RepositoryManager(RepositoryContext context, IAuthorRepository authorRepository, 
            ICategoryRepository categoryRepository)
        {
            _context = context;
            _authorRepository = authorRepository;
            _categoryRepository = categoryRepository;
        }

        public IAuthorRepository AuthorRepo => _authorRepository;

        public ICategoryRepository CategoryRepo => _categoryRepository;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
