using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    internal class Sag
    {
        public int SagsId { get; set; }
        public string Overskrift { get; set; }
        public string Beskrivelse { get; set; }
        public Afdeling Afdeling { get; set; }
        // Foreign key
        public int AfdelingNr { get; set; } 

        public Sag() { }
        public Sag( string overskrift, string beskrivelse, int afdelingNr)
        {
            this.Overskrift = overskrift;
            this.Beskrivelse = beskrivelse;
            this.AfdelingNr = afdelingNr;
        }
       
    }
}
