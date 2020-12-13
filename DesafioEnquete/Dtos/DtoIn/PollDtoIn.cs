using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioEnquete.Dtos
{
    public class PollDtoIn
    {        
        [Required]
        [StringLength(700)]
        public string PollDescription { get; set; }

        [Required]
        public List<OptionDtoIn> Options { get; set; }
    }
}
