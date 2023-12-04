using Entity.Model;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IAuthorRepository : IRepositoryBase<Author>
    {
        Task<IEnumerable<Author>> GetAllAuthorsAsync(bool trackChanges);
        Task<Author> GetAuthorByIdAsync(int authorId, bool trackChanges);
        void CreateAuthorAsync(Author author);
        void UpdateAuthorAsync(Author author);
        void DeleteAuthorAsync(Author author);
    }
}
