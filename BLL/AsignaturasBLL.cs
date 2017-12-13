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
    public class AsignatusraBLL
    {
        public static bool Guardar(Asignaturas asignaturas)
        {
            using (var context = new Repository<Asignaturas>())
            {
                try
                {
                    if (Buscar(p => p.AsignaturaId== asignaturas.AsignaturaId) == null)
                    {
                        return context.Guardar(asignaturas);
                    }
                    else
                    {
                        return context.Modificar(asignaturas);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }


        public static bool Modificar(Asignaturas asignaturas)
        {
            using (var context = new Repository<Asignaturas>())
            {
                try
                {
                    return context.Modificar(asignaturas);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static List<Asignaturas> GetList(Expression<Func<Asignaturas, bool>> criterio)
        {
            using (var context = new Repository<Asignaturas>())
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

        public static List<Asignaturas> GetListAll()
        {
            using (var context = new Repository<Asignaturas>())
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

        public static Asignaturas Buscar(Expression<Func<Asignaturas, bool>> criterio)
        {
            using (var context = new Repository<Asignaturas>())
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
