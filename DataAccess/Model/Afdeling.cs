using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    internal class Afdeling
    {
        public string Navn { get; set; }
        public int AfdelingNr { get; set; }
        public List<Sag> Sager { get; set; } = new List<Sag>();
        public List<Medarbejder> Medarbejdere { get; set; } = new List<Medarbejder>();

        public Afdeling() { }
        public Afdeling(string navn)
        {
            this.Navn = navn;
        }
       
    }

}

