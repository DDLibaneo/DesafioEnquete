using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioEnquete.Models
{
    public class Option
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string OptionDescription { get; set; }

        public int Votes { get; set; }
        
        [Required]
        public int PollId { get; set; }

        public Poll Poll { get; set; }
    }
}
