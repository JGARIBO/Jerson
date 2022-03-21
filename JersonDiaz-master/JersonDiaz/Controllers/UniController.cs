using JersonDiaz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using JersonDiaz.Clases;
using Microsoft.AspNetCore.Mvc.Rendering;
using JersonDiaz.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Nest;



namespace JersonDiaz.Controllers
{
    public class UniController : Controller
    {
        private readonly ILogger<UniController> _logger;
        private readonly MyDbContext _context;
        database_access_layer.db dbop = new database_access_layer.db();
        string err = "";

        public UniController(ILogger<UniController> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            Clases.UsuariosLogin Autenticacion = new Clases.UsuariosLogin();
            HttpContext.Session.SetInt32("IdUsuario", 0);
      

            return View(Autenticacion);
        }

        [HttpPost]
        public IActionResult Login(UsuariosLogin X)
        {
            var v_id_usuario = _context.Login.Where(xu => xu.Usuario.Equals(X.Usuario) && xu.Contraseña.Equals(X.Contraseña)).FirstOrDefault();

            if (v_id_usuario != null)
            {
                HttpContext.Session.SetInt32("IdUsuario", v_id_usuario.IdUsuario);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                err = "Usuario o Contraseña Invalido";
                ViewBag.modal = "mostrar"; ViewBag.ModalTitulo = "Autenticacion"; ViewBag.ModalMsj = "Error: " + err + ""; ViewBag.ModalPie = "Datos del Usuario";

                return View();
            }


        }
        [HttpGet]
        public IActionResult ListarClientes()
        {
        
            if (HttpContext.Session.GetInt32("IdUsuario") == 0 || HttpContext.Session.GetInt32("IdUsuario") == null) { return RedirectToAction("Login", "Uni"); }

            ViewBag.ListaClientes = _context.Cliente.ToList();

            return View();
        }



        [HttpGet]
        public IActionResult Cliente(string tipo, int ? IdCliente)
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == 0 || HttpContext.Session.GetInt32("IdUsuario") == null) { return RedirectToAction("Login", "Uni"); }
            Cliente cliente = new Cliente();
            if (tipo == "1")
            {


                List<SelectListItem> lsts = new List<SelectListItem>();

                lsts.Add(new SelectListItem() { Text = "--SELECCIONE--", Value = "0" });
                lsts.Add(new SelectListItem() { Text = "Masculino", Value = "M" });
                lsts.Add(new SelectListItem() { Text = "Femenino", Value = "F" });

                ViewBag.Genero = lsts;
            }
            if (tipo == "2" || tipo=="3")
            {
                var p = _context.Cliente.Where(xu => xu.IdCliente.Equals(IdCliente)).FirstOrDefault();

                List<SelectListItem> lsts = new List<SelectListItem>();

                lsts.Add(new SelectListItem() { Text = "--SELECCIONE--", Value = "0" });
                lsts.Add(new SelectListItem() { Text = "Masculino", Value = "M" });
                lsts.Add(new SelectListItem() { Text = "Femenino", Value = "F" });

                ViewBag.Genero = lsts;

                cliente.IdCliente = p.IdCliente;
                cliente.Nombre = p.Nombre;
                cliente.Apellido = p.Apellido;
                cliente.Telefono = p.Telefono;
                cliente.Direccion = p.Direccion;
                cliente.Cedula = p.Cedula;
                cliente.Genero = p.Genero;
                
            }


            HttpContext.Session.SetString("Tipo", tipo);

            if (tipo == "1" || tipo=="")
            {
                ViewBag.Boton = "Grabar";
            }
            if (tipo == "2")
            {
                ViewBag.Boton = "Actualizar";
            }
            if (tipo == "3" || tipo=="")
            {
                ViewBag.Boton = "Eliminar";
            }

