using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DataTransferObjects.Categories
{
    public record CategoryDto
    {
        public int CategoryID { get; init; }
        public string? CategoryName { get; init; }
    }
}
