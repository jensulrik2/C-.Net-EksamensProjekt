    using DTO.Model;
    using DataAccess.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace BusinessLogic.BLL
    {
        public class TidsregistreringBLL
        {
            public List<TidsregistreringsInfo> fetchTidsregistreringer(int medarbejderId)
            {
                return DataAccess.Repositories.TidsregistreringRepository.getTidsregistreringerForMedarbejder(medarbejderId);
            }
            public void RegistrerTid(int medarbejderId, int sagsId, DateTime start, DateTime slut)
            {

                var tidsregistrering = new TidsregistreringsInfo(medarbejderId, sagsId, start, slut);
                
                TidsregistreringRepository.opretTidsregistrering(tidsregistrering);
            }
            
            
        }
    }
