using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using utilidades;
using static System.Net.Mime.MediaTypeNames;

namespace tienda_web
{
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    List<Marca> listaMarca = marcaNegocio.listar();

                    ddlMarca.DataSource = listaMarca;
                    ddlMarca.DataValueField = "id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                    List<Categoria> listaCategoria = categoriaNegocio.listar();

                    ddlCategoria.DataSource = listaCategoria;
                    ddlCategoria.DataValueField = "id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();

                    if (Request.QueryString["id"] != null)
                    {
                        string id = Request.QueryString["id"].ToString();
                        ArticuloNegocio negocio = new ArticuloNegocio();
                        Articulo articuloSeleccionado = negocio.listar(id)[0];
                        Session["articuloSeleccionado"] = articuloSeleccionado;

                        txtCodigo.Text = articuloSeleccionado.Codigo;
                        txtNombre.Text = articuloSeleccionado.Nombre;
                        txtDescripcion.Text = articuloSeleccionado.Descripcion;
                        ddlMarca.SelectedValue = articuloSeleccionado.Marca.Descripcion;
                        ddlCategoria.SelectedValue = articuloSeleccionado.Categoria.Descripcion;
                        txtId.Text = articuloSeleccionado.Id.ToString();
                        txtPrecio.Text = articuloSeleccionado.Precio.ToString();
                        txtImagenUrl.Text = articuloSeleccionado.ImagenUrl;
                        txtImagenUrl_TextChanged(sender, e);
                        btnAceptar.Text = "Modificar";
                    }
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if(comprobarCampos() && comprobarLargoTexto())
                {
                    Articulo nuevoArticulo = new Articulo();
                    ArticuloNegocio negocio = new ArticuloNegocio();

                    nuevoArticulo.Codigo = txtCodigo.Text;
                    nuevoArticulo.Nombre = txtNombre.Text;
                    nuevoArticulo.Descripcion = txtDescripcion.Text;

                    nuevoArticulo.Marca = new Marca();
                    nuevoArticulo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                    nuevoArticulo.Categoria = new Categoria();
                    nuevoArticulo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                    nuevoArticulo.ImagenUrl = txtImagenUrl.Text;
                    nuevoArticulo.Precio = decimal.Parse(txtPrecio.Text);

                    if (Session["articuloSeleccionado"] != null)
                    {
                        nuevoArticulo.Id = ((Articulo)Session["articuloSeleccionado"]).Id;
                        negocio.modificar(nuevoArticulo);
                        Session.Remove("articuloSeleccionado");
                    }
                    else
                    {
                        negocio.agregar(nuevoArticulo);
                    }

                    Session.Remove("listaArticulos");
                    Response.Redirect("AdministrarArticulos.aspx", false);                    
                }
                
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }

        private bool comprobarCampos()
        {
            TextBox[] textBoxes = { txtCodigo, txtNombre, txtDescripcion, txtPrecio, txtImagenUrl };

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

            if(camposValidados)
            {
                if (UtilidadPrecio.noContieneSoloNumerosOComa(txtPrecio.Text))
                {
                    camposValidados = false;
                    txtPrecio.CssClass = "form-control is-invalid";
                    lblAviso.Text = "*Solo se admiten números y una coma en el campo Precio";
                }
            }
            else
            {
                lblAviso.Text = "*Debe llenar todos los campos";
            }

            return camposValidados;
        }

        private bool comprobarLargoTexto()
        {
            bool largosValidados = true;

            Dictionary<TextBox, int> largoMaximos = new Dictionary<TextBox, int>()
            {
                { txtCodigo, 50 },
                { txtNombre, 50 },
                { txtDescripcion, 150 },
                { txtImagenUrl, 1000 }
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

            if(!largosValidados )
            {
                lblAviso.Text = "*Los límites de caracteres son: Código y Nombre: 50, Descripción: 150, Url imagen: 1000";
            }

            return largosValidados;
        }

    }
}