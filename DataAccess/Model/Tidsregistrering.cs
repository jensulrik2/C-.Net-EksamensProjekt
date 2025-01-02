using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    internal class Tidsregistrering
    {
        public int TidsregistreringId { get; set; }
        public DateTime Start { get; set; }
        public DateTime Slut { get; set; }
        public Sag Sag { get; set; }
        public Medarbejder Medarbejder { get; set; }
        public int MedarbejderId { get; set; }
        public int SagsId { get; set; }


        public Tidsregistrering() { }
        public Tidsregistrering(int medarbejderId, DateTime start, DateTime slut)
        {
            this.MedarbejderId = medarbejderId;
            this.Start = start;
            this.Start = slut;
        }
        public Tidsregistrering(int medarbejderId, int sagsId, DateTime start, DateTime slut)
        {
            this.MedarbejderId = medarbejderId;
            this.SagsId = sagsId;
            this.Start = start;
            this.Slut = slut;
            
        }
    }
}
