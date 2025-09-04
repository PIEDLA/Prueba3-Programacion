using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Conexion
{
    public class Cinemas
    {
        [Key] public int Id { get; set; }
        public String? Nombre { get; set; }

        [NotMapped] public ICollection<Salas>? Salas { get; set; }
    }

    public class Salas
    {
        [Key] public int Id { get; set; }
        public String? Nombre { get; set; }
        public int Cinema { get; set; }
        public DateTime Fecha { get; set; }
        public bool Activo{ get; set; }
        public decimal Area { get; set; }

        [ForeignKey("Cinema")] public Cinemas? _Cinema { get; set; }
    }
}