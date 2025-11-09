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
    public partial class gestionProductos : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["modoModificar"] != null && (bool)Session["modoModificar"])
                    GridViewProductos.AutoGenerateSelectButton = true;

                if (Session["modoBaja"] != null && (bool)Session["modoBaja"])
                    GridViewProductos.AutoGenerateSelectButton = true;

                if (Session["modoAlta"] != null && (bool)Session["modoAlta"])
                    GridViewProductos.AutoGenerateSelectButton = true;

                if (Session["modoEliminar"] != null && (bool)Session["modoEliminar"])
                    GridViewProductos.AutoGenerateSelectButton = true;

                negocioProducto negocio = new negocioProducto();

                if (Session["modoAlta"] != null && (bool)Session["modoAlta"])
                    GridViewProductos.DataSource = negocio.listarInactivos(); 
                else
                    GridViewProductos.DataSource = negocio.listar();

                GridViewProductos.DataBind();
            }



        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("altaProducto.aspx");
        }

        protected void GridViewProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProducto = Convert.ToInt32(GridViewProductos.SelectedDataKey.Value);
            negocioProducto negocio = new negocioProducto();

            if (Session["modoModificar"] != null && (bool)Session["modoModificar"])
            {
                Session["modificarId"] = idProducto;
                Session.Remove("modoModificar");
                Response.Redirect("altaProducto.aspx");
            }
            else if (Session["modoBaja"] != null && (bool)Session["modoBaja"])
            {
                negocio.darDeBaja(idProducto);
                Session.Remove("modoBaja");
                Response.Redirect("gestionProductos.aspx");
            }
            else if (Session["modoAlta"] != null && (bool)Session["modoAlta"])
            {
                negocio.darDeAlta(idProducto);
                Session.Remove("modoAlta");
                Response.Redirect("gestionProductos.aspx");
            }

            else if (Session["modoEliminar"] != null && (bool)Session["modoEliminar"])
            {
               
                negocio.eliminarProducto(idProducto);

                Session.Remove("modoEliminar");
                Response.Redirect("gestionProductos.aspx");
            }


        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Session["modoModificar"] = true;
            Response.Redirect("Productos.aspx"); 


        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Session["modoEliminar"] = true;
            Response.Redirect("Productos.aspx");

        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            Session["modoBaja"] = true;
            Response.Redirect("Productos.aspx"); 

        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            Session["modoAlta"] = true;
            Response.Redirect("Productos.aspx");

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            
            Session.Remove("modoAlta");
            Session.Remove("modoBaja");
            Session.Remove("modoModificar");

            Response.Redirect("Productos.aspx"); 
        }


    }
}
