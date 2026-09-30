using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcCV.Models;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{

    public class YeteneklerController : Controller
    {
        GenericRepository<TblYetenekler> repo = new GenericRepository<TblYetenekler>();
        public IActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }
        [HttpGet]
        public IActionResult YetenekEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YetenekEkle(TblYetenekler p)
        {
            repo.Insert(p);
            return RedirectToAction("Index");
        }
        public IActionResult YetenekSil(int id)
        {
            TblYetenekler t = repo.Find(x => x.Id == id);
            repo.delete(t);
            return RedirectToAction("Index");
        }
    }
}