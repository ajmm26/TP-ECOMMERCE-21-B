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
                ddlMarcas.DataTextField = "Nombre";
                ddlMarcas.DataValueField = "Id";
                ddlMarcas.DataBind();



                negocioCategoria negocioCategoria = new negocioCategoria();
                List<Categoria> categorias = negocioCategoria.listarCategoria();
                ddlCategoria.DataSource = categorias;
                ddlCategoria.DataTextField = "Nombre";
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataBind();



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
                        ddlCategoria.SelectedValue = producto.IdCategoria.Id.ToString();

                    }
                }
            }

        }

        protected void Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos obligatorios
                if (string.IsNullOrWhiteSpace(txtCodigo.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    lblError.Text = "⚠️ Código y Nombre son obligatorios.";
                    return;
                }

                if (!decimal.TryParse(txtPrecioCompra.Text, out decimal precioCompra) ||
                    !decimal.TryParse(txtPorcentajeGanancia.Text, out decimal porcentajeGanancia) ||
                    !decimal.TryParse(txtPrecioVenta.Text, out decimal precioVenta))
                {
                    lblError.Text = "⚠️ Los precios y porcentaje deben ser valores numéricos.";
                    return;
                }
                if (precioVenta < precioCompra)
                {
                    lblError.Text = "⚠️ El precio de venta no puede ser menor al de compra.";
                    return;
                }

                if (!int.TryParse(txtStockActual.Text, out int stockActual) ||
                    !int.TryParse(txtStockMinimo.Text, out int stockMinimo))
                {
                    lblError.Text = "⚠️ El stock debe ser un número entero.";
                    return;
                }

                // Validar selección de marca y categoría
                if (string.IsNullOrWhiteSpace(ddlMarcas.SelectedValue) || !int.TryParse(ddlMarcas.SelectedValue, out int idMarca))
                {
                    lblError.Text = "⚠️ La marca seleccionada no es válida.";
                    return;
                }

                if (string.IsNullOrWhiteSpace(ddlCategoria.SelectedValue) || !int.TryParse(ddlCategoria.SelectedValue, out int idCategoria))
                {
                    lblError.Text = "⚠️ La categoría seleccionada no es válida.";
                    return;
                }

                // Validar al menos una imagen
                List<string> imagenes = Session["imagenes"] as List<string> ?? new List<string>();
                if (Session["modificarId"] == null && imagenes.Count < 1)
                {
                    lblError.Text = "⚠️ El producto debe tener al menos una imagen cargada.";
                    return;
                }

                // Crear producto
                Producto nuevo = new Producto
                {
                    Codigo = txtCodigo.Text,
                    Nombre = txtNombre.Text,
                    IdMarca = new Marca(idMarca, ddlMarcas.SelectedItem.Text),
                    IdCategoria = new Categoria(idCategoria, ddlCategoria.SelectedItem.Text),
                    Descripcion = txtDescripcion.Text,
                    PrecioCompra = precioCompra,
                    PorcentajeGanancia = porcentajeGanancia,
                    PrecioVenta = precioVenta,
                    StockActual = stockActual,
                    StockMinimo = stockMinimo,
                    Estado = CheckBoxEstado.Checked
                };

                negocioProducto negocio = new negocioProducto();

                if (Session["modificarId"] != null)
                {
                    nuevo.Id = (int)Session["modificarId"];
                    negocio.modificarProducto(nuevo);
                    Session.Remove("modificarId");
                }
                else
                {
                    lblError.Text = $"DEBUG → MarcaId: {ddlMarcas.SelectedValue}, CategoriaId: {ddlCategoria.SelectedValue}";


                    negocio.agregarProducto(nuevo);

                    // Asociar imágenes
                    negocioImagen negocioImg = new negocioImagen();
                    List<Imagen> listaImagenes = imagenes.Select(url => new Imagen { Url = url, IdProducto = nuevo.Id }).ToList();
                    negocioImg.agregarImagenes(listaImagenes);
                }

                Session.Remove("imagenes");
                Response.Redirect("gestionProductos.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = "❌ Error al guardar: " + ex.Message;
            }
        }

        protected void btnMarca_Click(object sender, EventArgs e)
        {
            string nombreMarca = txtMarca.Text.Trim();
            if (string.IsNullOrWhiteSpace(nombreMarca))
            {
                lblError.Text = "⚠️ Ingresá un nombre de marca válido.";
                return;
            }

            negocioMarca negocio = new negocioMarca();

            // 🔒 Validar duplicado
            List<Marca> marcasExistentes = negocio.listar();
            if (marcasExistentes.Any(m => m.Nombre.Equals(nombreMarca, StringComparison.OrdinalIgnoreCase)))
            {
                lblError.Text = "⚠️ Esa marca ya existe.";
                return;
            }

            // ✅ Agregar nueva marca
            negocio.agregarMarca(new Marca { Nombre = nombreMarca });

            // Recargar y seleccionar
            List<Marca> marcas = negocio.listar();
            ddlMarcas.DataSource = marcas;
            ddlMarcas.DataTextField = "Nombre";
            ddlMarcas.DataValueField = "Id";
            ddlMarcas.DataBind();

            Marca nueva = marcas.FirstOrDefault(m => m.Nombre.Equals(nombreMarca, StringComparison.OrdinalIgnoreCase));
            if (nueva != null)
                ddlMarcas.SelectedValue = nueva.Id.ToString();

            txtMarca.Text = "";
            lblError.Text = $"✅ Marca '{nombreMarca}' agregada.";

            updListas.Update();

        }

        protected void btnCategoria_Click(object sender, EventArgs e)
        {
            string nombreCategoria = txtCategoria.Text.Trim();
            if (string.IsNullOrWhiteSpace(nombreCategoria))
            {
                lblError.Text = "⚠️ Ingresá un nombre de categoría válido.";
                return;
            }

            negocioCategoria negocio = new negocioCategoria();

            // 🔒 Validar duplicado
            List<Categoria> categoriasExistentes = negocio.listarCategoria();
            if (categoriasExistentes.Any(c => c.Nombre.Equals(nombreCategoria, StringComparison.OrdinalIgnoreCase)))
            {
                lblError.Text = "⚠️ Esa categoría ya existe.";
                return;
            }

            // ✅ Agregar nueva categoría
            negocio.agregarCategoria(new Categoria { Nombre = nombreCategoria });

            // Recargar y seleccionar
            List<Categoria> categorias = negocio.listarCategoria();
            ddlCategoria.DataSource = categorias;
            ddlCategoria.DataTextField = "Nombre";
            ddlCategoria.DataValueField = "Id";
            ddlCategoria.DataBind();
            Categoria nueva = categorias.FirstOrDefault(c => c.Nombre.Equals(nombreCategoria, StringComparison.OrdinalIgnoreCase));
            if (nueva != null)
                ddlCategoria.SelectedValue = nueva.Id.ToString();

            txtCategoria.Text = "";
            lblError.Text = $"✅ Categoría '{nombreCategoria}' agregada.";

            updListas.Update();

        }


        protected void actualizarPreview(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!string.IsNullOrWhiteSpace(txt.Text))
                imgPreview.ImageUrl = txt.Text;
            else
                imgPreview.ImageUrl = string.IsNullOrWhiteSpace(txt.Text) ? "~/img/default.jpg" : txt.Text;

        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            List<string> imagenes = Session["imagenes"] as List<string> ?? new List<string>();
            string url = txtUrlImagen.Text.Trim();

            if (string.IsNullOrWhiteSpace(url))
            {
                lblError.Text = "⚠️ La URL no puede estar vacía.";
                return;
            }

            if (imagenes.Contains(url))
            {
                lblError.Text = "⚠️ Esa imagen ya fue cargada.";
                return;
            }

            imagenes.Add(url);
            Session["imagenes"] = imagenes;

            rptImagenes.DataSource = imagenes.Select(i => new Imagen { Url = i });
            rptImagenes.DataBind();

            txtUrlImagen.Text = "";
            imgPreview.ImageUrl = "~/img/default.jpg";
            lblError.Text = $"✅ Imagen agregada ({imagenes.Count})";
        }



        protected void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            string url = txtUrlImagen.Text.Trim();
            imgPreview.ImageUrl = string.IsNullOrWhiteSpace(url) ? "~/img/default.jpg" : url;
        }


    }
}