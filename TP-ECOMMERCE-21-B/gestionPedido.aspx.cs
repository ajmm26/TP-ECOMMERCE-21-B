using dominio;
using negocio;
using service;
using System;
using System.Linq;
using System.Text;
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
            System.Globalization.CultureInfo cultura = new System.Globalization.CultureInfo("es-AR");
            System.Threading.Thread.CurrentThread.CurrentCulture = cultura;
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultura;
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

                    
                    Pedido pedido = negocio.ObtenerPedidoConUsuario(idPedido);
                    Usuario user = new negocioUsuario().buscarPorId(pedido.IdUsuario);
                    emailService servicioEmail = new emailService();
                    string asunto = $"Estado actualizado - Pedido #{pedido.Id}";

                    StringBuilder cuerpo = new StringBuilder();
                    cuerpo.AppendLine($"<h2>Hola {user.Nombre},</h2>");
                    cuerpo.AppendLine($"<p>Tu pedido <strong>#{pedido.Id}</strong> ha cambiado de estado.</p>");
                    cuerpo.AppendLine($"<p><strong>Nuevo estado:</strong> {pedido.Estado}</p>");
                    cuerpo.AppendLine("<hr /><p>Gracias por confiar en SIGNOS.</p>");

                    servicioEmail.armarCorreo(user.Email, asunto, cuerpo.ToString());
                    servicioEmail.enviarMail();

                    cargarPedidos(); 
                }
            }
            else if (e.CommandName == "VerDetalle")
            {
                int idPedido = Convert.ToInt32(e.CommandArgument);
                negocioPedido negocio = new negocioPedido();

                
                Pedido pedido = negocio.ObtenerPedidoConUsuario(idPedido);

                
                Response.Redirect("detallePedido.aspx?id=" + idPedido);
            }
        }
        private void aplicarFiltroPedidos()
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

        protected void GridViewPedido_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewPedido.PageIndex = e.NewPageIndex; // cambia a la página seleccionada
            aplicarFiltroPedidos(); // reaplica el filtro
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            GridViewPedido.PageIndex = 0; // siempre arranca en la primera página
            aplicarFiltroPedidos();
        }

        
    }
}