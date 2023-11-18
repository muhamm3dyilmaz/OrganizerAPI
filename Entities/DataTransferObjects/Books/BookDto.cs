using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DataTransferObjects
{
    public record BookDto
    {
        public int BookID { get; init; }
        public string? BookName { get; init; }
        public string? AuthorID { get; init; }
        public string? ISBN { get; init; }
        public int CategoryID { get; init; }
        public char AdressCorridor { get; init; }
        public int AdressColumn { get; init; }
        public int AdressRow { get; init; }
    }
}
