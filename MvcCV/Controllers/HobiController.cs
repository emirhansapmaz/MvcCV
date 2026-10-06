using Microsoft.AspNetCore.Mvc;
using MvcCV.Models;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    public class HobiController : Controller
    {
        GenericRepository<TblHobilerim> repo = new GenericRepository<TblHobilerim>();
        [HttpGet]
        public IActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }
        [HttpPost]
        public IActionResult Index(TblHobilerim p)
        {
            var hobi = repo.Find(x => x.Id == p.Id);
            hobi.Aciklama1 = p.Aciklama1;
            hobi.Aciklama2 = p.Aciklama2;
            repo.Update(hobi);
            return RedirectToAction("Index");

        }
    }

}
