using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tienda_web
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                if (utilidades.UtilidadTexto.comprobarCampos(textBoxUsados(), lblAviso) && utilidades.UtilidadTexto.comprobarLargoTexto(largosMaximos(), lblAviso) && utilidades.UtilidadTexto.validarEmail(txtEmail, lblAviso))
                {                    
                    UsuarioNegocio negocio = new UsuarioNegocio();

                    if (!utilidades.UtilidadUsuario.comprobarEmail(txtEmail, lblAviso))
                    {
                        Usuario usuario = new Usuario(txtEmail.Text, txtPassword.Text, false);

                        usuario.Id = negocio.insertarNuevo(usuario);
                        Session.Add("usuario", usuario);

                        // Se debe proporcionar un email y password para utilizar como emisor.
                        string credencialEmail = "";
                        string credencialPassword = "";

                        if(credencialEmail != "" && credencialPassword != "")
                        {
                            ServicioEmail emailService = new ServicioEmail();
                            emailService.armarCorreo(usuario.Email, credencialEmail, credencialPassword);
                            emailService.enviarCorreo();
                        }

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
        private Dictionary<TextBox, int> largosMaximos()
        {
            return new Dictionary<TextBox, int>()
            {
                { txtEmail, 100 },
                { txtPassword, 20 }
            };
        }


    }
}