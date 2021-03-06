using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.Admin.Controllers
{
    [Area("admin")]
    public class InteractionsController : Controller
    {
        private readonly IInteractionsService service;
        public InteractionsController(IInteractionsService service)
        {
            this.service = service;
        }

        [Route("/admin/Interactions/{blogId}")]
       // [HttpGet]
        public IActionResult Index(int blogId)
        {
            return View(service.GetAllList(s => s.Blogs).Where(s => s.BlogId == blogId));
        }

        [Route("/admin/Interactions/Delete/{Id}")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            service.Delete(s => s.Id == id);
            return Redirect("/admin/Blogs");
        }

    }
}
