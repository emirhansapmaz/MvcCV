using Microsoft.AspNetCore.Mvc;
using MvcCV.Models;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    public class HakkimdaController : Controller
    {
        GenericRepository<TblHakkindum> repo = new GenericRepository<TblHakkindum>();
        [HttpGet]
        public IActionResult Index()
        {
            var hakkindum = repo.List();
            return View(hakkindum);
        }
        [HttpPost]
        public IActionResult Index(TblHakkindum p)
        {
            var hakkindum = repo.Find(x => x.Id == p.Id);
            hakkindum.Ad = p.Ad;
            hakkindum.Soyad = p.Soyad;
            hakkindum.Adres = p.Adres;
            hakkindum.Mail = p.Mail;
            hakkindum.Telefon = p.Telefon;
            hakkindum.Aciklama = p.Aciklama;
            hakkindum.Resim = p.Resim;
            repo.Update(hakkindum);
            return RedirectToAction("Index");

        }
    }

}
