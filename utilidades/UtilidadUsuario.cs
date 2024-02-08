using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace utilidades
{
    public static class UtilidadUsuario
    {
        public static bool comprobarEmail(TextBox email, Label lblAviso)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();

            if(!negocio.existeUsuario(email.Text))
            {
                return false;
            }
            else
            {
                lblAviso.Text = "*Ya existe un usuario registrado con ese email";
                email.CssClass = "form-control is-invalid";

                return true;
            }
        }

        public static bool logearUsuario(Usuario usuario, TextBox email, TextBox password, Label lblAviso) 
        {
            UsuarioNegocio negocio = new UsuarioNegocio();

            if (negocio.Login(usuario))
            {
                return true;
            }
            else
            {
                lblAviso.Text = "*No existe un usuario registrado con ese email y/o contraseña";
                email.CssClass = "form-control";
                password.CssClass = "form-control";

                return false;
            }        
        }
    }
}
