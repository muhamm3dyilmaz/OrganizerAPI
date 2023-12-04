using Entity.DataTransferObjects.Authors;
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
    [Route("api/authors")]
    public class AuthorController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public AuthorController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthorsAsync()
        {
            var authors = await _manager.AuthorService.GetAllAuthorsAsync(false);
            return Ok(authors); //400
        }

        [HttpGet("{authorId:int}")]
        public async Task<IActionResult> GetAuthorById([FromRoute(Name = "authorId")] int authorId)
        {
            var author = await _manager.AuthorService.GetAuthorByIdAsync(authorId, false);
            return Ok(author); //400
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthorAsync([FromBody] AuthorDtoInsertion authorDto)
        {
            var author = await _manager.AuthorService.CreateAutorAsync(authorDto);
            return StatusCode(201, author); //201
        }

        [HttpPut("{authorId:int}")]
        public async Task<IActionResult> UpdateAuthorAsync([FromRoute(Name = "authorId")] int authorId, 
            [FromBody] AuthorDtoUpdate authorDto)
        {
            await _manager.AuthorService.UpdateAuthorAsync(authorId, false, authorDto);
            return NoContent(); //204

        }

        [HttpDelete("{authorId:int}")]
        public async Task<IActionResult> DeleteAuthorAsync([FromRoute(Name = "authorId")] int authorId)
        {
            await _manager.AuthorService.DeleteAuthorAsync(authorId, false);
            return NoContent(); //204
        }
    }
}
