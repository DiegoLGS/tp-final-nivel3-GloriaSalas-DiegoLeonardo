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
                if (UtilidadTexto.comprobarCampos(textBoxUsados(), lblAviso) && UtilidadTexto.comprobarLargoTexto(largosMaximos(), lblAviso) && !UtilidadPrecio.noContieneSoloNumerosOComa(txtPrecio, lblAviso))
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

        private Dictionary<TextBox, int> largosMaximos()
        {
            return new Dictionary<TextBox, int>()
            {
                { txtCodigo, 50 },
                { txtNombre, 50 },
                { txtDescripcion, 150 },
                { txtImagenUrl, 1000 }
            };
        }
       
        private TextBox[] textBoxUsados()
        {
            return new TextBox[] 
            {
                txtCodigo,
                txtNombre,
                txtDescripcion,
                txtPrecio,
                txtImagenUrl
            };
        }

    }
}