            return View(cliente);
        }
        [HttpPost]
        public IActionResult Cliente(Cliente X,string Grabar)
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == 0 || HttpContext.Session.GetInt32("IdUsuario") == null) { return RedirectToAction("Login", "Uni"); }
            //aqui iria para grabar

            var Tipo = HttpContext.Session.GetString("Tipo");

            if (Grabar == "1")
            {
                if (X.Nombre == "" || X.Nombre == null)
                {
                    err = "Debe Existir el Nombre del Cliente";
                }
                if (err != "")
                {
                    ViewBag.modal = "mostrar"; ViewBag.ModalTitulo = "Cliente"; ViewBag.ModalMsj = "Error: " + err + ""; ViewBag.ModalPie = "Datos del Cliente";
                }



                try
                {
                    if (Grabar == "1" & err == "" & Tipo == "1")
                    {
                        var Fecha = DateTime.Now;
                        var IdUsuario = HttpContext.Session.GetInt32("IdUsuario");
                        _context.Cliente.Add(X);
                        _context.SaveChanges();
                      

                    }
                    if (Grabar == "1" & err == "" & Tipo == "2")
                    {
                        var Fecha = DateTime.Now;
                        var IdUsuario = HttpContext.Session.GetInt32("IdUsuario");
                        _context.Cliente.Update(X);
                        _context.SaveChanges();
                      

                    }
                    if (Grabar == "1" & err == "" & Tipo == "3")
                    {
                        var Fecha = DateTime.Now;
                        var IdUsuario = HttpContext.Session.GetInt32("IdUsuario");
                        _context.Cliente.Remove(X);
                        _context.SaveChanges();
                       

                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Ocurrio un Error al Grabar: ", e);

                }
            
                

            }

            return RedirectToAction("ListarClientes", "Uni");

            //return View();
        }

        [HttpGet]
        public IActionResult ListarCredito()
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == 0 || HttpContext.Session.GetInt32("IdUsuario") == null) { return RedirectToAction("Login", "Uni"); }

            var sql = (from p in _context.Credito
                       join co in _context.FormaPago on p.IdFormaPago equals co.IdFormaPago
                       join cl in _context.Cliente on p.IdCliente equals cl.IdCliente
                       join es in _context.Estados on p.Estado equals es.IdEstado
                       //where co.IdPais == pais && co.IdEmpresa == Empresa && co.IdRol == Rol && p.Estado == true

                       select new Creditox
                       {
                           IdPrestamo = p.IdPrestamo,
                           IdCliente=p.IdCliente,
                           Cliente = cl.Nombre+" "+cl.Apellido,
                           Monto = p.Monto,
                           FormaPago = co.Descripcion,
                           Plazo = p.Plazo,
                            Estado =  es.Descripcion

                       }).ToList();

            ViewBag.ListaCreditos = sql.ToList();


            return View();
        }

        [HttpGet]
        public IActionResult Credito(string tipo, int? IdPrestamo)
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == 0 || HttpContext.Session.GetInt32("IdUsuario") == null) { return RedirectToAction("Login", "Uni"); }
            HttpContext.Session.SetString("Tipo", tipo);

            if (tipo == "1" || tipo == "")
            {
                ViewBag.Boton2 = "Grabar";
            }
            if (tipo == "2")
            {
                ViewBag.Boton2 = "Actualizar";
            }
            if (tipo == "3" || tipo == "")
            {
                ViewBag.Boton2 = "Eliminar";
            }

            Credito Credito = new Credito();
            if (tipo == "1")
            {
                var sqls = (from p in _context.Cliente
                          
                           //where co.IdPais == pais && co.IdEmpresa == Empresa && co.IdRol == Rol && p.Estado == true

                           select new ListadoClientesx
                           {
                              
                               IdCliente = p.IdCliente,
                               Nombre = p.Nombre
                               

                           }).ToList();
                    
                ViewBag.Cl= sqls.ToList();
                ViewBag.checkcl = 0;
                ///
                var sqlss = (from p in _context.FormaPago

                                //where co.IdPais == pais && co.IdEmpresa == Empresa && co.IdRol == Rol && p.Estado == true

                            select new FormasPagox
                            {

                                IdFormaPago = p.IdFormaPago,
                                Descripcion = p.Descripcion


                            }).ToList();

                ViewBag.Cf = sqlss.ToList();
                ViewBag.checkcf = 0;

                //Dejo vacio el viewbag
                var Fecha = DateTime.Now;
                var IdUsuario = HttpContext.Session.GetInt32("IdUsuario");
                var s = "EXEC [dbo].[PLAN_PAGO] '" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 2 + "','" + Fecha + "','" + 0 + "','" + IdUsuario + "'";
                ViewBag.t = null;//_context.PlanPagoGenerado.FromSqlRaw(s).ToList();
               



            }
            if (tipo == "2" || tipo == "3")
            {
                var p = _context.Credito.Where(xu => xu.IdPrestamo.Equals(IdPrestamo)).FirstOrDefault();

                Credito.IdPrestamo = p.IdPrestamo;
                Credito.IdCliente = p.IdCliente;
                Credito.Interes = p.Interes;
                Credito.Seguro = p.Seguro;
                Credito.Deslizamiento = p.Deslizamiento;
                Credito.Monto = p.Monto;
                Credito.IdFormaPago = p.IdFormaPago;
                Credito.Plazo = p.Plazo;
                Credito.Mora = p.Mora;
                Credito.FechaCreacion = p.FechaCreacion;


                var sqls = (from pS in _context.Cliente

                                //where co.IdPais == pais && co.IdEmpresa == Empresa && co.IdRol == Rol && p.Estado == true

                            select new ListadoClientesx
                            {

                                IdCliente = pS.IdCliente,
                                Nombre = pS.Nombre


                            }).ToList();

                ViewBag.Cl = sqls.ToList();
                ViewBag.checkcl = p.IdCliente;
                ///
                var sqlss = (from pS in _context.FormaPago

                                 //where co.IdPais == pais && co.IdEmpresa == Empresa && co.IdRol == Rol && p.Estado == true

                             select new FormasPagox
                             {

                                 IdFormaPago = pS.IdFormaPago,
                                 Descripcion = pS.Descripcion


                             }).ToList();

                ViewBag.Cf = sqlss.ToList();
                ViewBag.checkcf = p.IdFormaPago;

            }

          

            return View(Credito);

            
        }
        //Este pos es asincrono hago uso de un model para obtener mi action result en un viewbag y pasarlo a mi vista
        [HttpPost]
        [Obsolete]
        public async  Task<IActionResult> Credito(Credito X, string Grabar)
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == 0 || HttpContext.Session.GetInt32("IdUsuario") == null) { return RedirectToAction("Login", "Uni"); }
            var Tipo = HttpContext.Session.GetString("Tipo");
            var IdUsuario = HttpContext.Session.GetInt32("IdUsuario");

            //BOTON
            if (Tipo == "1" || Tipo == "")
            {
                ViewBag.Boton2 = "Grabar";
            }
            if (Tipo == "2")
            {
                ViewBag.Boton2 = "Actualizar";
            }
            if (Tipo == "3" || Tipo == "")
            {
                ViewBag.Boton2 = "Eliminar";
            }

            var sqls = (from p in _context.Cliente

                                //where co.IdPais == pais && co.IdEmpresa == Empresa && co.IdRol == Rol && p.Estado == true

                            select new ListadoClientesx
                            {

                                IdCliente = p.IdCliente,
                                Nombre = p.Nombre


                            }).ToList();

                ViewBag.Cl = sqls.ToList();
                ViewBag.checkcl = X.IdCliente;
                ///
                var sqlss = (from p in _context.FormaPago

                                 //where co.IdPais == pais && co.IdEmpresa == Empresa && co.IdRol == Rol && p.Estado == true

                             select new FormasPagox
                             {

                                 IdFormaPago = p.IdFormaPago,
                                 Descripcion = p.Descripcion


                             }).ToList();

                ViewBag.Cf = sqlss.ToList();
                ViewBag.checkcf = X.IdFormaPago;

             
                 DateTime Fecha = Convert.ToDateTime(X.FechaCreacion);
                string d = Fecha.Day.ToString(); string m = Fecha.Month.ToString();
                //if (d.Length == 1) { d = "0" + d; }
                //if (m.Length == 1) { m = "0" + m; }
                //Session["FEC_SISTEMA"] = d + "-" + m + "-" + Fecha.Year.ToString();

                //proveso de validacion
                if (X.IdCliente == 0)
                {
                    err = "Debe Seleccinar el Cliente";

                }
                if (err != "")
                {
                    ViewBag.modal = "mostrar"; ViewBag.ModalTitulo = "Validacion"; ViewBag.ModalMsj = "Error: " + err + ""; ViewBag.ModalPie = "Credito";
                }
                else
                if (X.Monto <= 0)
                {
                    err = "Debe Ingresar el Monto";

                }
                if (err != "")
                {
                    ViewBag.modal = "mostrar"; ViewBag.ModalTitulo = "Validacion"; ViewBag.ModalMsj = "Error: " + err + ""; ViewBag.ModalPie = "Credito";
                }
                else
                 if (X.Interes <= 0)
                {
                    err = "Debe Ingresar el Porcentaje de Interes";

                }
                if (err != "")
                {
                    ViewBag.modal = "mostrar"; ViewBag.ModalTitulo = "Validacion"; ViewBag.ModalMsj = "Error: " + err + ""; ViewBag.ModalPie = "Credito";
                }
                else
                 if (X.Plazo <= 0)
                {
                    err = "Debe Ingresar el Plazo";

                }
                if (err != "")
                {
                    ViewBag.modal = "mostrar"; ViewBag.ModalTitulo = "Validacion"; ViewBag.ModalMsj = "Error: " + err + ""; ViewBag.ModalPie = "Credito";
                }
                else
                    // if (X.FechaCreacion == null)
                    //{
                    //    err = "Debe Ingresar la Fecha";

                    //}
                    //if (err != "")
                    //{
                    //    ViewBag.modal = "mostrar"; ViewBag.ModalTitulo = "Validacion"; ViewBag.ModalMsj = "Error: " + err + ""; ViewBag.ModalPie = "Credito";
                    //}
                    //else
                if (Grabar == "2" )
                  {
                try
                {
                   

                    var s = "EXEC [dbo].[PLAN_PAGO] '" + X.Monto + "','" + X.Interes + "','" + X.Seguro + "','" + X.Mora + "','" + X.Deslizamiento + "','" + X.Plazo + "','" + Fecha + "','" + X.IdFormaPago + "','" + IdUsuario +  "'";
                    //ViewBag.t = _context.PlanPagoGenerado.FromSqlRaw(s).ToList();
                    ViewBag.t = await _context.PlanPagoGenerado.FromSqlRaw(s).ToListAsync();
                }
                catch (Exception e)
                {
                    err = "Ocurrio un Error al Generar el Plan de Pagos: " + e;
                    ViewBag.modal = "mostrar"; ViewBag.ModalTitulo = "Credito"; ViewBag.ModalMsj = "Error: " + err + ""; ViewBag.ModalPie = "Modulo de Credito";

                }
                return View(X);
            }
            else
                if (Grabar == "1")
               {
                try
                {
                   

                    var s = "EXEC GrabarCredito '" + X.IdPrestamo +"','" + X.IdCliente + "','" + X.Monto + "','" + X.IdFormaPago + "','" + X.Plazo + "','" + X.Interes + "','" + X.Seguro + "','" + X.Mora + "','" + X.Deslizamiento + "','" + Fecha + "','" + IdUsuario + "','"+ Tipo + "'";

                    var afectados = _context.Database.ExecuteSqlCommand(s);
                }
                catch (Exception e)
                {
                    err = "Ocurrio un Error al Grabar el Credito: " + e;
                    ViewBag.modal = "mostrar"; ViewBag.ModalTitulo = "Credito"; ViewBag.ModalMsj = "Error: " + err + ""; ViewBag.ModalPie = "Modulo de Credito";

                }
                return RedirectToAction("ListarCredito", "Uni");
            }

            return  View(X);
        }

        [HttpGet]
        public   IActionResult Recuperaciones()
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == 0 || HttpContext.Session.GetInt32("IdUsuario") == null) { return RedirectToAction("Login", "Uni"); }

            RecuperacionesX X = new RecuperacionesX();

            var sql = (from p in _context.Cliente

                           select new ListarClientes
                           {
                               IdCliente = p.IdCliente,
                               Cliente = p.Cedula + "=>" + p.Nombre + " " + p.Apellido


                           }).ToList();

        
                ViewBag.Cls = sql.ToList();
                ViewBag.checkCl = 0;


            return  View(X);

        }

        [HttpPost]
        [Obsolete]
        public  IActionResult Recuperaciones(RecuperacionesX X,string Grabar)
        {

            if (HttpContext.Session.GetInt32("IdUsuario") == 0 || HttpContext.Session.GetInt32("IdUsuario") == null) { return RedirectToAction("Login", "Uni"); }
            var IdUsuario = HttpContext.Session.GetInt32("IdUsuario");



            var sql = (from p in _context.Cliente

                       select new ListarClientes
                       {
                           IdCliente = p.IdCliente,
                           Cliente = p.Cedula + "=>" + p.Nombre + " " + p.Apellido


                       }).ToList();


            ViewBag.Cls = sql.ToList();
            ViewBag.checkCl = X.IdCliente;

            if (X.MontoPagado <= 0)
            {
                err = "Debe Ingresar el Monto a Pagar";

            }
            if (err != "")
            {
                ViewBag.modal = "mostrar"; ViewBag.ModalTitulo = "Validacion"; ViewBag.ModalMsj = "Error: " + err + ""; ViewBag.ModalPie = "Recuperaciones";
            }
            else
             if (X.IdPrestamo <= 0)
            {
                err = "Debe Cargar el Numero de Credico";

            }
            if (err != "")
            {
                ViewBag.modal = "mostrar"; ViewBag.ModalTitulo = "Validacion"; ViewBag.ModalMsj = "Error: " + err + ""; ViewBag.ModalPie = "Recuperaciones";
            }
            else
             if (X.TotalCuota <= 0)
            {
                err = "Debe Existir Monto Pendiente de Pago";

            }
            if (err != "")
            {
                ViewBag.modal = "mostrar"; ViewBag.ModalTitulo = "Validacion"; ViewBag.ModalMsj = "Error: " + err + ""; ViewBag.ModalPie = "Recuperaciones";
            }
            else
                  if (Grabar == "1")
            {
                try
                {


                    var s = "EXEC GrabarAbono '" + X.IdPrestamo + "','" + X.MontoPagado + "','" + IdUsuario + "'";

                    var afectados =  _context.Database.ExecuteSqlCommand(s);
                }
                catch (Exception e)
                {
                    err = "Ocurrio un Error al Grabar el Credito: " + e;
                    ViewBag.modal =  "mostrar"; ViewBag.ModalTitulo = "Recuperacion"; ViewBag.ModalMsj = "Error: " + err + ""; ViewBag.ModalPie = "Modulo de Credito";

                }
                return RedirectToAction("Recuperaciones", "Uni");
            }


            return View();
        }

        //peticiones ajax
        [HttpGet]
        public JsonResult PrestamosCliente(int? ClienteId = 0)
        {
           
            DataSet ds = dbop.GetPrestamos(ClienteId); 
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new SelectListItem { Text = dr["Prestamo"].ToString(), Value = dr["IdPrestamo"].ToString() });
            }



            return Json(list);
        }
        //peticiones ajax
        [HttpPost]
        public IActionResult PrestamosClienteDeuda(int? IdPrestamo = 0)
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == 0 || HttpContext.Session.GetInt32("IdUsuario") == null) { return RedirectToAction("Login", "Uni"); }
            //instancio mi clase    
            RecuperacionesX Credito = new RecuperacionesX();

            //seteo la fecha a tipo de dato datetime
           var Fec = DateTime.Now.ToShortDateString();
            DateTime Fecc = Convert.ToDateTime(Fec);

            //setencia linq aqui cargo todo lo pendiente de pago segun fecha de pago hacia atras si existe cuotas no pagadas
            // ya que puede ser una o mas cuotas
            var Resultado = (from p in _context.CalendarioPago
                            where p.IdPrestamo == IdPrestamo && p.Estado=="P" && p.FechaPago<= Fecc
                            orderby p.NumCuota ascending
                            select new RecuperacionesX
                            {
                               
                                Capital = p.Capital,
                                Interes = p.Interes,
                                Seguro = p.Seguro,
                                Deslizamiento = p.Deslizamiento,
                                TotalCuota = p.TotalCuota,
                                MontoPagado = p == null ? 0 : p.MontoPagado, //si viene null me ponga un 0 caso contrario el monto
                                FechaPago = Convert.ToString(p.FechaPago.ToString("dd/MM/yyyy"))//seteo la fecha
                               

                            });


            //lleno mediante suma todo lo pendiente de pago
            if (Resultado != null) {


                //leo unica mente la fecha y la paso a mi clase
                foreach (var obj in Resultado)
                {
                    Credito.FechaPago = obj.FechaPago;
                    
                }

                decimal Capital = Resultado.Sum(elemento => elemento.Capital);
                decimal Seguro = Resultado.Sum(elemento => elemento.Seguro);
                decimal Interes = Resultado.Sum(elemento => elemento.Interes);
                decimal Deslizamiento = Resultado.Sum(elemento => elemento.Deslizamiento);
                decimal TotalCuota = Resultado.Sum(elemento => elemento.TotalCuota);
                decimal MontoPagado = Resultado.Sum(elemento => elemento.MontoPagado);

                Credito.Seguro = Seguro;
                Credito.IdPrestamo = Convert.ToInt32(IdPrestamo);
                Credito.Capital = Capital;
                Credito.Interes = Interes;
                Credito.Deslizamiento = Deslizamiento;
                Credito.TotalCuota = TotalCuota-MontoPagado;
                
            }


            return Json(new { Credito.Seguro, Credito.IdPrestamo, Credito.Capital, Credito.Interes , Credito.Deslizamiento, Credito.TotalCuota, Credito.FechaPago });
        }

        [HttpGet]
        public IActionResult VerCalendario (int ? IdPrestamo=0)
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == 0 || HttpContext.Session.GetInt32("IdUsuario") == null) { return RedirectToAction("Login", "Uni"); }
            ViewBag.Calendario = (from p in _context.CalendarioPago
                             where p.IdPrestamo == IdPrestamo 
                             orderby p.NumCuota ascending
                             select new CalendarioX
                             {
                                 NumCuota=p.NumCuota,
                                 Capital = p.Capital,
                                 Interes = p.Interes,
                                 Seguro = p.Seguro,
                                 Deslizamiento = p.Deslizamiento,
                                 TotalCuota = p.TotalCuota,
                                 SaldoFinal=p.SaldoFinal,
                                 SaldoInicial=p.SaldoInicial,
                                 MontoPagado = p == null ? 0 : p.MontoPagado, //si viene null me ponga un 0 caso contrario el monto
                                 FechaPago = Convert.ToString(p.FechaPago.ToString("dd/MM/yyyy")),//seteo la fecha
                                 Estado=p.Estado=="P" ? "Pendiente" : "Pagado"

                             });


            return View();
        }




}
}
