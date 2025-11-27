using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_ECOMMERCE_21_B
{
    public partial class contacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string email = txtEmail.Text.Trim();
            string mensaje = txtMensaje.Text.Trim();

            
            lblConfirmacion.Text = "Gracias por tu mensaje, " + nombre + ". Te responderemos pronto.";
            lblConfirmacion.Visible = true;

            txtNombre.Text = "";
            txtEmail.Text = "";
            txtMensaje.Text = "";
        }
    }
}