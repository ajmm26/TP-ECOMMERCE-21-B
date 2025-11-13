using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace TP_ECOMMERCE_21_B
{
    public partial class gestionPedido : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            cargarPedidos(); // Cargar antes del postback
            registrarValoresValidosParaDropDown(); // Registrar ítems válidos
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // No hace falta cargar acá, ya se hace en OnInit
        }

        private void cargarPedidos()
        {
            negocioPedido negocio = new negocioPedido();
            GridViewPedido.DataSource = negocio.listarPedido();
            GridViewPedido.DataBind();
        }

        private void registrarValoresValidosParaDropDown()
        {
            foreach (GridViewRow row in GridViewPedido.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList ddlEstado = (DropDownList)row.FindControl("ddlEstado");
                    if (ddlEstado != null)
                    {
                        ddlEstado.Items.Clear();
                        ddlEstado.Items.Add("Activo");
                        ddlEstado.Items.Add("En preparación");
                        ddlEstado.Items.Add("Enviado");
                        ddlEstado.Items.Add("Cancelado");
                    }
                }
            }
        }

        protected void GridViewPedido_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Pedido pedido = (Pedido)e.Row.DataItem;
                DropDownList ddlEstado = (DropDownList)e.Row.FindControl("ddlEstado");

                if (ddlEstado != null)
                {
                    ListItem item = ddlEstado.Items.FindByText(pedido.Estado);
                    if (item != null)
                        item.Selected = true;
                }
            }
        }

        protected void GridViewPedido_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "CambiarEstado")
            {
                int idPedido = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = ((Button)e.CommandSource).NamingContainer as GridViewRow;
                DropDownList ddlEstado = (DropDownList)row.FindControl("ddlEstado");
                string nuevoEstado = ddlEstado.SelectedValue;

                negocioPedido negocio = new negocioPedido();
                negocio.actualizarEstado(idPedido, nuevoEstado);

                cargarPedidos(); // Refrescar grilla
            }
        }
    }
}