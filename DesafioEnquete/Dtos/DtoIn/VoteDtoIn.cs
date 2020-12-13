using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioEnquete.Dtos.DtoIn
{
    public class VoteDtoIn
    {
        [Required]
        public int OptionId { get; set; }
    }
}
