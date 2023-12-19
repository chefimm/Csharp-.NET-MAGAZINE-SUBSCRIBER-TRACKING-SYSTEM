using Dergi_Abone_Takip_ASP.NET.Data.Model;
using Dergi_Abone_Takip_ASP.NET.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Dergi_Abone_Takip_ASP.NET.Controllers
{
    public class DergiController : Controller
    {
        UnitOfWork unitOfWork;

        public DergiController()
        {
            unitOfWork = new UnitOfWork();
        }

        // GET: Dergi
        public ActionResult Index()
        {
            var dergiler = unitOfWork.GetRepository<Dergi>().GetAll();
            return View(dergiler);
        }

        public ActionResult Ekle() 
        {
            ViewBag.Kategoriler = unitOfWork.GetRepository<Kategori>().GetAll();
            ViewBag.Yazarlar = unitOfWork.GetRepository<Yazar>().GetAll();
            return View();
        }

        [HttpPost]
        public JsonResult EkleJson(string[] kategoriler, string yazar, string dergiAd, string dergiAdet, string siraNo)
        {
            if (kategoriler != null && !string.IsNullOrEmpty(yazar) && !string.IsNullOrEmpty(dergiAd) && !string.IsNullOrEmpty(dergiAdet) && !string.IsNullOrEmpty(siraNo))
            {
                List<Kategori> k = new List<Kategori>();
                foreach (var kategoriId in kategoriler)
                {
                    var kategoriID = Convert.ToInt32(kategoriId);
                    var kategori = unitOfWork.GetRepository<Kategori>().GetById(kategoriID);
                    k.Add(kategori);
                }

                Dergi dergi = new Dergi();
                dergi.Ad = dergiAd;
                dergi.Adet = Convert.ToInt32(dergiAdet);
                dergi.YazarId = Convert.ToInt32(yazar);
                dergi.SiraNo = siraNo;
                dergi.Kategoriler = k;
                dergi.EklenmeTarihi = DateTime.Now;
                unitOfWork.GetRepository<Dergi>().Add(dergi);
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
            else
            {
                return Json("bosOlamaz");
            }
        }

        [HttpPost]
        public JsonResult SilJson(int dergiId)
        {
            Dergi dergi = unitOfWork.GetRepository<Dergi>().GetById(dergiId);
            if (dergi != null)
            {
                unitOfWork.GetRepository<Dergi>().Delete(dergi);
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
            else
            {
                return Json("dergiBulunamadi");
            }
        }

        public ActionResult Guncelle(int dergiId) 
        {
            ViewBag.Kategoriler = unitOfWork.GetRepository<Kategori>().GetAll();
            ViewBag.Yazarlar = unitOfWork.GetRepository<Yazar>().GetAll();
            var dergi = unitOfWork.GetRepository<Dergi>().GetById(dergiId);
            return View(dergi);
        }

       [HttpPost]
        public JsonResult GuncelleJson(int dergiId, string[] kategoriler, string yazar, string dergiAd, string dergiAdet, string siraNo)
        {
            if (kategoriler != null && !string.IsNullOrEmpty(yazar) && !string.IsNullOrEmpty(dergiAd) && !string.IsNullOrEmpty(dergiAdet) && !string.IsNullOrEmpty(siraNo))
            {
                var dergi = unitOfWork.GetRepository<Dergi>().GetById(dergiId);
                if (dergi != null)
                {
                    dergi.Ad = dergiAd;
                    dergi.Adet = Convert.ToInt32(dergiAdet);
                    dergi.YazarId = Convert.ToInt32(yazar);
                    dergi.SiraNo = siraNo;
                    dergi.Kategoriler.Clear();

                    foreach (var kategoriId in kategoriler)
                    {
                        var kategoriID = Convert.ToInt32(kategoriId);
                        var kategori = unitOfWork.GetRepository<Kategori>().GetById(kategoriID);
                        dergi.Kategoriler.Add(kategori);
                    }

                    unitOfWork.GetRepository<Dergi>().Update(dergi);
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
                else
                {
                    return Json("dergiBulunamadi");
                }
            }
            else
            {
                return Json("bosOlamaz");
            }
        }
    }
}