using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DataTransferObjects.Categories
{
    public abstract record CategoryDtoManipulation
    {
        [Required(ErrorMessage = "CategoryName is required field.")]
        public string? CategoryName { get; init; }
    }
}
