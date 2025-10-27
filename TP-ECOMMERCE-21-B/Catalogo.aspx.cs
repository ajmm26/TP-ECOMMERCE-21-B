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
        public List<Producto> listaProducto { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            negocioProducto productoNegocio = new negocioProducto();
            RepeaterProducto.DataSource = productoNegocio.listar();
            RepeaterProducto.DataBind();
           
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


    }
}