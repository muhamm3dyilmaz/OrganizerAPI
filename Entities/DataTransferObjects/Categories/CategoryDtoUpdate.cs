using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DataTransferObjects.Categories
{
    public record CategoryDtoUpdate : CategoryDtoManipulation
    {
        [Required(ErrorMessage = "CategoryID required field.")]
        public int CategoryID { get; init; }
    }
}
