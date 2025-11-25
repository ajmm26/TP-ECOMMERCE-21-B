using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_ECOMMERCE_21_B
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack) {

                if (Session["usuario"] == null) {

                    Response.Redirect("Ecommerce.aspx");

                }

                Usuario user = (Usuario)Session["usuario"];
                nombreUser.Text = user.Nombre + " "+ user.Apellido;
                string textid = "ID Usuario: ";
                IDusuario.Text = textid + user.Id.ToString();
                emailText.Text= " " + user.Email;
                TlfText.Text = " " + user.Telefono;

            }

        }
    }
}