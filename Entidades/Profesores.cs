using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Profesores
    {
        [Key]
        public int ProfesorId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Tanda { get; set; }

        public Profesores()
        {

        }

        public Profesores(int id, string nombre, string apellido, string tanda)
        {
            this.ProfesorId = id;
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.Tanda = tanda;

        }

    }
}
