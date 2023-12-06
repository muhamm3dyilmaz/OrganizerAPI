using Entity.Model;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        Task<IEnumerable<Book>> GetAllBooksAsync(bool trackChanges);
        Task<Book> GetBookById(int bookId, bool trackChanges);
        void CreateBookAsync(Book book);
        void UpdateBookAsync(Book book);
        void DeleteBookAsync(Book book); 
    }
}
