using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Book
    {
        public int BookID { get; set; }
        public string? BookName { get; set; }
        public string? AuthorID { get; set; }
        public string? ISBN { get; set; }
        public int CategoryID { get; set; }
        public char AdressCorridor { get; set; }
        public int AdressColumn { get; set; }
        public int AdressRow { get; set; }
    }
}
