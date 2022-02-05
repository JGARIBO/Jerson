using JersonDiaz.Models;
using Microsoft.EntityFrameworkCore;
namespace JersonDiaz.Data

{
    public class MyDbContext : DbContext
    {
        //Constructor
        public MyDbContext(DbContextOptions<MyDbContext> options) :base(options)
        {

        }
        public DbSet<Cliente> Cliente { get; set; }

    }
}
