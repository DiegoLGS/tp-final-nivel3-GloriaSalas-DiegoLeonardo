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
    public partial class Favoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                List<int> listaFavoritos = (List<int>)Session["listaFavoritos"];
                
                if(listaFavoritos.Count > 0)
                {
                    List<Articulo> listaArticulos = new List<Articulo>();

                    foreach (int id in listaFavoritos)
                    {
                        Articulo nuevoArticulo = new Articulo();
                        nuevoArticulo = negocio.listar(id.ToString())[0];
                        listaArticulos.Add(nuevoArticulo);                    
                    }

                    repArticulos.DataSource = listaArticulos;
                    repArticulos.DataBind();
                }
            }
        }

        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;
            Response.Redirect("DetalleProducto.aspx?id=" + id);
        }
    }
}