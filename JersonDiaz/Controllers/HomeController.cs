using JersonDiaz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WEB_Core_Conv2.Models;

namespace JersonDiaz.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            //Simular los datos como que estoy usando base de datos

            List<Paciente> pacientes = new List<Paciente>();

            pacientes.Add(new Paciente()
            {
                Nombre = "Jorge Urbina",
                Direccion = "Alguna direccion",
                Edad = 33,
                Telefono = "12345678"
            });

            pacientes.Add(new Paciente()
            {
                Nombre = "Otro Nombre",
                Direccion = "Otra direccion",
                Edad = 20,
                Telefono = "454545454"
            });

            return View(pacientes);
        }
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Prueba()
        {
            ViewBag.prueba = "Prueba de Jerson en Nueva Vista";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
