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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Session.Add("listaArticulos", negocio.listar());
                repArticulos.DataSource = Session["listaArticulos"];
                repArticulos.DataBind();
            }
        }

        protected void btnEjemplo_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
            Console.WriteLine(valor);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ConsoleLog", $"console.log('{valor}')", true);

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

                if (campo == "Precio" && UtilidadesPrecio.noContieneSoloNumeros(filtro))
                {
                    txtFiltroAvanzado.CssClass = "form-control is-invalid";                    
                    return;
                }
                else
                {
                    txtFiltroAvanzado.CssClass = "form-control";
                }

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

            if (ddlCampo.SelectedItem.ToString() == "Precio")
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor o igual a");
                ddlCriterio.Items.Add("Menor o igual a");
                lblFiltroAvanzado.Text = "Filtro *solo números";
            }
            else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
                lblFiltroAvanzado.Text = "Filtro";
            }
        }                

    }
}