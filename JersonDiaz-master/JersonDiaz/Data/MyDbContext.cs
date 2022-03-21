using JersonDiaz.Models;
using Microsoft.EntityFrameworkCore;
namespace JersonDiaz.Data

{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        //Constructor
        public MyDbContext(DbContextOptions<MyDbContext> options) :base(options)
        {

        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Login> Login { get; set; }

        public DbSet<Credito> Credito { get; set; }

        public DbSet<FormaPago> FormaPago { get; set; }

        public DbSet<PlanPagoGenerado> PlanPagoGenerado { get; set; }

        public DbSet<Estados> Estados { get; set; }

        public DbSet<Recuperaciones> Recuperaciones { get; set; }

        public DbSet<CalendarioPago> CalendarioPago { get; set; }

    }
}
