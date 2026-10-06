using Microsoft.AspNetCore.Mvc;
using MvcCV.Models;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    public class IletisimController : Controller
    {
        GenericRepository<TblIletisim> repo = new GenericRepository<TblIletisim>();
        public IActionResult Index()
        {
            var iletisimler = repo.List();
            return View(iletisimler);
        }
    }
}
