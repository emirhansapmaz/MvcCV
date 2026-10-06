using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http; // Session için
using Microsoft.AspNetCore.Mvc;
using MvcCV.Models;
using System.Security.Claims;

namespace MvcCV.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        // 1. Sayfanın ilk açılışını (HTML formunun ekrana gelmesini) sağlayan metot
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // 2. Butona basıldığında giriş verilerini kontrol eden metot
        [HttpPost]
        public async Task<IActionResult> Index(TblAdmin p)
        {
            DbCvContext db = new DbCvContext();
            var bilgiler = db.TblAdmins.FirstOrDefault(x => x.KullaniciAdi == p.KullaniciAdi && x.Sifre == p.Sifre);

            if (bilgiler != null)
            {
                // Yeni sistem FormsAuthentication (Cookie tabanlı giriş)
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, bilgiler.KullaniciAdi)
                };

                var useridentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                // Yeni sistem Session ataması
                HttpContext.Session.SetString("KullaniciAdi", bilgiler.KullaniciAdi);

                return RedirectToAction("Index", "Hakkimda"); // Giriş başarılıysa yönlendirilecek sayfa
            }
            else
            {
                return View(); // Şifre veya kullanıcı adı yanlışsa aynı sayfada kal
            }
        }

        // 3. Çıkış yapma metodu
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            // 1. Tarayıcıdaki yetkilendirme çerezini (Cookie) siler
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // 2. Varsa Session (oturum) verilerini tamamen temizler
            HttpContext.Session.Clear();

            // 3. Çıkış yaptıktan sonra giriş ekranına geri yönlendirir
            return RedirectToAction("Index", "Login");
        }
    }
}

