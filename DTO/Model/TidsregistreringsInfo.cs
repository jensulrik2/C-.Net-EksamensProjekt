using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class TidsregistreringsInfo
    {

        public int TidsregistreringId { get; set; }
        public DateTime Start { get; set; }
        public DateTime Slut { get; set; }
        public SagsInfo Sag { get; set; }
        public int SagsId { get; set; }
        public int MedarbejderId { get; set; }
        public double TotalHours { get; set; }
        
        public TidsregistreringsInfo(){}
        public TidsregistreringsInfo(int medarbejderId,int sagsId, DateTime start, DateTime slut)
        {
            this.MedarbejderId = medarbejderId;
            this.SagsId = sagsId;
            this.Start = start;
            this.Slut = slut;
   
        }

        // Constructor with Sag
        public TidsregistreringsInfo(int tidsregistreringId, int medarbejderId, int sagsId, DateTime start, DateTime slut)
        {
            this.TidsregistreringId = tidsregistreringId;
            this.MedarbejderId= medarbejderId;
            this.SagsId = sagsId;
            this.Start = start;
            this.Slut = slut;
            
        }


    }
}
