using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Context;
using DataAccess.Mappers;
using DTO.Model;

namespace DataAccess.Repositories
{
    public class MedarbejderRepository
    {
        public static Medarbejder getMedarbejder(int medarbejderId)
        {
            using (Context.Context context = new Context.Context())
            {
                return MedarbejderMapper.Map(context.Medarbejdere.Find(medarbejderId));
            }
        }
        public static List<Medarbejder> getMedarbejdere()
        {
            using (Context.Context context = new Context.Context())
            {
                return context.Medarbejdere.Select(MedarbejderMapper.Map).ToList();
            }
        }



        public static void AddMedarbejderToAfdeling(DTO.Model.Medarbejder medarbejder, int afdelingNr)
        {
            using (Context.Context context = new Context.Context())
            {
                var medarbejderEntity = MedarbejderMapper.Map(medarbejder);
                var afdeling = context.Afdelinger.Find(afdelingNr);

                if (afdeling != null)
                {
                    afdeling.Medarbejdere.Add(medarbejderEntity);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Afdeling not found");
                }
            }
        }
        
  
        public static void CreateMedarbejder(DTO.Model.Medarbejder medarbejder)
        {
            using (Context.Context context = new Context.Context())
            {
                var medarbejderEntity = MedarbejderMapper.Map(medarbejder);
                context.Medarbejdere.Add(medarbejderEntity);
                context.SaveChanges();
            }
        }

       
        public static void RemoveMedarbejder(int medarbejderId)
        {
            using (Context.Context context = new Context.Context())
            {
                var medarbejder = context.Medarbejdere.Find(medarbejderId);
                if (medarbejder != null)
                {
                    context.Medarbejdere.Remove(medarbejder);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Medarbejder not found");
                }
            }
        }
   

        public static List<TidsregistreringsInfo> getTidsregistreringer(int medarbejderId)
        {
            using (Context.Context context = new Context.Context())
            {
                var medarbejder = context.Medarbejdere.Find(medarbejderId);
                if (medarbejder != null)
                {
                    return medarbejder.Tidsregistreringer.Select(TidsregistreringMapper.Map).ToList();
                }
                else
                {
                    throw new Exception("Medarbejder not found");
                }
            }

        }


    }
}
