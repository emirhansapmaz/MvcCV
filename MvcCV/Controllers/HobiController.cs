using Microsoft.AspNetCore.Mvc;

namespace MvcCV.Controllers
{
    public class HobiController : Controller
    {
        GenericRepository<TblHobilerim> repo = new GenericRepository<TblHobilerim>();
        public IActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }
    }
}
