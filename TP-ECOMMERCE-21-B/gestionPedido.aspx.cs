using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace TP_ECOMMERCE_21_B
{
    public partial class gestionPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            negocioPedido negocio = new negocioPedido();
            GridViewPedido.DataSource = negocio.listarPedido();
            GridViewPedido.DataBind();
        }
    }
}