using DTO.Model;
using DataAccess.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class TidsregistreringRepository
    {
        public static TidsregistreringsInfo getTidsregestrering(int tidsregistreringID)
        {
            if (tidsregistreringID <= 0) throw new IndexOutOfRangeException("TidsregistreringID skal være større end 0");
            using (Context.Context context = new Context.Context())
            {
                return Mappers.TidsregistreringMapper.Map(context.Tidsregistreringer.Find(tidsregistreringID));
            }
        }
        public static void opretTidsregistrering(TidsregistreringsInfo tidsregistrering)
        {
            using (Context.Context context = new Context.Context())
            {
                context.Tidsregistreringer.Add(Mappers.TidsregistreringMapper.Map(tidsregistrering));
                context.SaveChanges();
            }
        }

        public static List<TidsregistreringsInfo> getTidsregistreringerForMedarbejder(int medarbejderId)
        {
            using (Context.Context context = new Context.Context())
            {
                var tidsregistreringer = context.Tidsregistreringer
                    .Where(t => t.MedarbejderId == medarbejderId)
                    .ToList()
                    .Select(TidsregistreringMapper.Map)
                    .ToList();
                return tidsregistreringer;
            }
        }


    }
    
}
