using Dergi_Abone_Takip_ASP.NET.Data.Model;
using Dergi_Abone_Takip_ASP.NET.Data.UnitOfWork;
using System;
using System.Web.Mvc;

namespace Dergi_Abone_Takip_ASP.NET.Controllers
{
    public class UyeController : Controller
    {
        private UnitOfWork unitOfWork;

        public UyeController()
        {
            unitOfWork = new UnitOfWork();
        }

        // GET: Uye
        public ActionResult Index()
        {
            var uyeler = unitOfWork.GetRepository<Uye>().GetAll();
            return View(uyeler);
        }

        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public JsonResult EkleJson(string uyeAd, string uyeSoyad, string uyeAdres, string uyeTel)
        {
            if (!string.IsNullOrEmpty(uyeAd) && !string.IsNullOrEmpty(uyeSoyad))
            {
                Uye uye = new Uye();
                uye.Ad = uyeAd;
                uye.Soyad = uyeSoyad;
                uye.Adres = uyeAdres;
                uye.Tel = uyeTel;
                uye.Ceza = 0;
                uye.KayitTarihi = DateTime.Now;
                unitOfWork.GetRepository<Uye>().Add(uye);

                var durum = unitOfWork.SaveChanges();

                if (durum > 0)
                {
                    return Json("1");
                }
                else
                {
                    return Json("0");
                }

            }
            else { return Json("bosOlamaz"); }

        }
        [HttpPost]
        public JsonResult SilJson(int uyeId)
        {
            var uye = unitOfWork.GetRepository<Uye>().GetById(uyeId);
            if (uye != null)
            {
                unitOfWork.GetRepository<Uye>().Delete(uye);
                unitOfWork.SaveChanges();
                return Json("1");
            }
            return Json("0");
        }

        public ActionResult Guncelle(int uyeId)
        {

            var uye = unitOfWork.GetRepository<Uye>().GetById(uyeId);
            return View(uye);
        }

        [HttpPost]
        public JsonResult GuncelleJson(int uyeId,string uyeAd, string uyeSoyad, string uyeAdres, string uyeTel)
        {
            if (!string.IsNullOrEmpty(uyeAd) && !string.IsNullOrEmpty(uyeSoyad))
            {

                var uye = unitOfWork.GetRepository<Uye>().GetById(uyeId);
                uye.Ad = uyeAd;
                uye.Soyad = uyeSoyad;
                uye.Adres = uyeAdres;
                uye.Tel = uyeTel;
                unitOfWork.GetRepository<Uye>().Update(uye);
                var durum = unitOfWork.SaveChanges();

                if (durum > 0)
                {
                    return Json("1");
                }
                else
                {
                    return Json("0");
                }

            }
            else { return Json("bosOlamaz"); }

        }

    }
}