using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DataTransferObjects.Authors
{
    public record AuthorDto
    {
        public int AuthorID { get; init; }
        public string? AuthorName { get; init; }
    }
}
