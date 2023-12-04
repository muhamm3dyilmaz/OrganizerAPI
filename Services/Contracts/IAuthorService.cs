using Entity.DataTransferObjects.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IAuthorService 
    {
        Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync(bool trackChanges);
        Task<AuthorDto> GetAuthorByIdAsync(int authorId, bool trackChanges);
        Task<AuthorDto> CreateAutorAsync(AuthorDtoInsertion authorDto);
        Task UpdateAuthorAsync(int authorId, bool trackChanges, AuthorDtoUpdate authorDto);
        Task DeleteAuthorAsync(int authorId, bool trackChanges);
    }
}
