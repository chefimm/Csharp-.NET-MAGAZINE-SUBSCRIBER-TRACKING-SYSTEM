using Dergi_Abone_Takip_ASP.NET.Data.Model;
using Dergi_Abone_Takip_ASP.NET.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dergi_Abone_Takip_ASP.NET.Controllers
{
    public class AlinanDergiController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        public AlinanDergiController()
        {
            unitOfWork = new UnitOfWork();
        }

        // GET: AlinanDergi/AboneSuresi
        public ActionResult AboneSuresi()
        {
            var alinanDergi = unitOfWork.GetRepository<AlinanDergi>().GetAll(x => x.OdemeTarihi == null);
            return View(alinanDergi);
        }

        public ActionResult Odendi()
        {
            var alinanDergi = unitOfWork.GetRepository<AlinanDergi>().GetAll(x=>x.OdemeTarihi != null);
            return View(alinanDergi);
        }

        public ActionResult OdemeVer()
        {
            ViewBag.Dergiler = unitOfWork.GetRepository<Dergi>().GetAll(x => x.Adet > 0);
            ViewBag.Uyeler = unitOfWork.GetRepository<Uye>().GetAll();
            return View();
        }

        [HttpPost]
        public JsonResult OdemeVerJson(int uyeId, int dergiId, DateTime aboneBitisTarih)
        {
            AlinanDergi alinanDergi = new AlinanDergi();
            alinanDergi.AboneBaslangic = DateTime.Now;
            alinanDergi.AboneBitis = aboneBitisTarih;
            alinanDergi.DergiId = dergiId;
            alinanDergi.UyeId = uyeId;
            unitOfWork.GetRepository<AlinanDergi>().Add(alinanDergi);
            var durum = unitOfWork.SaveChanges();
            if (durum > 0)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, message = "Ödeme işlemi gerçekleştirilemedi." });
            }
        }

        public ActionResult OdemeDergiGuncelle(int alinanDergiId)
        {
            ViewBag.Dergiler = unitOfWork.GetRepository<Dergi>().GetAll(x => x.Adet > 0);
            ViewBag.Uyeler = unitOfWork.GetRepository<Uye>().GetAll();
            var alinanDergi = unitOfWork.GetRepository<AlinanDergi>().GetById(alinanDergiId);
            return View(alinanDergi);
        }

        [HttpPost]
        public JsonResult OdemeDergiGuncelleJson(int alinanDergiId, int uyeId, int dergiId, DateTime aboneBitisTarih)
        {
            var alinanDergi = unitOfWork.GetRepository<AlinanDergi>().GetById(alinanDergiId);
            alinanDergi.AboneBitis = aboneBitisTarih;
            alinanDergi.DergiId = dergiId;
            alinanDergi.UyeId = uyeId;
            unitOfWork.GetRepository<AlinanDergi>().Update(alinanDergi);
            var durum = unitOfWork.SaveChanges();
            if (durum > 0)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, message = "Güncelleme işlemi gerçekleştirilemedi." });
            }
        }
        [HttpPost]
        public JsonResult OdemeOnayla(int alinanDergiId) 
        {
            var alinanDergi = unitOfWork.GetRepository<AlinanDergi>().GetById(alinanDergiId);
            alinanDergi.OdemeTarihi = DateTime.Now;
            unitOfWork.GetRepository<AlinanDergi>().Update(alinanDergi);
            var durum = unitOfWork.SaveChanges();
            if(durum > 0)
            {
                return Json("1");
            }
            else 
            {
                return Json("0");
            }
                
        }
    }
}
