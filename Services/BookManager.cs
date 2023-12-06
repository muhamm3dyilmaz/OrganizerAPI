using AutoMapper;
using Entity.DataTransferObjects;
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
    public class BookManager : IBookService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public BookManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<BookDto> CreateBookAsync(BookDtoInsertion bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            _manager.BookRepo.CreateBookAsync(book);
            await _manager.SaveAsync();
            return _mapper.Map<BookDto>(book);
        }

        public async Task DeleteBookAsync(int bookId, bool trackChanges)
        {
            var book = await GetBookByIdAndCheckExists(bookId, trackChanges);
            _manager.BookRepo.DeleteBookAsync(book);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync(bool trackChanges)
        {
            var books = await _manager.BookRepo.GetAllBooksAsync(trackChanges);
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<BookDto> GetBookByIdAsync(int bookId, bool trackChanges)
        {
            var book = await GetBookByIdAndCheckExists(bookId, trackChanges);
            return _mapper.Map<BookDto>(book);
        }

        public async Task UpdateBookAsync(int bookId, bool trackChanges, BookDtoUpdate bookDto)
        {
            var book = await GetBookByIdAndCheckExists(bookId, trackChanges);
            book = _mapper.Map<Book>(bookDto);
            _manager.BookRepo.UpdateBookAsync(book);
            await _manager.SaveAsync();
        }

        private async Task<Book> GetBookByIdAndCheckExists(int bookId, bool trackChanges)
        {
            var book = await _manager.BookRepo.GetBookById(bookId, trackChanges);
            
            if(book is null)
            {
                throw new Exception($"Book Not Found With {bookId} ID Number!");
            }

            return book;
        }
    }
}
