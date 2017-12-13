using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Asignaturas
    {
        [Key]
        public int AsignaturaId { get; set; }
        public string Nombre { get; set; }
        public int Seccion { get; set; }


        public Asignaturas()
        {

        }

        public Asignaturas(int id, string nombre, int seccion)
        {
            this.AsignaturaId = id;
            this.Nombre = nombre;
            this.Seccion = seccion;

        }
    }
}
