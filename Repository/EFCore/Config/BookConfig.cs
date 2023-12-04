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
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.BookID);
            builder.HasData
                (
                    new Book 
                    { 
                        BookID = 1, 
                        BookName = "Suç ve Ceza", 
                        AuthorID = 1, 
                        CategoryID = 1, 
                        AdressCorridor = 'A', 
                        AdressColumn = 1, 
                        AdressRow = 1 
                    },
                    new Book
                    {
                        BookID = 2,
                        BookName = "Kavgam",
                        AuthorID = 2,
                        CategoryID = 2,
                        AdressCorridor = 'A',
                        AdressColumn = 1,
                        AdressRow = 2
                    },
                    new Book
                    {
                        BookID = 3,
                        BookName = "İnsan Ne İle Yaşar",
                        AuthorID = 3,
                        CategoryID = 3,
                        AdressCorridor = 'A',
                        AdressColumn = 2,
                        AdressRow = 2
                    }
                );
        }
    }
}
