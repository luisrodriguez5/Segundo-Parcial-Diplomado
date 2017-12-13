using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Estudiantes
    {
        [Key]

        public int EstudianteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public DateTime FechaIngreso { get; set; }
        public Estudiantes()
        {

        }

        public Estudiantes(int id, string nombre, string apellidos, string email, DateTime fecha)
        {
            this.EstudianteId = id;
            this.Nombre = nombre;
            this.Apellido = apellidos;
            this.Email = email;
            this.FechaIngreso = fecha;

        }

    }
}
