using dominio;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using utilidades;

namespace tienda_web
{
    public partial class MiMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!UtilidadLogin.sesionActiva(Session["usuario"]))
            {
                if (Page is AdministrarArticulos || Page is Favoritos || Page is FormularioArticulo || Page is MiPerfil)
                    Response.Redirect("Login.aspx", false);
            }
            else
            {                    
                Usuario usuario = (Usuario)Session["usuario"];
                lblUsuario.Text = usuario.Email;

                if (!string.IsNullOrEmpty(usuario.Imagen))
                    imgAvatar.ImageUrl = "~/Imagenes/" + usuario.Imagen;

                if(UtilidadLogin.esAdmin(usuario) && Page is Favoritos || !UtilidadLogin.esAdmin(usuario) && Page is AdministrarArticulos)
                {
                    Session.Add("error", "Esta página no está disponible para sus permisos.");
                    Response.Redirect("Error.aspx");
                }
            }

            
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Remove("usuario");
            Response.Redirect("Default.aspx");
        }
    }
}