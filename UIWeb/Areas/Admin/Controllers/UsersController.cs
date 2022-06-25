using BusinessLayer.Abstract;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.Admin.Controllers
{
    [Area("admin")]
    public class UsersController : Controller
    {
        private readonly IUserService service;
        public UsersController(IUserService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View(service.GetAllList());
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Users users)
        {
            ViewBag.Messages = service.Insert(users);
            return View();
        }

        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }
        [Route("/admin/Users/Update/{id}")]
        [HttpPost]
        public IActionResult Update(int id, Users users)
        {
            users.Id = id;
            ViewBag.Messages = service.Update(users);
            return View(service.GetById(s => s.Id == id));
        }

        [Route("/admin/Users/Delete/{id}")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            service.Delete(s => s.Id == id);
            return Redirect("/admin/Users");
        }
    }
}
