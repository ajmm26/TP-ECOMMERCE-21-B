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
    public partial class altaProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                negocioMarca negocio = new negocioMarca();
                List<Marca> marcas = negocio.listar();
                ddlMarcas.DataSource = marcas;
                ddlMarcas.DataBind();
            }




        }

        protected void Aceptar_Click(object sender, EventArgs e)
        {
            Producto nuevo = new Producto();
            negocioProducto negocio = new negocioProducto();
            try
            {
                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;

                int idMarca = int.Parse(ddlMarcas.SelectedValue);
                string nombreMarca = ddlMarcas.SelectedItem.Text;
                Marca marcaSeleccionada = new Marca(idMarca, nombreMarca);
                nuevo.IdMarca = marcaSeleccionada;






                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.PrecioCompra = decimal.Parse(txtPrecioCompra.Text);
                nuevo.PorcentajeGanancia = decimal.Parse(txtPorcentajeGanancia.Text);
                nuevo.PrecioVenta = decimal.Parse(txtPrecioVenta.Text);
                nuevo.StockActual = int.Parse (txtStockActual.Text);
                nuevo.StockMinimo = int.Parse(txtStockMinimo.Text);
                nuevo.Estado = CheckBoxEstado.Checked;

                negocio.agregarProducto(nuevo);
               


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}