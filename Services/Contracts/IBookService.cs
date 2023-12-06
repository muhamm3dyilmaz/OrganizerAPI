using Entity.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBooksAsync(bool trackChanges);
        Task<BookDto> GetBookByIdAsync(int bookId, bool trackChanges);
        Task<BookDto> CreateBookAsync(BookDtoInsertion bookDto);
        Task UpdateBookAsync(int bookId, bool trackChanges ,BookDtoUpdate bookDto);
        Task DeleteBookAsync(int bookId, bool trackChanges);
    }
}
