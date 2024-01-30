using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace utilidades
{
    public static class UtilidadesPrecio
    {
        public static string limitarDecimales(object precio)
        {
            if (precio != null && precio != DBNull.Value)
            {
                decimal precioDecimal = Convert.ToDecimal(precio);
                precioDecimal = Math.Truncate(100 * precioDecimal) / 100;
                string precioFormateado = precioDecimal.ToString("0.00");

                return precioFormateado;
            }
            else
            {
                return "-";
            }
        }

        public static bool noContieneSoloNumeros(string texto)
        {
            Regex regex = new Regex(@"^\d+$");

            return !regex.IsMatch(texto);
        }
    }
}
