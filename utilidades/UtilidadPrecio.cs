using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

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
                string precioFormateado = precioDecimal.ToString("N2");

                return precioFormateado;
            }
            else
            {
                return "-";
            }
        }

        public static bool noContieneSoloNumerosOComa(TextBox textoAComprobar, Label lblAviso)
        {
            Regex regex = new Regex(@"^\d+(,\d+)?$");

            if (!regex.IsMatch(textoAComprobar.Text))
            {
                textoAComprobar.CssClass = "form-control is-invalid";
                lblAviso.Text = "*Solo se admiten números y una coma";

                return true;
            }
            else
            {
                textoAComprobar.CssClass = "form-control is-valid";

                return false;
            }            
        }

        public static bool noContieneSoloNumeros(TextBox textoAComprobar, Label lblAviso)
        {
            Regex regex = new Regex(@"^\d+$");

            if (!regex.IsMatch(textoAComprobar.Text))
            {
                textoAComprobar.CssClass = "form-control is-invalid";
                lblAviso.Text = "*Solo se admiten números";

                return true;
            }
            else
            {
                textoAComprobar.CssClass = "form-control is-valid";

                return false;
            }
        }
    }
}
