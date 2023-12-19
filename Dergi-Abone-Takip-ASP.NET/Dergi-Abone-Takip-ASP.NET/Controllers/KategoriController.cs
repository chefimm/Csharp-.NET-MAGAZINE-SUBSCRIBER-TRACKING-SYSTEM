using Dergi_Abone_Takip_ASP.NET.Data.Model;
using Dergi_Abone_Takip_ASP.NET.Data.UnitOfWork;
using System.Web.Mvc;

namespace Dergi_Abone_Takip_ASP.NET.Controllers
{
    public class KategoriController : Controller
    {
        UnitOfWork unitOfWork;

        public KategoriController()
        {
            unitOfWork = new UnitOfWork();
        }

        // GET: Kategori
        public ActionResult Index()
        {
            var kategoriler = unitOfWork.GetRepository<Kategori>().GetAll();
            return View(kategoriler);
        }
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public JsonResult EkleJson(string ktgAd)
        {
            if (!string.IsNullOrEmpty(ktgAd))
            {
                Kategori ktgr = new Kategori();
                ktgr.Ad = ktgAd;
                unitOfWork.GetRepository<Kategori>().Add(ktgr);
                unitOfWork.SaveChanges();

                return Json("1");
            }
            else
            {
                return Json("bosOlamaz");
            }
        }

        [HttpPost]
        public JsonResult GuncelleJson(int ktgId,string ktgAd) 
        {
            var kategori = unitOfWork.GetRepository<Kategori>().GetById(ktgId);
            kategori.Ad = ktgAd;
            var durum = unitOfWork.SaveChanges();
            if(durum > 0) 
            {
                return Json("1");
            }
            return Json("0");
        }
        [HttpPost]
        public JsonResult SilJson(int ktgId)
        {
            var kategori = unitOfWork.GetRepository<Kategori>().GetById(ktgId);
            if (kategori != null)
            {
                unitOfWork.GetRepository<Kategori>().Delete(kategori);
                unitOfWork.SaveChanges();
                return Json("1");
            }
            return Json("0");
        }


        /*[HttpPost]
        public JsonResult SilJson(int ktgId)
        {
            unitOfWork.GetRepository<Kategori>().Delete(ktgId);
            var durum = unitOfWork.SaveChanges();
            if (durum > 0)
            {
                return Json("1");
            }
            return Json("0");
        }*/
    }
}