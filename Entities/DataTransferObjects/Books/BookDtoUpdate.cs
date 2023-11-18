using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DataTransferObjects
{
    public record BookDtoUpdate : BookDtoManipulation
    {
        [Required(ErrorMessage = "BookID is required field.")]
        public int BookID { get; init; }
    }
}
