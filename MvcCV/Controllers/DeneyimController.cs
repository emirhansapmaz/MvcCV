using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcCV.Models;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    public class DeneyimController : Controller
    {
        DeneyimRepository repo = new DeneyimRepository();
        public IActionResult Index()
        {
            var deneyimler = repo.List();
            return View(deneyimler);
        }
        [HttpGet]
        public IActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeneyimEkle(TblDeneyim p)
        {
            repo.Insert(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeneyimSil(int id)
        {
            TblDeneyim t = repo.Find(x => x.Id == id);
            repo.delete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            TblDeneyim t = repo.Find(x => x.Id ==id);
            return View(t);
        }
        [HttpPost]
        public ActionResult DeneyimGetir(TblDeneyim p)
        {
            TblDeneyim t = repo.Find(x => x.Id == p.Id);
            t.Baslik = p.Baslik;
            t.AltBaslik = p.AltBaslik;
            t.Tarih = p.Tarih;
            t.Aciklama = p.Aciklama;
            repo.Update(t);

            return RedirectToAction("Index");
        }
    }   
}
