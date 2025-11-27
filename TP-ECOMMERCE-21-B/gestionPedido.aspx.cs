using dominio;
using negocio;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_ECOMMERCE_21_B
{
    public partial class gestionPedido : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("login.aspx", false);
            }
            else
            {
                Usuario usuario = (Usuario)Session["usuario"];
                if (!usuario.RolUsuario.Equals("admin", StringComparison.OrdinalIgnoreCase))
                {
                    Response.Redirect("login.aspx", false);
                }
            }
           
            if (!IsPostBack)
            {
                cargarPedidos();
            }
        }

        private void cargarPedidos()
        {
            negocioPedido negocio = new negocioPedido();
            GridViewPedido.DataSource = negocio.listarPedido();
            GridViewPedido.DataBind();
        }

        /*private void registrarValoresValidosParaDropDown()
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
        }*/

        protected void GridViewPedido_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Pedido pedido = (Pedido)e.Row.DataItem;
                DropDownList ddlEstado = (DropDownList)e.Row.FindControl("ddlEstado");

                if (ddlEstado != null)
                {
                    ddlEstado.Items.Clear();
                    ddlEstado.Items.Add("Activo");
                    ddlEstado.Items.Add("En preparación");
                    ddlEstado.Items.Add("Enviado");
                    ddlEstado.Items.Add("Cancelado");

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
                
                GridViewRow row = ((Button)e.CommandSource).NamingContainer as GridViewRow;
                DropDownList ddlEstado = (DropDownList)row.FindControl("ddlEstado");
                if (ddlEstado != null)
                {
                    string nuevoEstado = ddlEstado.SelectedValue;
                    int idPedido = Convert.ToInt32(e.CommandArgument);

                    negocioPedido negocio = new negocioPedido();
                    negocio.actualizarEstado(idPedido, nuevoEstado);

                    cargarPedidos(); // Refrescar grilla
                }
            }
        }

        protected void GridViewPedido_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewPedido.PageIndex = e.NewPageIndex;
            cargarPedidos();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            int.TryParse(txtFiltroNumero.Text.Trim(), out int numeroPedido);
            string estado = ddlFiltroEstado.SelectedValue;

            negocioPedido negocio = new negocioPedido();
            var lista = negocio.listarPedido();

            if (numeroPedido > 0)
                lista = lista.Where(p => p.Id == numeroPedido).ToList();

            if (!string.IsNullOrEmpty(estado))
                lista = lista.Where(p => p.Estado == estado).ToList();

            GridViewPedido.DataSource = lista;
            GridViewPedido.DataBind();
        }
    }
}