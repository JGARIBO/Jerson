namespace JersonDiaz.Clases
{
    //public class Cliente
    //{

    //public int IdCliente { get; set; }
    //public string Nombre { get; set; }
    //public string  Apellido { get; set; }
    //public string Telefono { get; set; }
    //public  string  Direccion { get; set; }
    //public string   Cedula { get; set; }

    //public string Genero { get; set; }



    //}
    
    public class ListadoClientesx
    {
        public int IdCliente { get; set; }

        public string Nombre { get; set; }
    }

   
    public class FormasPagox
    {
        public int IdFormaPago { get; set; }

        public string Descripcion { get; set; }
    }

    public class Creditox
    {
        public int IdPrestamo { get; set; }
        public int IdCliente { get; set; }

        public string Cliente { get; set; }

        public decimal Monto { get; set; }

        public string FormaPago { get; set; }

        public int Plazo { get; set; }

        public string Estado { get; set; }
    }

    public class UsuariosLogin
    {
      public int  IdUsuario { get; set; }

        public string Usuario { get; set; }

        public string Contraseña { get; set; }

        public int Estado { get; set; }

    }

    public class RecuperacionesX
    {
        public int IdCliente { get; set; }

        public int IdPrestamo { get; set; }

        public decimal MontoPagado { get; set; }

        public decimal Capital { get; set; }

        public decimal Interes { get; set; }
           
        public decimal Seguro { get; set; }

       public decimal  Deslizamiento { get; set; }

       public decimal  TotalCuota { get; set; }

      public string  FechaPago { get; set; }


    }

    public class CalendarioX
    {
        public int IdCliente { get; set; }

        public int IdPrestamo { get; set; }

        public decimal NumCuota { get; set; }

        public decimal MontoPagado { get; set; }

        public decimal Capital { get; set; }

        public decimal Interes { get; set; }

        public decimal Seguro { get; set; }

        public decimal Deslizamiento { get; set; }

        public decimal TotalCuota { get; set; }

        public string FechaPago { get; set; }

        public string Estado { get; set; }

        public decimal SaldoInicial { get; set; }

        public decimal SaldoFinal { get; set; }

       

    }

    public class ListarClientes
    {
        public int IdCliente { get; set; }

        public string Cliente { get; set; }

        
    }

    public class ListarCredit
    {
        public int IdPrestamox { get; set; }
        public string Prestamo { get; set; }
    }

}
