using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_ECOMMERCE_21_B
{
    public partial class productoUnico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            string idproduct= Request.QueryString["id"];
                if (!string.IsNullOrEmpty(idproduct))
                {
                    int id = int.Parse(idproduct);
                    Producto p = getCurrentproduct(id);
                    ttlp.Text = String.Format(p.Nombre);
                    labelDescripcionText.Text = String.Format(p.Descripcion);
                    labelPrecioNormal.Text = String.Format(p.PrecioVenta.ToString());
                    imgProducto.ImageUrl = p.Imagenes[0].Url;
                    numLabel.Text = "0";
                }
            }
        }

        protected void click_buttonRest(object sender, EventArgs e)
        {

            if (!IsPostBack) { 
            
            }

            int num = int.Parse(numLabel.Text);

            if( num <= 0 || string.IsNullOrEmpty(numLabel.Text))
            {
           

            }
            else
            {
                buttonRest.Enabled= true;
                int rest = num - 1;
                string newvalue=rest.ToString();
                numLabel.Text = newvalue;
            }
        }

        protected void click_buttonPlus(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

            }

            int num = int.Parse(numLabel.Text);

            if (num < 0 || string.IsNullOrEmpty(numLabel.Text))
            {
           

            }
            else
            {
                buttonPlus.Enabled = true;
                int rest = num + 1;
                string newvalue = rest.ToString();
                numLabel.Text = newvalue;
            }

        }

        protected void click_buttonAdd(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

            }

            if (Session["items"] != null)
            {
                List<Producto> items = Session["items"] as List<Producto>;

                int num = int.Parse(numLabel.Text);

                if (num>0)
                {
                    Producto product = new Producto();
                    product.Nombre = ttlp.Text;
                    product.Descripcion = labelDescripcionText.Text;
                    product.PrecioVenta = decimal.Parse(labelPrecioNormal.Text);
                    items.Add(product);
                    Session["items"] = items;
                }

            }


        }

        protected Producto getCurrentproduct(int id)
        {
            negocioProducto negoProduct = new negocioProducto();
            Producto product = negoProduct.obtenerPorId(id);
            if(product != null)
            {
                return product;
            }
            return null;
        }

    }
}