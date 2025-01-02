using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories;

namespace BusinessLogic.BLL
{
    public class MedarbejderBLL
    {
        public Medarbejder GetMedarbejder(int medarbejderId)
        {
         
            if (medarbejderId == 0)
            {
                throw new Exception("Medarbejder not found");
            }
            return MedarbejderRepository.getMedarbejder(medarbejderId);
        }
        
        public List<Medarbejder> FetchMedarbejdere()
        {
            return DataAccess.Repositories.MedarbejderRepository.getMedarbejdere();
        }


        public void CreateMedarbejder(DTO.Model.Medarbejder medarbejder)
        {
            DataAccess.Repositories.MedarbejderRepository.CreateMedarbejder(medarbejder);
        }


        public void DeleteMedarbejder(int medarbejderId)
        {
            
            DataAccess.Repositories.MedarbejderRepository.RemoveMedarbejder(medarbejderId);
        }

        public void AddMedarbejderToAfdeling(DTO.Model.Medarbejder medarbejder, int afdelingNr)
        {
            DataAccess.Repositories.MedarbejderRepository.AddMedarbejderToAfdeling(medarbejder, afdelingNr);
        }

        public double getTotalHoursWorked(int medarbejderId)
        {
            List<TidsregistreringsInfo> tider = DataAccess.Repositories.MedarbejderRepository.getTidsregistreringer(medarbejderId);

            foreach (var tid in tider)
            {
                if (tid.Slut != null)
                {
                    TimeSpan time = tid.Slut - tid.Start;
                    tid.TotalHours = time.TotalHours;
                }
            }
            return tider.Sum(t => t.TotalHours);
        }
        public double getHoursWeek(int medarbejderId)
        {
            List<TidsregistreringsInfo> tider = DataAccess.Repositories.MedarbejderRepository.getTidsregistreringer(medarbejderId).ToList();

            DateTime today = DateTime.Today;
            DayOfWeek currentDay = today.DayOfWeek;

            int daysSinceMonday = (int)currentDay - (int)DayOfWeek.Monday;
            if (daysSinceMonday < 0) daysSinceMonday += 7;
            DateTime weekStart = today.AddDays(-daysSinceMonday);
            DateTime weekEnd = weekStart.AddDays(6);

            double totalHoursWorked = tider
            .Where(tr => tr.Start >= weekStart && tr.Slut <= weekEnd) // Filter records within the week
            .Sum(tr => (tr.Slut - tr.Start).TotalHours);

            return totalHoursWorked;
        }


    }
}
