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
        private readonly IBookService _bookService;

        public ServiceManager(IAuthorService authorService, ICategoryService categoryService, IBookService bookService)
        {
            _authorService = authorService;
            _categoryService = categoryService;
            _bookService = bookService;
        }

        public IAuthorService AuthorService => _authorService;

        public ICategoryService CategoryService => _categoryService;

        public IBookService BookService => _bookService;
    }
}
