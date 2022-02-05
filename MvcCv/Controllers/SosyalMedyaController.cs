using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entitiy;
using MvcCv.Reopsitories;
namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<TblSosyalMedya> repo = new GenericRepository<TblSosyalMedya>();
        public ActionResult Index()
        {
            var veriler = repo.List();
            return View(veriler);
        }
        [HttpGet]
        public ActionResult Ekle()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Ekle(TblSosyalMedya p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            TblSosyalMedya t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult Duzenle(TblSosyalMedya p)
        {
            TblSosyalMedya t = repo.Find(x => x.ID == p.ID);
            t.Ad = p.Ad;
            t.Durum = true;
            t.Link = p.Link;
            t.ikon = p.ikon;
            repo.TUpdate(t);

            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            TblSosyalMedya t = repo.Find(x => x.ID == id);
            t.Durum = false;
            repo.TUpdate(t);

            return RedirectToAction("Index");
        }
    }
}