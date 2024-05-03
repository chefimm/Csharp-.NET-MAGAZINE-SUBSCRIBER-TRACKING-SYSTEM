using Dergi_Abone_Takip_ASP.NET.Data.Model;
using Dergi_Abone_Takip_ASP.NET.Data.UnitOfWork;
using Dergi_Abone_Takip_ASP.NET.HelperClass;
using System.Web.Mvc;

namespace Dergi_Abone_Takip_ASP.NET.Controllers
{
    public class UyelikController : Controller
    {
        UnitOfWork unitOfWork;
        public UyelikController() 
        {
            unitOfWork = new UnitOfWork();
        }
        // GET: Uyelik
        public ActionResult Index()
        {
            var uyeler = unitOfWork.GetRepository<Uye>().GetAll(x => x.Yetki != null);
            return View(uyeler);
        }
        public ActionResult Ekle() 
        {
            var uyeler = unitOfWork.GetRepository<Uye>().GetAll(x => x.Yetki == null);
            return View(uyeler);
        }
        [HttpPost]
        public JsonResult EkleJson(int uyeId, string mail, string parola, string parolaTekrar) 
        {
            if(!string.IsNullOrEmpty(mail) && string.IsNullOrEmpty(parola) && !string.IsNullOrEmpty(parolaTekrar)) 
            {
                if(parola == parolaTekrar) 
                {
                    parola = Sifreleme.Sifrele(parola);
                    var uye = unitOfWork.GetRepository<Uye>().GetById(uyeId);
                    uye.Mail = mail;
                    uye.Sifre = parola;
                    // 1  = admin 2 = modaretör düzenleme işleri 3 = abone ve ekran görme işlem yapamaz
                    uye.Yetki = "3";

                    unitOfWork.GetRepository<Uye>().Add(uye);
                    unitOfWork.SaveChanges();
                    return Json("1");
                }
                else 
                {
                    return Json("paroloUyusmazligi");
                }
            }
            else
            {
                return Json("bosOlamaz");

            }
        }
    }
}