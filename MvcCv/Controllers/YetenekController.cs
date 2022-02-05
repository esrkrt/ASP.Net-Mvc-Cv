using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entitiy;
using MvcCv.Reopsitories;
namespace MvcCv.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
        DbCvEntities db = new DbCvEntities();
        GenericRepository<TblYetenekler> repo = new GenericRepository<TblYetenekler>(); 
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {

            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(TblYetenekler p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult YetenekSil(int id)
        {
            TblYetenekler t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekDuzenle(int id)
        {
            TblYetenekler t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult YetenekDuzenle(TblYetenekler p)
        {
            TblYetenekler t = repo.Find(x => x.ID == p.ID);
            t.Yetenek= p.Yetenek;
            t.Oran = p.Oran;
           
            repo.TUpdate(t);

            return RedirectToAction("Index");
        }
    }
}