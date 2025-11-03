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
    public partial class Catalogo : Page
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
                if (!IsPostBack)
                {
                    negocioProducto productoNegocio = new negocioProducto();
                    listaProducto = productoNegocio.listar();

                    RepeaterProducto.DataSource = listaProducto;
                    RepeaterProducto.DataBind();


                }


            }

        }
        protected void btnComprar_Command(object sender, CommandEventArgs e)
        {
            int idProducto = Convert.ToInt32(e.CommandArgument);
            // Lógica para agregar al carrito o redirigir
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
    }
}