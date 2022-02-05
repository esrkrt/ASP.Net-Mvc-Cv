using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entitiy;
using MvcCv.Reopsitories;

namespace MvcCv.Controllers
{
    public class HakkimdaController : Controller
    {
        DbCvEntities db = new DbCvEntities();
        GenericRepository<TblHakkimda> repo = new GenericRepository<TblHakkimda>();
        [HttpGet]
        public ActionResult Index()
        {
            var hobi = repo.List();
            return View(hobi);
        }
        [HttpPost]
        public ActionResult Index(TblHakkimda p)
        {
            var deger = repo.Find(x => x.ID == 1);
            deger.Ad = p.Ad;
            deger.Soyad = p.Soyad;
            deger.Adres = p.Adres;
            deger.Mail = p.Mail;
            deger.Telefon = p.Telefon;
            deger.Aciklama = p.Aciklama;
            deger.Resim = p.Resim;
            repo.TUpdate(deger);
            return RedirectToAction("Index");
        }
    }
}