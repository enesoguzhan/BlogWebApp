using BusinessLayer.Abstract;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.Admin.Controllers
{
    [Area("admin")]
    public class BlogsController : Controller
    {
        private readonly IBlogService service;
        public BlogsController(IBlogService service)
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
        public IActionResult Insert(Blogs blogs, IFormFile file)
        {
            blogs.UsersId = 1;
            if (file != null)
            {
                string dosyaUzanti = Path.GetExtension(file.FileName);
                string[] uzantilar = { ".jpg", ".jpeg", ".png" };
                if (uzantilar.Contains(dosyaUzanti))
                {
                    string rastgele = Guid.NewGuid() + dosyaUzanti;
                    string kayitYolu = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{rastgele}");
                    using (var Stream = new FileStream(kayitYolu, FileMode.Create))
                    {
                        file.CopyTo(Stream);
                    }
                    blogs.Images = rastgele;
                    ViewBag.Messages = service.Insert(blogs);
                }
                else
                {
                    ViewBag.Error = "Lütfen Jpg,Jpeg veya Png uzantılı dosya seçiniz.";
                }
            }
            else
            {
                ViewBag.Error = "Lütfen Dosya Seçiniz";
            }

            return View();
        }

        [Route("/admin/Blogs/Update/{id}")]
        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(service.GetById(s => s.Id == id));
        }

        [Route("/admin/Blogs/Update/{id}")]
        [HttpPost]
        public IActionResult Update(int id, Blogs blogs, IFormFile file)
        {
            blogs.Id = id;
            if (file != null)
            {
                string dosyaUzanti = Path.GetExtension(file.FileName);
                string[] uzantilar = { ".jpg", ".jpeg", ".png" };
                if (uzantilar.Contains(dosyaUzanti))
                {
                    string rastgele = Guid.NewGuid() + dosyaUzanti;
                    string kayitYolu = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{rastgele}");
                    using (var Stream = new FileStream(kayitYolu, FileMode.Create))
                    {
                        file.CopyTo(Stream);
                    }
                    blogs.Images = rastgele;
                    ViewBag.Messages = service.Update(blogs);
                }
                else
                {
                    ViewBag.Error = "Lütfen Jpg,Jpeg veya Png uzantılı dosya seçiniz.";
                }
            }
            else
            {
                ViewBag.Messages = service.Update(blogs);

            }
            return View(service.GetById(s => s.Id == id));
        }

        [Route("/admin/Blogs/Delete/{id}")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            service.Delete(s => s.Id == id);
            return Redirect("/admin/Blogs");
        }
    }
}
