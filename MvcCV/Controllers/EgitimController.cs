using Microsoft.AspNetCore.Mvc;
using MvcCV.Models;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    public class EgitimController : Controller
    {
        GenericRepository<TblEgitim> repo = new GenericRepository<TblEgitim>();
        public IActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }
        public IActionResult EgitimSil(int id)
        {
            TblEgitim t = repo.Find(x => x.Id == id);
            repo.delete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EgitimEkle(TblEgitim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.Insert(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EgitimDuzenle(int id)
        {
            var egitim = repo.Find(x => x.Id == id);
            return View(egitim);
        }
        [HttpPost]
        public IActionResult EgitimDuzenle(TblEgitim p)
        {
            var e = repo.Find(x => x.Id == p.Id);
            e.Baslik = p.Baslik;
            e.AltBaslik = p.AltBaslik;
            e.AltBaslik2 = p.AltBaslik2;
            e.Gno = p.Gno;
            e.Tarih = p.Tarih;
            repo.Update(e);
            return RedirectToAction("Index");
        }


    }
}
