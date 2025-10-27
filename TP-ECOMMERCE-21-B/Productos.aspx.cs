using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_ECOMMERCE_21_B
{
    public partial class Productos : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            negocioProducto producto = new negocioProducto();
            GridViewProductos.DataSource = producto.listar();
            GridViewProductos.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("altaProducto.aspx");
        }
    }
}