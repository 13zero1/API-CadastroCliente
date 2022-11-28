using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AplicacaoCliente.Models;

namespace AplicacaoCliente.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() 
        {
            ClientModel objClient = new ClientModel();
            ViewBag.ClientList = objClient.AllListClient();

            return View();
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Registrar(ClientModel dados)
        {
            dados.Inserir();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
