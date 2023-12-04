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
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoryID);
            builder.HasData
                (
                    new Category { CategoryID = 1, CategoryName = "Roman" },
                    new Category { CategoryID = 2, CategoryName = "Savaş" },
                    new Category { CategoryID = 3, CategoryName = "Hikaye" }
                );
        }
    }
}
