using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Model;
using DataAccess.Model;


namespace DataAccess.Mappers
{
    internal class TidsregistreringMapper
    {
        public static DTO.Model.TidsregistreringsInfo Map(Tidsregistrering tidsregistrering)
        {
            if (tidsregistrering.Sag == null)
            {
                return new DTO.Model.TidsregistreringsInfo(tidsregistrering.TidsregistreringId, tidsregistrering.MedarbejderId, tidsregistrering.Start, tidsregistrering.Slut);
            }
            else
            {
                return new DTO.Model.TidsregistreringsInfo(tidsregistrering.TidsregistreringId,tidsregistrering.MedarbejderId, tidsregistrering.SagsId,tidsregistrering.Start, tidsregistrering.Slut);    
            }  
        }

        public static Tidsregistrering Map(DTO.Model.TidsregistreringsInfo tidsregistrering)
        {
            if (tidsregistrering.Sag == null)
            {
                return new Tidsregistrering(tidsregistrering.MedarbejderId, tidsregistrering.Start, tidsregistrering.Slut);
            }
            else
            {
                return new Tidsregistrering(tidsregistrering.MedarbejderId, tidsregistrering.SagsId, tidsregistrering.Start, tidsregistrering.Slut);
            }
        }


    }
}
