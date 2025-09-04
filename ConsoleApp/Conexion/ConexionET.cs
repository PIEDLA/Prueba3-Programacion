using System.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ConsoleApp.Conexion;



namespace ConsoleApp.Conexion
{
    public class ConexionET
    {
        private String cadena_conexion = "server=DESKTOP-P48H2HL\\SQLEXPRESS;database=db_cinema;Integrated Security=True;TrustServerCertificate=true";

        public void CargarCinemas()
        {
            var conexion = new Conexion();

            conexion.Cadena_Conexion = cadena_conexion;

            var lista = conexion.Cinemas!.ToList();

            foreach (var elemento in lista)
            {
                Console.WriteLine(elemento.Id + ", " + elemento.Nombre);
            }
        }
    }



    public class Conexion : DbContext
    {
        public string? Cadena_Conexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.Cadena_Conexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Cinemas>? Cinemas { get; set; }
    }
}