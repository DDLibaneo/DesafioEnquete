using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioEnquete.Dtos.DtoOut
{
    public class StatsDtoOut
    {
        public int Views { get; set; }

        public IEnumerable<OptionVoteDtoOut> Options { get; set; }
    }
}
