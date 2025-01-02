using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Model;
using DataAccess.Mappers;

namespace DataAccess.Repositories
{
    public class SagRepository
    {
        public static SagsInfo getSag(int sagsId)
        {
            using (Context.Context context = new Context.Context())
            {
                return SagMapper.Map(context.Sager.Find(sagsId));
            }
        }
        
        public static List<SagsInfo> getSager()
        {
            using (Context.Context context = new Context.Context())
            {
                return context.Sager.Select(SagMapper.Map).ToList();
            }
        }

        public static void CreateSag(SagsInfo sag)
        {
            using (Context.Context context = new Context.Context())
            {
                var sagEntity = SagMapper.Map(sag);
                context.Sager.Add(sagEntity);
                context.SaveChanges();
            }
        }

        public static void RemoveSag(int sagsId)
        {
            using (Context.Context context = new Context.Context())
            {
                var sag = context.Sager.Find(sagsId);
                if (sag != null)
                {
                    context.Sager.Remove(sag);
                    context.SaveChanges();
                }
            }
        }

    }
}
