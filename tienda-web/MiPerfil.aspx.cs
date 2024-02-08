using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using utilidades;

namespace tienda_web
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Usuario usuario = (Usuario)Session["usuario"];

                    if (!string.IsNullOrEmpty(usuario.Imagen))
                    {
                        string rutaImagen = Server.MapPath("~/Imagenes/" + usuario.Imagen);

                        if(System.IO.File.Exists(rutaImagen))
                            imgAvatar.ImageUrl = "~/Imagenes/" + usuario.Imagen;
                    }

                    txtNombre.Text = usuario.Nombre;
                    txtApellido.Text = usuario.Apellido;
                    txtEmail.Text = usuario.Email;
                    txtEmail.ReadOnly = true;
                    txtPassword.Text = usuario.Pass;
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (UtilidadTexto.comprobarCampos(textBoxUsados(), lblAviso) && UtilidadTexto.comprobarLargoTexto(largosMaximos(), lblAviso))
                {
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    Usuario usuario = (Usuario)Session["usuario"];

                    if (txtImagen.PostedFile != null && !string.IsNullOrEmpty(txtImagen.PostedFile.FileName))
                    {                        
                        string ruta = Server.MapPath("./Imagenes/");
                        txtImagen.PostedFile.SaveAs(ruta + "perfil-" + usuario.Id + ".jpg");
                        usuario.Imagen = "perfil-" + usuario.Id + ".jpg";
                    }

                    usuario.Nombre = txtNombre.Text != "" ? usuario.Nombre = txtNombre.Text : usuario.Nombre = null;
                    usuario.Apellido = txtApellido.Text != "" ? usuario.Apellido = txtApellido.Text : usuario.Apellido = null;

                    negocio.actualizar(usuario);

                    Image imagen = (Image)Master.FindControl("imgAvatar");
                    imagen.ImageUrl = "~/Imagenes/" + usuario.Imagen;

                    Response.Redirect("Default.aspx", false);             
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
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
                { txtNombre, 50 },
                { txtApellido, 50 },
                { txtEmail, 100 },
                { txtPassword, 20 }
            };
        }

        
    }
}