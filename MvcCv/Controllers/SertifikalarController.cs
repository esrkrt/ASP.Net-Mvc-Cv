using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Reopsitories;
using MvcCv.Models.Entitiy;

namespace MvcCv.Controllers
{
    public class SertifikalarController : Controller
    {
        // GET: Sertifikalar
        GenericRepository<TblSertifikalarım> repo = new GenericRepository<TblSertifikalarım>();
        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }
        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            TblSertifikalarım t = repo.Find(x => x.ID == id);
        ViewBag.d = id;
            return View(t);
        }
        [HttpPost]
        public ActionResult SertifikaGetir(TblSertifikalarım p)
        {
           
            TblSertifikalarım t = repo.Find(x => x.ID == p.ID);
            
            t.Aciklama = p.Aciklama;
            t.Tarih = p.Tarih;
            repo.TUpdate(t);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YeniSertifika()
        {

            return View();
        }
        [HttpPost]
        public ActionResult YeniSertifika(TblSertifikalarım  p)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniSertifika ");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaSil(int id)
        {
            TblSertifikalarım t = repo.Find(x => x.ID == id);
           
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
    }
}