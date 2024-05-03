using Dergi_Abone_Takip_ASP.NET.Data.Model;
using Dergi_Abone_Takip_ASP.NET.Data.UnitOfWork;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Dergi_Abone_Takip_ASP.NET.Tasks.Jobs
{
    public class CezaArttirmaDusurmeJob : IJob
    {
        private readonly UnitOfWork unitOfWork;

        public CezaArttirmaDusurmeJob(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public void Execute(IJobExecutionContext context)
        {
            try
            {
                CezaArttir();
                CezaDusur();
                unitOfWork.SaveChanges();
            }
            catch { }

        }

         void CezaArttir()
        {
            var alinanDergiler = unitOfWork.GetRepository<AlinanDergi>().GetAll(x => x.OdemeTarihi == null && DateTime.Now > x.OdemeTarihi);
            foreach (var alinanDergi in alinanDergiler)
            {
                alinanDergi.Uye.Ceza += 1;
                unitOfWork.GetRepository<Uye>().Update(alinanDergi.Uye);
            }
        }

         void CezaDusur()
        {
            var alinanDergiler = unitOfWork.GetRepository<AlinanDergi>().GetAll(x => x.OdemeTarihi != null && x.Uye.Ceza > 0);
            foreach (var alinanDergi in alinanDergiler)
            {
                alinanDergi.Uye.Ceza -= 1;
                unitOfWork.GetRepository<Uye>().Update(alinanDergi.Uye);
            }
        }
    }
}
