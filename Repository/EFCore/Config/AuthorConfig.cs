using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Config
{
    public class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.AuthorID);
            builder.HasData
                (
                    new Author { AuthorID = 1, AuthorName = "Fyodor Dostoyevski" },
                    new Author { AuthorID = 2, AuthorName = "Adolf Hitler" },
                    new Author { AuthorID = 3, AuthorName = "Lev Tolstoy" }
                );
        }
    }
}
