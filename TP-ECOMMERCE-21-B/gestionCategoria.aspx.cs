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
    public partial class gestionCategoria : System.Web.UI.Page
    {
       public void cargarListaMarcas()
        {
            negocioMarca marcaNegocio = new negocioMarca();
            GridViewMarca.DataSource = marcaNegocio.listar();
            GridViewMarca.DataBind();
        }
        public void cargarListaCategoria()
        {
            negocioCategoria categoriaNegocio = new negocioCategoria();
            GridViewCategoria.DataSource = categoriaNegocio.listarCategoria();
            GridViewCategoria.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarListaCategoria();
            cargarListaMarcas();
            
        }

        protected void GridViewCategoria_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewCategoria.PageIndex = e.NewPageIndex;
            cargarListaCategoria(); 
        }

        protected void GridViewMarca_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewMarca.PageIndex = e.NewPageIndex;
            cargarListaMarcas(); 
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombreCategoria = txtCategoria.Text.Trim();
            string nombreMarca = txtMarca.Text.Trim();

            if (!string.IsNullOrEmpty(nombreCategoria))
            {
                Categoria nuevaCat = new Categoria();
                nuevaCat.Nombre = nombreCategoria;

                negocioCategoria negocioCat = new negocioCategoria();
                negocioCat.agregarCategoria(nuevaCat);

                cargarListaCategoria();
                txtCategoria.Text = "";
            }

            if (!string.IsNullOrEmpty(nombreMarca))
            {
                Marca nuevaMarca = new Marca();
                nuevaMarca.Nombre = nombreMarca;

                negocioMarca negocioMarca = new negocioMarca();
                negocioMarca.agregarMarca(nuevaMarca);

                cargarListaMarcas();
                txtMarca.Text = "";
            }

            if (string.IsNullOrEmpty(nombreCategoria) && string.IsNullOrEmpty(nombreMarca))
            {
                // Mostrar mensaje: "Debe ingresar un nombre para categoría o marca"
            }

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            negocioProducto negocioProd = new negocioProducto();

            
            if (GridViewCategoria.SelectedDataKey != null)
            {
                int idCategoria = Convert.ToInt32(GridViewCategoria.SelectedDataKey.Value);

                if (negocioProd.ExistenProductosPorCategoria(idCategoria))
                {
                    lblMensaje.Text = "No se puede eliminar la categoría porque tiene productos asociados.";
                    return;
                }

                negocioCategoria negocioCat = new negocioCategoria();
                negocioCat.eliminarCategoria(idCategoria);

                cargarListaCategoria();
                lblMensaje.Text = "Categoría eliminada correctamente.";
                return;
            }

           
            if (GridViewMarca.SelectedDataKey != null)
            {
                int idMarca = Convert.ToInt32(GridViewMarca.SelectedDataKey.Value);

                if (negocioProd.ExistenProductosPorMarca(idMarca))
                {
                    lblMensaje.Text = "No se puede eliminar la marca porque tiene productos asociados.";
                    return;
                }

                negocioMarca negocioMarca = new negocioMarca();
                negocioMarca.eliminarMarca(idMarca);

                cargarListaMarcas();
                lblMensaje.Text = "Marca eliminada correctamente.";
                return;
            }

           
            lblMensaje.Text = "Debe seleccionar una categoría o una marca.";
        }
    }
}