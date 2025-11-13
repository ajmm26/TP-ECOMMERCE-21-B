using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace TP_ECOMMERCE_21_B
{
    public partial class carritoWithMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) { 
            
            }

            List<Producto> products = (List<Producto>)Session["items"];


            if (products != null && products.Count == 0) { 
                TextBox tbtVacio= new TextBox();
                tbtVacio.Text = "No tiene articulos en el carrito";
                
            } 
        }

        protected void btnVolverCatalogo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void Click_btnDelete(object sender, CommandEventArgs e)
        {

            int index = int.Parse(e.CommandArgument.ToString());
            string script = "el div es: " + index.ToString();
            ClientScript.RegisterStartupScript(this.GetType(), "mensaje", script, true);

            // Si querés acceder al producto:
            List<Producto> products = (List<Producto>)Session["items"];
            Producto seleccionado = products[index];
        }

    }
}