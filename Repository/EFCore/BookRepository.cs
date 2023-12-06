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
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateBookAsync(Book book) => Create(book);

        public void DeleteBookAsync(Book book) => Delete(book);

        public async Task<IEnumerable<Book>> GetAllBooksAsync(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public async Task<Book> GetBookById(int bookId, bool trackChanges) =>
            await FindByCondition(b => b.BookID.Equals(bookId), trackChanges).SingleOrDefaultAsync();

        public void UpdateBookAsync(Book book) => Update(book);
    }
}
