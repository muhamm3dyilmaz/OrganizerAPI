using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DataTransferObjects
{
    public abstract record BookDtoManipulation
    {
        [Required(ErrorMessage = "BookName is required field.")]
        public string? BookName { get; init; }

        [Required(ErrorMessage = "AuthorID is required field.")]
        public string? AuthorID { get; init; }

        [Required(ErrorMessage = "ISBN is required field")]
        [StringLength(13, ErrorMessage = "ISBN must be 13 digits.")]
        public string? ISBN { get; init; }

        [Required(ErrorMessage = "CategoryID is required field.")]
        public int CategoryID { get; init; }

        [Required(ErrorMessage = "AdressCorridor is required field. Letter must be entered.")]
        public char AdressCorridor { get; init; }

        [Required(ErrorMessage = "AdressColumn is required field.")]
        public int AdressColumn { get; init; }

        [Required(ErrorMessage = "AdressRow is required field.")]
        public int AdressRow { get; init; }
    }
}
