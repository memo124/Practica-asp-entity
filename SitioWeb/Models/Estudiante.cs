using System.ComponentModel.DataAnnotations;

namespace SitioWeb.Models
{
    public class Estudiante
    {
        [Key]
        public int idEstudiante { get; set; }
        public string Nombre { get; set; }
        public string ApelPaterno { get; set; }
        public string ApelMaterno { get; set; }
        public DateTime FechaInscrip { get; set; }
        public int Edad { get; set; }
    }
}
