using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_ECOMMERCE_21_B
{
    public partial class FormularioPago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

            if (!IsPostBack)
            {
                string tipo = rbEnvio.SelectedValue;
                panelDireccion.Visible = tipo == "Retiro";
                panelTelefono.Visible = tipo == "Coordinar";


                Usuario usuario = Session["usuario"] as Usuario;
                if (usuario != null)
                {
                    txtNombre.Text = usuario.Nombre;
                    txtApellido.Text = usuario.Apellido;
                    txtEmail.Text = usuario.Email;
                }

                List<Producto> carrito = Session["items"] as List<Producto>;
                if (carrito != null && carrito.Count > 0)
                {
                    RepeaterCarrito.DataSource = carrito;
                    RepeaterCarrito.DataBind();
                    decimal total = carrito.Sum(p => p.PrecioVenta * p.cantidad);
                    lblTotal.Text = $"Total a pagar: ${total}";
                }
                else
                {
                    lblTotal.Text = "No hay productos en el carrito.";
                }
            }



        }

        protected void btnConfirmarPago_Click(object sender, EventArgs e)
        {
            List<Producto> carrito = Session["items"] as List<Producto>;
            if (carrito == null || carrito.Count == 0)
            {
                Response.Redirect("carritoWithMaster.aspx");
                return;
            }

            negocioPedido np = new negocioPedido();
            Pedido pedido = new Pedido();
            Usuario user = (Usuario)Session["usuario"];
            pedido.IdUsuario = user.Id;
            pedido.PrecioTotal= carrito.Sum(p => p.PrecioVenta * p.cantidad);
            pedido.Estado = "Pagado";
            pedido.MetodoDePago = rbPago.SelectedValue;
            int numPedido = np.AgregarPedido(pedido);
            pedido.DetallePedidos = getDetallePedido(numPedido);
            foreach(var detalle in pedido.DetallePedidos)
            {
              bool response =  np.AgregarDetalleDePedido(detalle);

                if (!response)
                {


                np.verificarDetallePedido(numPedido, response);
                }
            }
          
            Session["items"] = null;
            Response.Redirect("Confirmacion.aspx");
        }

        protected List<DetallePedido> getDetallePedido(int numPedido)
        { 
            List<DetallePedido> detallePedidos = new List<DetallePedido>();
            List<Producto> items = (List<Producto>)Session["items"];
           
            if (items.Count < 0 || items == null) {
                return null;
            }

            foreach (var item in items) { 
                DetallePedido detalleP = new DetallePedido();
                detalleP.idProducto=item.Id;
                detalleP.idPedido = numPedido;
                detalleP.cantidadProducto = item.cantidad;
                detalleP.precioUnitario = item.PrecioVenta;
                detalleP.precioRebajado = 0;
                detallePedidos.Add(detalleP);
            }
            return detallePedidos;
        }


        protected void rbPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            string metodo = rbPago.SelectedValue;

            panelTarjeta.Visible = metodo == "tarjeta";
            panelTransferencia.Visible = metodo == "transferencia";
            panelMercadoPago.Visible = metodo == "mercadopago";
        }
        protected void rbEnvio_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipo = rbEnvio.SelectedValue;

            panelDireccion.Visible = tipo == "Retiro";
            panelTelefono.Visible = tipo == "Coordinar";
        }




    }
}