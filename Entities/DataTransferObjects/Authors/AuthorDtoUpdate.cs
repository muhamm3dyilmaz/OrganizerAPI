using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DataTransferObjects.Authors
{
    public record AuthorDtoUpdate : AuthorDtoManipulation
    {
        [Required(ErrorMessage = "AuthorID is required field")]
        public int AuthorID { get; init; }
    }
}
