using Microsoft.AspNetCore.Mvc;
using MvcCV.Models;
using MvcCV.Repositories;
using System.Linq;

public class SosyalMedyaViewComponent : ViewComponent
{
    // Repository nesnemizi oluşturuyoruz
    GenericRepository<TblSosyalMedya> repo = new GenericRepository<TblSosyalMedya>();

    public IViewComponentResult Invoke()
    {
        // Hem verileri repo'dan çekiyoruz hem de sadece Durum'u True olanları filtreliyoruz
        var degerler = repo.List().Where(x => x.Durum == true).ToList();

       

        return View("~/Views/Default/SosyalMedya.cshtml", degerler);
    }
}