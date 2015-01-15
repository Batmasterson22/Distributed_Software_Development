using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PublicPage
{
    public partial class MyCart : System.Web.UI.Page
    {
        Double totalAmount = 0.0;
        protected void Page_Load(object sender, EventArgs e)
        {

            for (Int16 i = 1; i <= Session.Count-2; i++)
            {
                string indexKey = "sSP" + i;
                PublicPage.SolarPanel aSP = (PublicPage.SolarPanel)Session[indexKey];

                if (aSP.inCart)
                {
                    ListBox1.Items.Add(aSP.name);
                    totalAmount = totalAmount + Convert.ToDouble(aSP.price);
                }
            }

            Label1.Text = Convert.ToString(totalAmount);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ShoppingCart.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            for (int n = 0; n < ListBox1.Items.Count - 1; n++)
            {
                ListBox1.Items.RemoveAt(n);

            }
            Response.Redirect("~/Checkout.aspx");
        }
    }
}