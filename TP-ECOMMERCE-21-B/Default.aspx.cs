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
    public partial class Default : Page
    {
        public List<Producto> listaProducto
        {
            get { return Session["listaProducto"] as List<Producto>; }
            set { Session["listaProducto"] = value; }
        }




        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                negocioProducto productoNegocio = new negocioProducto();
                listaProducto = productoNegocio.listar();

                RepeaterProducto.DataSource = listaProducto;
                RepeaterProducto.DataBind();

                negocioMarca nm = new negocioMarca();
                List<Marca> marcas = nm.listar();
                marcaSelect.DataSource = marcas;
                marcaSelect.DataTextField = "Nombre"; 
                marcaSelect.DataValueField = "Id";
                marcaSelect.DataBind();

                negocioCategoria nc = new negocioCategoria();
                List<Categoria> categorias = nc.listarCategoria();
                categoriaSelect.DataSource = categorias;
                categoriaSelect.DataTextField = "Nombre";
                categoriaSelect.DataValueField = "id";
                categoriaSelect.DataBind();

            }
        }
        protected void btnComprar_Command(object sender, CommandEventArgs e)
        {
            int idProducto = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("product.aspx?id=" + idProducto, false);
        }

        

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text.Trim();
           List<Producto> listaProducto = Session["listaProducto"] as List<Producto>;

            if (listaProducto == null)
                return;

            List<Producto> listaFiltrada = listaProducto
                .Where(p => p.Nombre != null && p.Nombre.ToLower().Contains(filtro.ToLower()))
                .ToList();

            RepeaterProducto.DataSource = listaFiltrada;
            RepeaterProducto.DataBind();

        }
        

    }
}