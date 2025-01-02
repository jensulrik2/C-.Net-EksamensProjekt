using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    internal class Medarbejder
    {
        public int MedarbejderId { get; set; }
        public string Initialer { get; set; }   
        public string Cpr { get; set; }
        public string Navn { get; set; }
        public List<Tidsregistrering> Tidsregistreringer { get; set; }
        public List<Afdeling> Afdelinger { get; set; }

        public Medarbejder() { }
        public Medarbejder( string initialer, string cpr, string navn)
        {
            this.Initialer = initialer;
            this.Cpr = cpr;
            this.Navn = navn;
            this.Tidsregistreringer = new List<Tidsregistrering>();
            this.Afdelinger = new List<Afdeling>();
        }
        public Medarbejder(int medarbejderId, string initialer, string cpr, string navn)
        {
            this.MedarbejderId = medarbejderId;
            this.Initialer = initialer;
            this.Cpr = cpr;
            this.Navn = navn;
            this.Tidsregistreringer = new List<Tidsregistrering>();
            this.Afdelinger = new List<Afdeling>();
        }
    }
}
