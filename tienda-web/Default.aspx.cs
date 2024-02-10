using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using utilidades;

namespace tienda_web
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Session.Add("listaArticulos", negocio.listar());
                    repArticulos.DataSource = Session["listaArticulos"];
                    repArticulos.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)Session["listaArticulos"];
            List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            repArticulos.DataSource = listaFiltrada;
            repArticulos.DataBind();
        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAvanzado.Checked)
            {
                ddlCampo_SelectedIndexChanged(sender, e);
            }
            else
            {
                repArticulos.DataSource = Session["listaArticulos"];
                repArticulos.DataBind();
            }

            txtFiltro.Enabled = !chkAvanzado.Checked;            
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();                
                string campo = ddlCampo.SelectedItem.ToString();
                string criterio = ddlCriterio.SelectedItem.ToString();
                string filtro = txtFiltroAvanzado.Text;

                if (campo == "Precio" && UtilidadPrecio.noContieneSoloNumeros(txtFiltroAvanzado, lblFiltroAvanzado))
                    return;                

                repArticulos.DataSource = negocio.filtrar(campo, criterio, filtro);
                repArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }


        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            txtFiltro.CssClass = "form-control";

            if (ddlCampo.SelectedItem.ToString() == "Precio")
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor o igual a");
                ddlCriterio.Items.Add("Menor o igual a");
            }
            else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
                lblFiltroAvanzado.Text = "Filtro";
            }
        }

        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;
            Response.Redirect("DetalleProducto.aspx?id=" + id);
        }

        protected void btnFavorito_Click(object sender, EventArgs e)
        {
            FavoritoNegocio negocio = new FavoritoNegocio();
            int idArticulo = int.Parse(((Button)sender).CommandArgument);
            int idUsuario = ((Usuario)Session["usuario"]).Id;
            List<int> listaFavoritos = (List<int>)Session["listaFavoritos"];

            if (listaFavoritos.Contains(idArticulo))
            {
                negocio.eliminar(idArticulo, idUsuario);
                ((Button)sender).Text = "🤍";
            }
            else
            {
                negocio.agregar(idArticulo, idUsuario);
                ((Button)sender).Text = "❤";
            }
        }

        protected void repArticulos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Button btnFavorito = (Button)e.Item.FindControl("btnFavorito");
                int articuloId = (int)DataBinder.Eval(e.Item.DataItem, "Id");
                List<int> listaFavoritos = (List<int>)Session["listaFavoritos"];

                if(listaFavoritos != null)
                {
                    if (listaFavoritos.Contains(articuloId))
                        btnFavorito.Text = "❤";
                    else
                        btnFavorito.Text = "🤍";
                }
            }
        }
    }
}