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
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateAuthorAsync(Author author) => Create(author);

        public void DeleteAuthorAsync(Author author) =>Delete(author);

        public async Task<Author> GetAuthorByIdAsync(int authorId, bool trackChanges) =>
            await FindByCondition(a => a.AuthorID.Equals(authorId), trackChanges).SingleOrDefaultAsync();

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public void UpdateAuthorAsync(Author author) => Update(author);
    }
}
