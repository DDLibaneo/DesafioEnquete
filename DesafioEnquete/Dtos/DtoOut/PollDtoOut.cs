using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioEnquete.Dtos.DtoOut
{
    public class PollDtoOut
    {
        public int Id { get; set; }

        public string PollDescription { get; set; }

        public List<OptionDtoOut> Options { get; set; }
    }
}
