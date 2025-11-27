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

        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            string nombreCategoria = txtCategoria.Text.Trim();
            lblMensajeCategoria.ForeColor = System.Drawing.Color.Red;

            if (string.IsNullOrEmpty(nombreCategoria))
            {
                lblMensajeCategoria.Text = "⚠️ Debe ingresar un nombre para la categoría.";
                return;
            }

            var negocioCat = new negocioCategoria();
            var listaCat = negocioCat.listarCategoria();

            bool existeCategoria = listaCat.Any(c => c.Nombre.Equals(nombreCategoria, StringComparison.OrdinalIgnoreCase));
            if (existeCategoria)
            {
                lblMensajeCategoria.Text = "⚠️ Ya existe una categoría con ese nombre.";
                return;
            }

            negocioCat.agregarCategoria(new Categoria { Nombre = nombreCategoria });
            cargarListaCategoria();
            txtCategoria.Text = "";
            lblMensajeCategoria.ForeColor = System.Drawing.Color.Green;
            lblMensajeCategoria.Text = "✅ Categoría agregada correctamente.";


        }
        protected void btnAgregarMarca_Click(object sender, EventArgs e)
        {

            string nombreMarca = txtMarca.Text.Trim();
            lblMensajeMarca.ForeColor = System.Drawing.Color.Red;

            if (string.IsNullOrEmpty(nombreMarca))
            {
                lblMensajeMarca.Text = "⚠️ Debe ingresar un nombre para la marca.";
                return;
            }

            var negocioMarca = new negocioMarca();
            var listaMarca = negocioMarca.listar();

            bool existeMarca = listaMarca.Any(m => m.Nombre.Equals(nombreMarca, StringComparison.OrdinalIgnoreCase));
            if (existeMarca)
            {
                lblMensajeMarca.Text = "⚠️ Ya existe una marca con ese nombre.";
                return;
            }

            negocioMarca.agregarMarca(new Marca { Nombre = nombreMarca });
            cargarListaMarcas();
            txtMarca.Text = "";
            lblMensajeMarca.ForeColor = System.Drawing.Color.Green;
            lblMensajeMarca.Text = "✅ Marca agregada correctamente.";

        }

        protected void btnModificarCategoria_Click(object sender, EventArgs e)
        {
            if (Session["idCategoriaSeleccionada"] == null)
            {
                lblMensajeCategoria.Text = "⚠️ Debe seleccionar una categoría para modificar.";
                lblMensajeCategoria.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string nuevoNombre = txtCategoria.Text.Trim();
            if (string.IsNullOrEmpty(nuevoNombre))
            {
                lblMensajeCategoria.Text = "⚠️ El nombre de la categoría no puede estar vacío.";
                lblMensajeCategoria.ForeColor = System.Drawing.Color.Red;
                return;
            }

            int id = (int)Session["idCategoriaSeleccionada"];
            var negocioCat = new negocioCategoria();
            var listaCat = negocioCat.listarCategoria();

            bool nombreDuplicado = listaCat.Any(c => c.Nombre.Equals(nuevoNombre, StringComparison.OrdinalIgnoreCase) && c.Id != id);
            if (nombreDuplicado)
            {
                lblMensajeCategoria.Text = "⚠️ Ya existe otra categoría con ese nombre.";
                lblMensajeCategoria.ForeColor = System.Drawing.Color.Red;
                return;
            }

            negocioCat.modificarCategoria(id, nuevoNombre);
            cargarListaCategoria();
            txtCategoria.Text = "";
            Session["idCategoriaSeleccionada"] = null;
            lblMensajeCategoria.ForeColor = System.Drawing.Color.Green;
            lblMensajeCategoria.Text = "✅ Categoría modificada correctamente.";

        }

        protected void btnModificarMarca_Click(object sender, EventArgs e)
        {
            if (Session["idMarcaSeleccionada"] == null)
            {
                lblMensajeMarca.Text = "⚠️ Debe seleccionar una marca para modificar.";
                lblMensajeMarca.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string nuevoNombre = txtMarca.Text.Trim();
            if (string.IsNullOrEmpty(nuevoNombre))
            {
                lblMensajeMarca.Text = "⚠️ El nombre de la marca no puede estar vacío.";
                lblMensajeMarca.ForeColor = System.Drawing.Color.Red;
                return;
            }

            int id = (int)Session["idMarcaSeleccionada"];
            var negocioMarca = new negocioMarca();
            var listaMarca = negocioMarca.listar();

            bool nombreDuplicado = listaMarca.Any(m => m.Nombre.Equals(nuevoNombre, StringComparison.OrdinalIgnoreCase) && m.Id != id);
            if (nombreDuplicado)
            {
                lblMensajeMarca.Text = "⚠️ Ya existe otra marca con ese nombre.";
                lblMensajeMarca.ForeColor = System.Drawing.Color.Red;
                return;
            }

            negocioMarca.modificarMarca(id, nuevoNombre);
            cargarListaMarcas();
            txtMarca.Text = "";
            Session["idMarcaSeleccionada"] = null;
            lblMensajeMarca.ForeColor = System.Drawing.Color.Green;
            lblMensajeMarca.Text = "✅ Marca modificada correctamente.";

        }
        protected void btnCancelarCategoria_Click(object sender, EventArgs e)
        {
            txtCategoria.Text = "";
            Session["idCategoriaSeleccionada"] = null;
            lblMensajeCategoria.Text = "";
            cargarListaCategoria();
        }
        protected void btnCancelarMarca_Click(object sender, EventArgs e)
        {
            txtMarca.Text = "";
            Session["idMarcaSeleccionada"] = null;
            lblMensajeMarca.Text = "";
            cargarListaMarcas();
        }

        protected void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            if (GridViewCategoria.SelectedDataKey == null)
            {
                lblMensajeCategoria.Text = "⚠️ Debe seleccionar una categoría para eliminar.";
                lblMensajeCategoria.ForeColor = System.Drawing.Color.Red;
                return;
            }

            int idCategoria = Convert.ToInt32(GridViewCategoria.SelectedDataKey.Value);
            var negocioProd = new negocioProducto();

            if (negocioProd.ExistenProductosPorCategoria(idCategoria))
            {
                lblMensajeCategoria.Text = "⚠️ No se puede eliminar la categoría porque tiene productos asociados.";
                lblMensajeCategoria.ForeColor = System.Drawing.Color.Red;
                return;
            }

            var negocioCat = new negocioCategoria();
            negocioCat.eliminarCategoria(idCategoria);
            cargarListaCategoria();
            lblMensajeCategoria.ForeColor = System.Drawing.Color.Green;
            lblMensajeCategoria.Text = "✅ Categoría eliminada correctamente.";
        }

        protected void btnEliminarMarca_Click(object sender, EventArgs e)
        {
            if (GridViewMarca.SelectedDataKey == null)
            {
                lblMensajeMarca.Text = "⚠️ Debe seleccionar una marca para eliminar.";
                lblMensajeMarca.ForeColor = System.Drawing.Color.Red;
                return;
            }

            int idMarca = Convert.ToInt32(GridViewMarca.SelectedDataKey.Value);
            var negocioProd = new negocioProducto();

            if (negocioProd.ExistenProductosPorMarca(idMarca))
            {
                lblMensajeMarca.Text = "⚠️ No se puede eliminar la marca porque tiene productos asociados.";
                lblMensajeMarca.ForeColor = System.Drawing.Color.Red;
                return;
            }

            var negocioMarca = new negocioMarca();
            negocioMarca.eliminarMarca(idMarca);
            cargarListaMarcas();
            lblMensajeMarca.ForeColor = System.Drawing.Color.Green;
            lblMensajeMarca.Text = "✅ Marca eliminada correctamente.";

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