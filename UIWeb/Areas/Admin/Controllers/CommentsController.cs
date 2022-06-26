using BusinessLayer.Abstract;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.Admin.Controllers
{
    [Area("admin")]
    public class CommentsController : Controller
    {
        private readonly ICommentService service;
        public CommentsController(ICommentService service)
        {
            this.service = service;
        }

        [Route("/admin/Comments/{BlogId}")]
        [HttpGet]
        public IActionResult Index(int blogId)
        {
            return View(service.GetAllList(s=>s.Blogs).Where(s => s.BlogId == blogId));
        }

        [Route("/admin/Comments/Update/{Id}")]
        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(service.GetById(s => s.Id == id));
        }

        [Route("/admin/Comments/Update/{Id}")]
        [HttpPost]
        public IActionResult Update(int id, Comments comments)
        {
            comments.Id = id;
            ViewBag.Messages = service.Update(comments);
            return View(service.GetById(s => s.Id == id));
        }
        [Route("/admin/Comments/Delete/{Id}")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            service.Delete(s => s.Id == id);
            return Redirect("/admin/Blogs");
        }
    }
}
