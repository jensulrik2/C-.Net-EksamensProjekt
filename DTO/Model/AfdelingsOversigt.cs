using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class AfdelingsOversigt
    {
        public List<AfdelingsInfo> Afdelinger { get; set; }

        public AfdelingsOversigt()
        {
            Afdelinger = new List<AfdelingsInfo>();
        }

        public AfdelingsOversigt(List<AfdelingsInfo> afdelinger)
        {
            Afdelinger = afdelinger;
        }
    }
}