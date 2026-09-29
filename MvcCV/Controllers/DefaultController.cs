using Microsoft.AspNetCore.Mvc;
using MvcCV.Models;

namespace MvcCV.Controllers
{
    public class DefaultController : Controller
    {
        DbCvContext db = new DbCvContext();
        public IActionResult Index()
        {
            var degerler = db.TblHakkinda.ToList();
            return View(degerler);
        }

        [HttpPost]
        public IActionResult MesajGonder(TblIletisim p)
        {
            p.Tarih = DateOnly.FromDateTime(DateTime.Now);
            db.TblIletisims.Add(p);
            db.SaveChanges();
                
            return RedirectToAction("Index");
        }

    }
}
