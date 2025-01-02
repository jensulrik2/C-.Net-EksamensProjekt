using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class AfdelingsInfo
    {
        public int AfdelingNr { get; set; }
        public string Navn { get; set; }
        public List<Medarbejder> Medarbejdere { get; set; } = new List<Medarbejder>();
        public List<SagsInfo> Sager { get; set; } = new List<SagsInfo>();
        
        public AfdelingsInfo() { }
        public AfdelingsInfo(String navn)
        {
            this.Navn = navn;
         
        }

        public AfdelingsInfo(int AfdelingNr, String navn)
        {
            this.AfdelingNr = AfdelingNr;
            this.Navn = navn;
          
        }

    }
}
