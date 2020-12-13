using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioEnquete.Models
{
    public class Poll
    {
        public int Id { get; set; }

        [Required]
        [StringLength(700)]
        public string PollDescription { get; set; }

        public List<Option> Options { get; set; }

        public int Views { get; set; }
    }
}
