using DataAccess.Repositories;
using DTO.Model;
using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BLL
{
    public class AfdelingBLL
    {
        
       
        public static List<AfdelingsInfo> FetchAfdelinger()
        {
            return AfdelingRepository.hentAlleAfdelinger();
        }

        public static List<Medarbejder> FetchMedarbejdere(int nr)
        {
            return AfdelingRepository.hentAlleMedarbejdere(nr);
        }

        public static List<SagsInfo> FetchSager(int nr)
        {
            return AfdelingRepository.hentAlleSager(nr);
        }


        public static void CreateAfdeling(AfdelingsInfo afdeling)
        {
            AfdelingRepository.createAfdeling(afdeling);
        }

            public static void DeleteAfdeling(int afdelingNr)
        {
            AfdelingRepository.removeAfdeling(afdelingNr);
        }
    }
}
