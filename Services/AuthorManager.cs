using AutoMapper;
using Entity.DataTransferObjects.Authors;
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
    public class AuthorManager : IAuthorService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public AuthorManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<AuthorDto> CreateAutorAsync(AuthorDtoInsertion authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            _manager.AuthorRepo.CreateAuthorAsync(author);
            await _manager.SaveAsync();
            return _mapper.Map<AuthorDto>(author);
        }

        public async Task DeleteAuthorAsync(int authorId, bool trackChanges)
        {
            var author = await GetIdAndCheckExists(authorId, trackChanges);
            _manager.AuthorRepo.DeleteAuthorAsync(author);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync(bool trackChanges)
        {
            var authors = await _manager.AuthorRepo.GetAllAuthorsAsync(trackChanges);
            return _mapper.Map<IEnumerable<AuthorDto>>(authors);
        }

        public async Task<AuthorDto> GetAuthorByIdAsync(int authorId, bool trackChanges)
        {
            var author = await GetIdAndCheckExists(authorId, trackChanges);
            return _mapper.Map<AuthorDto>(author);
        }

        public async Task UpdateAuthorAsync(int authorId, bool trackChanges, AuthorDtoUpdate authorDto)
        {
            var author = await GetIdAndCheckExists(authorId, trackChanges);
            author = _mapper.Map<Author>(authorDto);
            _manager.AuthorRepo.UpdateAuthorAsync(author);
            await _manager.SaveAsync();
        }

        private async Task<Author> GetIdAndCheckExists(int authorId, bool trackChanges)
        {
            var entity = await _manager.AuthorRepo.GetAuthorByIdAsync(authorId, trackChanges);

            if(entity is null)
            {
                throw new Exception($"Author Not Found With {authorId} ID Number!");
            }

            return entity;
        }
    }
}
