using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ColegioDb : DbContext
    {
        public ColegioDb() : base("ConStr")
        {

        }

        public DbSet<Estudiantes> Estudiante { get; set; }
        public DbSet<Asignaturas> Asignatura { get; set; }
        public DbSet<Profesores> Profesore  { get; set; }

    }
}
