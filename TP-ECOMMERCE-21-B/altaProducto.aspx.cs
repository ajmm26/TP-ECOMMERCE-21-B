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

               
                if (Session["modificarId"] != null)
                {
                    int id = (int)Session["modificarId"];
                    negocioProducto negocioProducto = new negocioProducto();
                    Producto producto = negocioProducto.obtenerPorId(id);

                    if (producto != null)
                    {
                        txtCodigo.Text = producto.Codigo;
                        txtNombre.Text = producto.Nombre;
                        txtDescripcion.Text = producto.Descripcion;
                        txtPrecioCompra.Text = producto.PrecioCompra.ToString();
                        txtPorcentajeGanancia.Text = producto.PorcentajeGanancia.ToString();
                        txtPrecioVenta.Text = producto.PrecioVenta.ToString();
                        txtStockActual.Text = producto.StockActual.ToString();
                        txtStockMinimo.Text = producto.StockMinimo.ToString();
                        CheckBoxEstado.Checked = producto.Estado;

                        
                        ddlMarcas.SelectedValue = producto.IdMarca.Id.ToString();
                    }
                }
            }






        }

        protected void Aceptar_Click(object sender, EventArgs e)
        {
            Producto nuevo = new Producto();
            negocioProducto negocio = new negocioProducto();

            try
            {
                List<string> urlsValidas = new List<string>
                {
                  txtUrlImagen.Text,
                  txtUrlImagen1.Text,
                  txtUrlImagen2.Text,
                  txtUrlImagen3.Text,
                  txtUrlImagen4.Text,
                  txtUrlImagen5.Text
                }.Where(u => !string.IsNullOrWhiteSpace(u)).ToList();

                if (Session["modificarId"] == null && urlsValidas.Count < 3)
                {
                    lblError.Text = "⚠️ El producto debe tener al menos 3 imágenes cargadas.";
                    return;
                }



                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;

                int idMarca = int.Parse(ddlMarcas.SelectedValue);
                string nombreMarca = ddlMarcas.SelectedItem.Text;
                nuevo.IdMarca = new Marca(idMarca, nombreMarca);

                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.PrecioCompra = decimal.Parse(txtPrecioCompra.Text);
                nuevo.PorcentajeGanancia = decimal.Parse(txtPorcentajeGanancia.Text);
                nuevo.PrecioVenta = decimal.Parse(txtPrecioVenta.Text);
                nuevo.StockActual = int.Parse(txtStockActual.Text);
                nuevo.StockMinimo = int.Parse(txtStockMinimo.Text);
                nuevo.Estado = CheckBoxEstado.Checked;

                if (Session["modificarId"] != null)
                {
                    nuevo.Id = (int)Session["modificarId"];
                    negocio.modificarProducto(nuevo);
                    Session.Remove("modificarId");
                }
                else
                {
                    negocio.agregarProducto(nuevo);
                    List<Imagen> imagenes = urlsValidas.Select(url => new Imagen
                    {
                       
                        Url = url
                    }).ToList();

                    negocioImagen negocioImg = new negocioImagen();
                    negocioImg.agregarImagenes(imagenes);



                }

                Response.Redirect("gestionProductos.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

       

        protected void actualizarPreview(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!string.IsNullOrWhiteSpace(txt.Text))
                imgPreview.ImageUrl = txt.Text;
            else
                imgPreview.ImageUrl = string.IsNullOrWhiteSpace(txt.Text) ? "~/img/default.jpg" : txt.Text;

        }


    }
}