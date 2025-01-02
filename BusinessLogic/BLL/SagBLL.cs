using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories;

namespace BusinessLogic.BLL
{
    public class SagBLL
    {
        public SagsInfo getSag(int sagsId)
        {

            if (sagsId == 0)
            {
                throw new Exception("Sag not found");
            }
            return SagRepository.getSag(sagsId) ;
        }
        
        public List<SagsInfo> FetchSager()
        {
            return DataAccess.Repositories.SagRepository.getSager();
        }


        public void CreateSag(SagsInfo sag)
        {
            DataAccess.Repositories.SagRepository.CreateSag(sag);
        }

        public void DeleteSag(int sagsId)
        {
            DataAccess.Repositories.SagRepository.RemoveSag(sagsId);
        }

    }
}
