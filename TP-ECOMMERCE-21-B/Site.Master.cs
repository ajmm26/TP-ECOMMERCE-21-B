using dominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_ECOMMERCE_21_B
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string currentPage = Path.GetFileName(Request.Url.AbsolutePath).ToLower();

                // Mostrar menú solo si estás en gestionProductos.aspx
                phGestionLinks.Visible = currentPage.Contains("gestion");
            }




        }
    }
}