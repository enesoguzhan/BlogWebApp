using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace UIWeb.Areas.Admin.Controllers
{
    [Area("admin")]
    public class LoginController : Controller
    {
        private readonly IUserService service;
        public LoginController(IUserService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string email, string sifre)
        {
            /* 
            Claims : Giriş yapan kullanıcının bilgilerini tutmak ve yönetmek için kullanılan classtır
            ClaimsIdentity: Proje  içerisinde oluşturulan Claimslere sanal isim verip yönetmemizi sağlarlar.
            ClaimsPrincipal : Claims İçerisindeki dataları şifrelememizi sağlar
            */
            var userInfo = service.GetById(s => s.Email == email && s.Password == sifre);
            if (userInfo != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userInfo.NameSurname),
                    new Claim(ClaimTypes.Role, "admin"),
                    new Claim("Id", userInfo.Id.ToString()),
                };
                var UserIdentity = new ClaimsIdentity(claims,"UserLogin");
                ClaimsPrincipal principal = new ClaimsPrincipal(UserIdentity);
                HttpContext.SignInAsync(principal);
                return Redirect("/admin/Blogs");
            }
            else
            {
                ViewBag.Error = "Kullanıcı Adı veya Şifre Hatalı";
            }
            return View();
        }
    }
}
