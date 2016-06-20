using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace WebAppCoreGMQA.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Pagina de descricão da Aplicação.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Nossa página de Contato.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
