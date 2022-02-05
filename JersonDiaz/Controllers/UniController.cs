using JersonDiaz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using JersonDiaz.Clases;

namespace JersonDiaz.Controllers
{
    public class UniController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            Cliente cliente = new Cliente();

            return View();
        }
        [HttpPost]
        public IActionResult Index(Cliente X)
        {
            //aqui iria para grabar




            return View();
        }


    }
}
