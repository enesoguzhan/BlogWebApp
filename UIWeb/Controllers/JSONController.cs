using BusinessLayer.Abstract;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace UIWeb.Controllers
{
    [AllowAnonymous]
    public class JSONController : Controller
    {
        private readonly IInteractionsService service;
        public JSONController(IInteractionsService service)
        {
            this.service = service;
        }

        public JsonResult Index(int BlogId, bool Status)
        {
            string ipAdres = Dns.GetHostAddresses(Dns.GetHostName())[1].ToString();

            var dogrula = service.GetById(s => s.IPAddress == ipAdres && s.BlogId == BlogId);

            if (dogrula == null)
            {
                Interactions interactions = new Interactions();
                interactions.IPAddress = ipAdres;
                interactions.BlogId = BlogId;
                interactions.InteractionType = Status;
                service.Insert(interactions);
            }
            else
            {
                if (dogrula.InteractionType == true && Status == false)
                {
                    dogrula.InteractionType = false;
                }
                else if (dogrula.InteractionType == false && Status == true)
                {
                    dogrula.InteractionType = true;
                }
                service.Update(dogrula);
            }

            return Json("");

        }

        [Route("JSON/PartialGetir/{id}")]
        public IActionResult PartialGetir(int id)
        {

            return PartialView("/Views/Shared/PartialInteractions.cshtml", service.GetAllList().Where(s => s.Id == id).ToList());
        }
    }
}
