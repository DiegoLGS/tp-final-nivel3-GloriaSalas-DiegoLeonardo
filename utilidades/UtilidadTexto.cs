using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace utilidades
{
    public static class UtilidadTexto
    {
        public static bool comprobarLargoTexto(Dictionary<TextBox, int> largoMaximos, Label lblAviso)
        {
            bool largosValidados = true;

            foreach (var par in largoMaximos)
            {
                string texto = par.Key.Text;
                int limite = par.Value;

                if (texto.Length > limite)
                {
                    largosValidados = false;
                    par.Key.CssClass = "form-control is-invalid";
                }
            }

            if (!largosValidados)
            {
                lblAviso.Text = "*Límites de caracteres excedido";
            }

            return largosValidados;
        }

        public static bool comprobarCampos(TextBox[] textBoxes, Label lblAviso)
        {
            bool camposValidados = true;

            foreach (TextBox textBox in textBoxes)
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    camposValidados = false;
                    textBox.CssClass = "form-control is-invalid";
                    lblAviso.Text = "*Debe completar todos los campos";
                }
                else
                {
                    textBox.CssClass = "form-control is-valid";
                }
            }            

            return camposValidados;
        }

        public static bool validarEmail(TextBox email, Label lblAviso)
        {
            string patron = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

            if (!Regex.IsMatch(email.Text, patron))
            {
                email.CssClass = "form-control is-invalid";
                lblAviso.Text = "*El mail debe tener un formato válido";

                return false;
            }
            else
            {
                email.CssClass = "form-control is-valid";

                return true;
            }

        }
    }
}
