using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Context;
using DataAccess.Mappers;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class AfdelingRepository
    {
        public static AfdelingsInfo getAfdeling(int nr)
        {
            using (Context.Context context = new Context.Context())
            {
                var afdeling = context.Afdelinger
                    .Include(a => a.Medarbejdere)
                    .FirstOrDefault(a => a.AfdelingNr == nr);
                return AfdelingMapper.Map(afdeling);
            }
        }

        public static List<DTO.Model.Medarbejder> hentAlleMedarbejdere(int nr)
        {
            using (Context.Context context = new Context.Context())
            {
                var afdeling = context.Afdelinger
                    .Include(a => a.Medarbejdere)
                    .FirstOrDefault(a => a.AfdelingNr == nr);
                if (afdeling != null)
                {
                    return afdeling.Medarbejdere.Select(MedarbejderMapper.Map).ToList();
                }
                return new List<DTO.Model.Medarbejder>();
            }
        }

        public static List<SagsInfo> hentAlleSager(int nr)
        {
            using (Context.Context context = new Context.Context())
            {
                var afdeling = context.Afdelinger
                    .Include(a => a.Sager) // Include related Sager
                    .FirstOrDefault(a => a.AfdelingNr == nr);

                if (afdeling != null)
                {
                    // Assuming you want to map Sager to SagsInfo, you can use a mapper if needed
                    return afdeling.Sager.Select(SagMapper.Map).ToList();

                }
        
                return new List<SagsInfo>();
            }
        }

        public static List<AfdelingsInfo> hentAlleAfdelinger()
        {
            using (Context.Context context = new Context.Context())
            {
                var afdelinger = context.Afdelinger.ToList();
                return AfdelingMapper.Map(afdelinger);
            }
        }

        public static void createAfdeling(AfdelingsInfo afdeling)
        {
            using (Context.Context context = new Context.Context())
            {
                var afdelingEntity = AfdelingMapper.Map(afdeling);
                context.Afdelinger.Add(afdelingEntity);
                context.SaveChanges();
            }
        }

        public static void removeAfdeling(int nr)
        {
            using (Context.Context context = new Context.Context())
            {
                var afdeling = context.Afdelinger.Find(nr);
                if (afdeling != null)
                {
                    //skal også fjerne sin relation til medarbejder og sager først

                    context.Afdelinger.Remove(afdeling);
                    context.SaveChanges();
                }
            }
        }
    }
}