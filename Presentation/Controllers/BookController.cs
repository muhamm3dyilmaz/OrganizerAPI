using Entity.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public BookController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            var books = await _manager.BookService.GetAllBooksAsync(false);
            return Ok(books);
        }

        [HttpGet("{bookId:int}")]
        public async Task<IActionResult> GetBookByIdAsync([FromRoute(Name = "bookId")] int bookId)
        {
            var book = await _manager.BookService.GetBookByIdAsync(bookId, false);
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookAsync([FromBody] BookDtoInsertion bookDto)
        {
            var book = await _manager.BookService.CreateBookAsync(bookDto);
            return StatusCode(201, book);
        }

        [HttpPut("{bookId:int}")]
        public async Task<IActionResult> UpdateBookAsync([FromRoute(Name = "bookId")] int bookId, 
            [FromBody] BookDtoUpdate bookDto)
        {
            await _manager.BookService.UpdateBookAsync(bookId, false, bookDto);
            return NoContent();
        }

        [HttpDelete("{bookId:int}")]
        public async Task<IActionResult> DeleteBookAsync([FromRoute(Name = "bookId")] int bookId)
        {
            await _manager.BookService.DeleteBookAsync(bookId, false);
            return NoContent();
        }
    }
}
