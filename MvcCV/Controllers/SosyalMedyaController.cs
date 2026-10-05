using Microsoft.AspNetCore.Mvc;
using MvcCV.Models;
using MvcCV.Repositories;


namespace MvcCV.Controllers
{
    public class SosyalMedyaController : Controller
    {
        GenericRepository<TblSosyalMedya> repo = new GenericRepository<TblSosyalMedya>();
        public IActionResult Index()
        {
            var sosyalMedya = repo.List();
            return View(sosyalMedya);
        }
        [HttpGet]
        public IActionResult SosyalMedyaEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SosyalMedyaEkle(TblSosyalMedya p)
        {
            repo.Insert(p);
            return RedirectToAction("Index");
        }
        public IActionResult SosyalMedyaSil(int id)
        {
            var sosyalMedya = repo.Find(x => x.Id == id);
            sosyalMedya.Durum = false;
            repo.Update(sosyalMedya);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult SosyalMedyaGuncelle(int id)
        {
            var sosyalMedya = repo.Find(x => x.Id == id);
            return View(sosyalMedya);
        }
        [HttpPost]
        public IActionResult SosyalMedyaGuncelle(TblSosyalMedya p)
        {
            var sosyalMedya = repo.Find(x => x.Id == p.Id);
            sosyalMedya.Ad = p.Ad;
            sosyalMedya.Durum = true;
            sosyalMedya.Link = p.Link;
            sosyalMedya.Icon = p.Icon;
            repo.Update(sosyalMedya);
            return RedirectToAction("Index");
        }
    }
}
