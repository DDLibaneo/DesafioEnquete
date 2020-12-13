using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioEnquete.Dtos
{
    public class OptionDtoIn
    {
        [Required]
        [StringLength(500)]
        public string OptionDescription { get; set; }
    }
}
