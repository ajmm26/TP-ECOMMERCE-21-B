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
            numLabel.Text = "0";
          
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
                int n = (int)Session["items"];

                int num = int.Parse(numLabel.Text);

                if (num>0)
                {
                int nw = n + 1;

                Session["items"] = nw;
                }

            }


        }

    }
}