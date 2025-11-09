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
    public partial class gestionUsuario : System.Web.UI.Page
    {
        protected void cargarListaUsuarios()
        {
            negocioUsuario negocioUsuario = new negocioUsuario();
            List<Usuario> lista = negocioUsuario.listarUsuarios();
            GridViewUsuario.DataSource = lista;
            GridViewUsuario.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarListaUsuarios();
            }


        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
           


        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {

        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }
        


    }
}