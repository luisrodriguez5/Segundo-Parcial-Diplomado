using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AsiginaturaBLL
{
    public class EstudiantesBLL
    {
        public static bool Guardar(Estudiantes estudiante)
        {
            using (var context = new Repository<Estudiantes>())
            {
                try
                {
                    if (Buscar(p => p.EstudianteId == estudiante.EstudianteId) == null)
                    {
                        return context.Guardar(estudiante);
                    }
                    else
                    {
                        return context.Modificar(estudiante);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static bool Eliminar(Estudiantes estudiantes)
        {
            using (var context = new Repository<Estudiantes>())
            {
                try
                {
                    return context.Eliminar(estudiantes);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static bool Modificar(Estudiantes estudiantes)
        {
            using (var context = new Repository<Estudiantes>())
            {
                try
                {
                    return context.Modificar(estudiantes);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static List<Estudiantes> GetList(Expression<Func<Estudiantes, bool>> criterio)
        {
            using (var context = new Repository<Estudiantes>())
            {
                try
                {
                    return context.GetList(criterio);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static List<Estudiantes> GetListAll()
        {
            using (var context = new Repository<Estudiantes>())
            {
                try
                {
                    return context.GetListAll();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static Estudiantes Buscar(Expression<Func<Estudiantes, bool>> criterio)
        {
            using (var context = new Repository<Estudiantes>())
            {
                try
                {
                    return context.Buscar(criterio);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

    }
}

