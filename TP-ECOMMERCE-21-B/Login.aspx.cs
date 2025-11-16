using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace TP_ECOMMERCE_21_B
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Nada que hacer acá por ahora
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string clave = txtClave.Text.Trim();

            negocioUsuario negocio = new negocioUsuario();
            Usuario usuario = negocio.Login(email, clave);

            if (usuario != null)
            {
                Session["usuario"] = usuario;

                if (usuario.RolUsuario == "admin")
                    Response.Redirect("gestionProductos.aspx", false);
                else
                {
                    bool redirect = (Session["redirectCarrito"] as bool?) ?? false;

                    if (!redirect && usuario.RolUsuario=="client")
                    {
                        Response.Redirect("Default.aspx");
                    }

                    if (usuario.RolUsuario == "client")
                    {
                        Session["redirectCarrito"] = false;
                    Response.Redirect("FormularioPago.aspx");
                    }

                }
                   
            }
            else
            {
                lblErrorLogin.Text = "Email o contraseña incorrectos.";
            }
        }




    }
}