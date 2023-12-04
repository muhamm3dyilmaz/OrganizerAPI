using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IAuthorService _authorService;
        private readonly ICategoryService _categoryService;

        public ServiceManager(IAuthorService authorService, ICategoryService categoryService)
        {
            _authorService = authorService;
            _categoryService = categoryService;
        }

        public IAuthorService AuthorService => _authorService;

        public ICategoryService CategoryService => _categoryService;
    }
}
