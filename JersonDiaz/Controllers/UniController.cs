using JersonDiaz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using JersonDiaz.Clases;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JersonDiaz.Controllers
{
    public class UniController : Controller
    {
        string err = "";

        [HttpGet]
        public IActionResult Index()
        {
            Cliente cliente = new Cliente();

            List<SelectListItem> lsts = new List<SelectListItem>();

            lsts.Add(new SelectListItem() { Text = "--SELECCIONE--", Value = "0" });
            lsts.Add(new SelectListItem() { Text = "Masculino", Value = "M" });
            lsts.Add(new SelectListItem() { Text = "Femenino", Value = "F" });

            ViewBag.Genero = lsts;

            return View();
        }
        [HttpPost]
        public IActionResult Index(Cliente X,string Grabar)
        {
            //aqui iria para grabar

            if (Grabar == "1")
            {
                if (X.Nombre == "" || X.Nombre==null)
                {
                    err = "Debe Existir el Nombre del Cliente";
                }
                if (err != "")
                {
                    ViewBag.modal = "mostrar"; ViewBag.ModalTitulo = "Cliente"; ViewBag.ModalMsj = "Error: " + err + ""; ViewBag.ModalPie = "Datos del Cliente";
                }


                if (Grabar == "1" & err == "")
                {
                    try
                {
                //var sql = "EXEC [PLD_CARGA_MASIVA] '" + UploadedfileName + "','" + USR + "'";
                //DB.Database.ExecuteSqlCommand(sql);

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Ocurrio un Error al Grabar: ", e);

            }

                }

            }

            return RedirectToAction("Index", "Home");

            //return View();
        }


    }
}
