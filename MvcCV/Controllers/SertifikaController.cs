using Microsoft.AspNetCore.Mvc;
using MvcCV.Models;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    public class SertifikaController : Controller
    {

        GenericRepository<TblSertifikalar> repo = new GenericRepository<TblSertifikalar>();
        public IActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }
        [HttpGet]
        public IActionResult SertifikaGetir(int id)
        {
            var sertifika = repo.Find(x => x.Id == id);
            return View(sertifika);
        }
        [HttpPost]
        public IActionResult SertifikaGetir(TblSertifikalar p)
        {
            var sertifika = repo.Find(x => x.Id == p.Id);
            sertifika.Aciklama = p.Aciklama;
            sertifika.Tarih = p.Tarih;
            repo.Update(sertifika);
            return RedirectToAction("Index");
        }
        public IActionResult SertifikaSil(int id)
        {
            var sertifika = repo.Find(x => x.Id == id);
            repo.delete(sertifika);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult SertifikaEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SertifikaEkle(TblSertifikalar p)
        {
            repo.Insert(p);
            return RedirectToAction("Index");
        }

    }
}
