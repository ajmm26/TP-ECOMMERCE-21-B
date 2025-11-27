using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_ECOMMERCE_21_B
{
    public partial class PurchaseConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Recuperar carrito de sesión
                List<Producto> carrito = Session["items"] as List<Producto>;
                if (carrito != null && carrito.Count > 0)
                {
                    RepeaterResumen.DataSource = carrito;
                    RepeaterResumen.DataBind();

                    decimal total = carrito.Sum(p => p.PrecioVenta * p.cantidad);
                    lblTotal.Text = $"Total pagado: ${total}";
                }

               
                lblMensaje.Text = "Tu pago fue aprobado y el pedido está siendo procesado.";
            }
        }
    }
}