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
            GridViewUsuario.DataSource = negocioUsuario.listarUsuarios();
            GridViewUsuario.DataBind();
        }

        public bool MostrarSeleccionar()
        {
            return Session["modoSeleccion"] != null;
        }




        protected void GridViewUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idUsuario = Convert.ToInt32(GridViewUsuario.SelectedDataKey.Value);
            negocioUsuario negocio = new negocioUsuario();

            if (Session["modoModificar"] != null && (bool)Session["modoModificar"])
            {
                Session["modificarUsuarioId"] = idUsuario;
                Session["modoAdmin"] = true;
                Session.Remove("modoModificar");
                Response.Redirect("altaUsuario.aspx");
            }
            else if (Session["modoBaja"] != null && (bool)Session["modoBaja"])
            {
                negocio.darDeBaja(idUsuario);
                Session.Remove("modoBaja");
                cargarListaUsuarios();
            }
            else if (Session["modoAlta"] != null && (bool)Session["modoAlta"])
            {
                negocio.darDeAlta(idUsuario);
                Session.Remove("modoAlta");
                cargarListaUsuarios();
            }
            else if (Session["modoEliminar"] != null && (bool)Session["modoEliminar"])
            {
                negocio.eliminarUsuario(idUsuario);
                Session.Remove("modoEliminar");
                cargarListaUsuarios();
            }
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
            Session.Remove("usuarioSeleccionadoId");
            Session.Remove("modificarUsuarioId");
            Session["modoAdmin"] = true;
            Response.Redirect("altaUsuario.aspx");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Session["modoModificar"] = true;
            cargarListaUsuarios();



        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Session["modoEliminar"] = true;
            cargarListaUsuarios();
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            Session["modoAlta"] = true;
            cargarListaUsuarios();
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            Session["modoBaja"] = true;
            cargarListaUsuarios();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Session.Remove("modoModificar");
            Session.Remove("modoBaja");
            Session.Remove("modoAlta");
            Session.Remove("modoEliminar");
            Session.Remove("modoAdmin");
            Session.Remove("modificarUsuarioId");
            Session.Remove("usuarioSeleccionadoId");
            Response.Redirect("gestionUsuario.aspx");


        }

        protected void GridViewUsuario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewUsuario.PageIndex = e.NewPageIndex;
            cargarListaUsuarios(); // ← si tenés este método para recargar la grilla
        }
        public bool MostrarBotonSeleccionar()
        {
            return Session["modoModificar"] != null || Session["modoBaja"] != null || Session["modoAlta"] != null || Session["modoEliminar"] != null;
        }




    }
}