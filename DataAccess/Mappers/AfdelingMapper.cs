using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Model;
using DataAccess.Model;

namespace DataAccess.Mappers
{
    internal class AfdelingMapper
    {
        public static DTO.Model.AfdelingsInfo Map(Afdeling afdeling)
        {
            return new DTO.Model.AfdelingsInfo(afdeling.AfdelingNr, afdeling.Navn);
        }

        public static Afdeling Map(DTO.Model.AfdelingsInfo afdeling)
        {
            return new Afdeling(afdeling.Navn);
        }

        public static List<AfdelingsInfo> Map(List<Afdeling> afdelinger)
        {
            return afdelinger.Select(Map).ToList();
        }
        public static List<Afdeling> Map(List<AfdelingsInfo> afdelinger)
        {
            return afdelinger.Select(Map).ToList();
        }
    }
}
