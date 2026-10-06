using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcCV.Models;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        GenericRepository<TblAdmin> repo = new GenericRepository<TblAdmin>();
        public IActionResult Index()
        {
            var liste = repo.List();
            return View(liste);
        }
        [HttpGet]
        public IActionResult AdminEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminEkle(TblAdmin p)
        {
            repo.Insert(p);
            return RedirectToAction("Index");
        }

        public ActionResult AdminSil(int id)
        {
            var yetenek = repo.Find(x => x.Id == id);
            repo.delete(yetenek);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminGetir(int id)
        {
            TblAdmin t = repo.Find(x => x.Id == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult AdminGetir(TblAdmin p)
        {
            TblAdmin t = repo.Find(x => x.Id == p.Id);
            t.KullaniciAdi = p.KullaniciAdi;
            t.Sifre = p.Sifre;
            repo.Update(t);

            return RedirectToAction("Index");
        }
    }
}
    

