using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_ECOMMERCE_21_B
{
    public partial class carritoWithMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) { 
            
            }

            if (Session["items"] != null) {
                int n = (int)Session["items"];
                if (n == 0)
                {
                    textcart.Text = "no tienes articulos en el carrito";
                }
                else
                {
                    if(n > 0)
                    {
                        textcart.Text = "La cantidad de articulos seleccinados es: " + n.ToString();
                    }
                }
            }
        }
    }
}