using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DataTransferObjects.Authors
{
    public abstract record AuthorDtoManipulation
    {
        [Required(ErrorMessage = "AuthorName field is required.")]
        public string? AuthorName { get; set; }
    }
}
