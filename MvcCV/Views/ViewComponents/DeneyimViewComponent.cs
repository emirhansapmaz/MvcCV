using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCV.Models; // Context klasörünüz
using System.Linq;

// ViewComponent sınıfından miras alması şarttır
public class DeneyimViewComponent : ViewComponent
{
    private readonly DbCvContext db;

    public DeneyimViewComponent(DbCvContext context)
    {
        db = context;
    }

    // 'Invoke' metodu eskiden Controller'a yazdığınız metodun görevini üstlenir
    public IViewComponentResult Invoke()
    {
        // Kendi tablonuzdan veriyi çekin
        var degerler = db.TblDeneyims.ToList();

        // Not: Klasör taşıma zahmetine girmemek için View'ın tam yolunu belirtiyoruz
        return View("~/Views/Default/Deneyim.cshtml", degerler);
    }
}
