using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProfesoresBLL
    {
        public static bool Guardar(Profesores profesor)
        {
            using (var context = new Repository<Profesores>())
            {
                try
                {
                    if (Buscar(p => p.ProfesorId == profesor.ProfesorId) == null)
                    {
                        return context.Guardar(profesor);
                    }
                    else
                    {
                        return context.Modificar(profesor);
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

        public static List<Profesores> GetList(Expression<Func<Profesores, bool>> criterio)
        {
            using (var context = new Repository<Profesores>())
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

        public static List<Profesores> GetListAll()
        {
            using (var context = new Repository<Profesores>())
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

        public static Profesores Buscar(Expression<Func<Profesores, bool>> criterio)
        {
            using (var context = new Repository<Profesores>())
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
