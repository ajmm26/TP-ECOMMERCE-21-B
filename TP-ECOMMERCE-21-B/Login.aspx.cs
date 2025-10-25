using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_ECOMMERCE_21_B
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Catalogo.aspx");


        }
        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            lblErrorRegistro.Text = "Registro exitoso. Ahora podés iniciar sesión.";

            mvLoginRegistro.ActiveViewIndex = 0; 



        }
        protected void btnMostrarRegistro_Click(object sender, EventArgs e)
        {
            mvLoginRegistro.ActiveViewIndex = 1;
        }

        protected void btnMostrarLogin_Click(object sender, EventArgs e)
        {
            mvLoginRegistro.ActiveViewIndex = 0;
        }






    }
}