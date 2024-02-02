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
                        imgAvatar.ImageUrl = "~/Imagenes/" + usuario.Imagen;
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
                if (comprobarCampos() && comprobarLargoTexto())
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

        private bool comprobarCampos()
        {
            TextBox[] textBoxes = { txtEmail, txtPassword };

            bool camposValidados = true;

            foreach (TextBox textBox in textBoxes)
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    camposValidados = false;
                    textBox.CssClass = "form-control is-invalid";
                }
                else
                {
                    textBox.CssClass = "form-control is-valid";
                }
            }          

            return camposValidados;
        }

        private bool comprobarLargoTexto()
        {
            bool largosValidados = true;

            Dictionary<TextBox, int> largoMaximos = new Dictionary<TextBox, int>()
            {
                { txtEmail, 100 },
                { txtPassword, 20 },
            };

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
                lblAviso.Text = "*Los límites de caracteres son: Email: 100, Password: 20";
            }

            return largosValidados;
        }
    }
}