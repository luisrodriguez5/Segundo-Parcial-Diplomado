using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ColegioParcial
{
    public class Utilidades
    {
        public static int TOINT(string num)
        {
            int numero = 0;
            int.TryParse(num, out numero);
            return numero;
        }

        public static DateTime ToDateTime(string texto)
        {
            DateTime fecha = new DateTime(1, 1, 1);
            DateTime.TryParse(texto, out fecha);
            return fecha;
        }



        public static decimal TODECIMAL(string num)
        {
            decimal numero = 0;
            decimal.TryParse(num, out numero);
            return numero;
        }
    }
}