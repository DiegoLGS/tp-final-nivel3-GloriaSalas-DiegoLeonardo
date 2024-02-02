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
            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario usuario = new Usuario(txtEmail.Text, txtPassword.Text, false);

            try
            {
                if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    lblAviso.Text = "*Debes completar ambos campos";
                }
                else
                {
                    if (negocio.Login(usuario))
                    {
                        Session.Add("usuario", usuario);

                        if (((Usuario)Session["usuario"]).Admin)
                        {
                            Response.Redirect("AdministrarArticulos.aspx", false);
                        }
                        else
                        {
                            Response.Redirect("Default.aspx", false);
                        }
                    }
                    else
                    {
                        lblAviso.Text = "*No existe un usuario registrado con ese email y/o contraseña";
                    }

                }

            }
            //catch (ThreadAbortException ex) { }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}