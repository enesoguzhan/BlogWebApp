using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.Admin.Controllers
{
	[Area("Admin")]
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.SignOutAsync();
            return Redirect("/admin/Login");
        }
    }
}
