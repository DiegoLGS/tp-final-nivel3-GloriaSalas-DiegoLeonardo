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
    public partial class AdministrarArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["listaArticulos"] == null)
            {                
                ArticuloNegocio negocio = new ArticuloNegocio();
                Session.Add("listaArticulos", negocio.listar());                
            }

            dgvArticulos.DataSource = Session["listaArticulos"];
            dgvArticulos.DataBind();
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulo.aspx?id=" + id);
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)Session["listaArticulos"];
            List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvArticulos.DataSource = listaFiltrada;
            dgvArticulos.DataBind();
        }

        protected void dgvArticulos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = int.Parse(dgvArticulos.DataKeys[e.RowIndex].Value.ToString());
            List<Articulo> listaTemporal = (List<Articulo>)Session["listaArticulos"];
            Articulo articuloSeleccionado = listaTemporal.Find(x => x.Id == id);
            Session.Add("articuloABorrar", articuloSeleccionado);
            modal.Style["display"] = "block";
            articuloAEliminar.Text = articuloSeleccionado.Nombre + " - " + articuloSeleccionado.Codigo + " - " + articuloSeleccionado.Marca.Descripcion;
        }

        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            if (Session["articuloABorrar"] != null)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Articulo articuloSeleccionado = (Articulo)Session["articuloABorrar"];
                int id = articuloSeleccionado.Id;
                negocio.eliminar(id);
                modal.Style["display"] = "none";

                List<Articulo> listaTemporal = (List<Articulo>)Session["listaArticulos"];                
                listaTemporal.Remove(articuloSeleccionado);
                Page_Load(sender, e);
            }
        }

        protected void btnCancelarEliminar_Click(object sender, EventArgs e)
        {
            modal.Style["display"] = "none";
        }

    }
}