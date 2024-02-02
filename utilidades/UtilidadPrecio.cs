using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace utilidades
{
    public static class UtilidadPrecio
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

        public static bool noContieneSoloNumerosOComa(string texto)
        {
            Regex regex = new Regex(@"^\d+(,\d+)?$");

            return !regex.IsMatch(texto);
        }
    }
}
