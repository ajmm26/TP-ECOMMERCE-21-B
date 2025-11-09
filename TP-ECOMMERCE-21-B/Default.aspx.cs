using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_ECOMMERCE_21_B
{
    public partial class Default : Page
    {
        public List<Producto> listaProducto
        {
            get { return Session["listaProducto"] as List<Producto>; }
            set { Session["listaProducto"] = value; }
        }




        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                negocioProducto productoNegocio = new negocioProducto();
                listaProducto = productoNegocio.listar();

                RepeaterProducto.DataSource = listaProducto;
                RepeaterProducto.DataBind();

                Usuario usuario = Session["usuario"] as Usuario;

                if (usuario != null)
                {
                    lblLoginTexto.Text = $"Hola, {usuario.Nombre}";


                }
            }
        }
        protected void btnComprar_Command(object sender, CommandEventArgs e)
        {
            int idProducto = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("product.aspx?id=" + idProducto, false);
        }

        protected void btnCarrito_Command(object sender, CommandEventArgs e)
        {
            int idProducto = Convert.ToInt32(e.CommandArgument);
            // Lógica para agregar al carrito sin redirigir
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text.Trim();
           List<Producto> listaProducto = Session["listaProducto"] as List<Producto>;

            if (listaProducto == null)
                return;

            List<Producto> listaFiltrada = listaProducto
                .Where(p => p.Nombre != null && p.Nombre.ToLower().Contains(filtro.ToLower()))
                .ToList();

            RepeaterProducto.DataSource = listaFiltrada;
            RepeaterProducto.DataBind();




        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear(); // Elimina todos los datos de sesión
            Response.Redirect("Default.aspx", false); // Redirige al catálogo
        }


    }
}