using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    internal class MedarbejderMapper
    {
        public static DTO.Model.Medarbejder Map(Medarbejder medarbejder)
        {
            return new DTO.Model.Medarbejder(medarbejder.MedarbejderId, medarbejder.Initialer, medarbejder.Cpr, medarbejder.Navn);
        }

        public static Medarbejder Map(DTO.Model.Medarbejder medarbejder)
        {
            return new Medarbejder( medarbejder.Initialer, medarbejder.Cpr, medarbejder.Navn);
        }
    }
}
