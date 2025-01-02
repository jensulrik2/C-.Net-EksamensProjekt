using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    internal class SagMapper
    {
        public static DTO.Model.SagsInfo Map(Sag sag)
        {
            return new DTO.Model.SagsInfo(sag.SagsId, sag.Overskrift, sag.Beskrivelse, sag.AfdelingNr);
        }

        public static Sag Map(DTO.Model.SagsInfo sag)
        {
            return new Sag( sag.Overskrift, sag.Beskrivelse, sag.AfdelingNr);
        }
    }
}
