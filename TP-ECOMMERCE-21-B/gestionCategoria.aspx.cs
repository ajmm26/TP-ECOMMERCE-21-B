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
       public void cargarListaMarcas(string filtro = "")
        {
            var negocio = new negocioMarca();
            var lista = negocio.listar();

            if (!string.IsNullOrWhiteSpace(filtro))
                lista = lista.Where(m => m.Nombre.ToLower().Contains(filtro.ToLower())).ToList();

            GridViewMarca.DataSource = lista;
            GridViewMarca.DataBind();
        }
        public void cargarListaCategoria(string filtro = "")
        {
            var negocio = new negocioCategoria();
            var lista = negocio.listarCategoria();

            if (!string.IsNullOrWhiteSpace(filtro))
                lista = lista.Where(c => c.Nombre.ToLower().Contains(filtro.ToLower())).ToList();

            GridViewCategoria.DataSource = lista;
            GridViewCategoria.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
            cargarListaCategoria();
            cargarListaMarcas();
            }
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
            if (Session["idCategoriaSeleccionada"] !=null && !string.IsNullOrEmpty(txtCategoria.Text))
            {
                int id = (int)Session["idCategoriaSeleccionada"];
                string nuevoNombre = txtCategoria.Text.Trim();
                negocioCategoria negocioCat = new negocioCategoria();
                negocioCat.modificarCategoria(id,nuevoNombre);
                cargarListaCategoria();
                txtCategoria.Text = "";
                Session["idCategoriaSeleccionada"] = null;
                lblMensaje.Text = "Categoria modificada correctamente.";

            }
            if (Session["idMarcaSeleccionada"] != null && !string.IsNullOrEmpty(txtMarca.Text))
            {
                int id = (int)Session["idMarcaSeleccionada"];
                string nuevoNombre = txtMarca.Text.Trim();

                negocioMarca negocioMarca = new negocioMarca();
                negocioMarca.modificarMarca(id, nuevoNombre);

                cargarListaMarcas();
                txtMarca.Text = "";
                Session["idMarcaSeleccionada"] = null;
                lblMensaje.Text = "Marca modificada correctamente.";
            }

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            txtCategoria.Text = "";
            txtMarca.Text = "";
            Session["idCategoriaSeleccionada"] = null;
            Session["idMarcaSeleccionada"] = null;
            lblMensaje.Text = "";
            cargarListaCategoria();
            cargarListaMarcas();
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

        protected void GridViewCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(GridViewCategoria.SelectedDataKey.Value);
            string nombre = GridViewCategoria.SelectedRow.Cells[1].Text;
            txtCategoria.Text = nombre;
            Session["idCategoriaSeleccionada"] = id;
        }

        protected void GridViewMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(GridViewMarca.SelectedDataKey.Value);
            string nombre = GridViewMarca.SelectedRow.Cells[1].Text;
            txtMarca.Text = nombre;
            Session["idMarcaSeleccionada"] = id;
        }

        protected void btnFiltrarCategoria_Click(object sender, EventArgs e)
        {
            cargarListaCategoria(txtFiltroCategoria.Text.Trim());
        }

        protected void btnFiltrarMarca_Click(object sender, EventArgs e)
        {
            cargarListaMarcas(txtFiltroMarca.Text.Trim());
        }
    }
}