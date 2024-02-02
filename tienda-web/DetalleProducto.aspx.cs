using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace tienda_web
{
    public partial class DetalleProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["id"] != null)
            {
                string id = Request.QueryString["id"].ToString();
                ArticuloNegocio negocio = new ArticuloNegocio();
                Articulo articuloSeleccionado = negocio.listar(id)[0];

                imgArticulo.ImageUrl = articuloSeleccionado.ImagenUrl;
                tituloCard.Text = articuloSeleccionado.Nombre;
                descripcionCard.Text = articuloSeleccionado.Descripcion;
                precioCard.Text = "$" + articuloSeleccionado.Precio.ToString();
                marcaCard.Text = "Marca: " + articuloSeleccionado.Marca.Descripcion;
                categoriaCard.Text = "Categoría: " + articuloSeleccionado.Categoria.Descripcion;
                codigoCard.Text = "Código: " + articuloSeleccionado.Codigo.ToString();
                idCard.Text = "ID: " + articuloSeleccionado.Id.ToString();

                switch (articuloSeleccionado.Marca.Descripcion)
                {
                    case "Samsung":
                        linkPagina.Text = "https://www.samsung.com/ar/";
                        linkPagina.NavigateUrl = "https://www.samsung.com/ar/";
                        break;

                    case "Apple":
                        linkPagina.Text = "https://www.apple.com/la/";
                        linkPagina.NavigateUrl = "https://www.apple.com/la/";
                        break;

                    case "Sony":
                        linkPagina.Text = "https://www.sony.com.ar/";
                        linkPagina.NavigateUrl = "https://www.sony.com.ar/";
                        break;

                    case "Huawei":
                        linkPagina.Text = "https://consumer.huawei.com/latin/";
                        linkPagina.NavigateUrl = "https://consumer.huawei.com/latin/";

                        break;

                    default:
                        linkPagina.Text = "https://www.motorola.com.ar/";
                        linkPagina.NavigateUrl = "https://www.motorola.com.ar/";
                        break;
                }
            }
            else
            {
                lblAviso.Text = "No se seleccionó ningún artículo para ver detalles";
            }
        }
    }
}