using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tienda_web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if(utilidades.UtilidadTexto.comprobarCampos(textBoxUsados(), lblAviso))
                {
                    Usuario usuario = new Usuario(txtEmail.Text, txtPassword.Text, false);

                    if (utilidades.UtilidadUsuario.logearUsuario(usuario, txtEmail, txtPassword, lblAviso))
                    {
                        Session.Add("usuario", usuario);

                        if (((Usuario)Session["usuario"]).Admin)
                            Response.Redirect("AdministrarArticulos.aspx", false);
                        else
                            Response.Redirect("Default.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        private TextBox[] textBoxUsados()
        {
            return new TextBox[]
            {
                txtEmail,
                txtPassword
            };
        }
    }
}