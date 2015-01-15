using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PublicPage
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Add the entered data to the catalog
        protected void Button2_Click(object sender, EventArgs e)
        {
            string name = TextBox1.Text;
            string number = TextBox2.Text;
            string sPrice = TextBox3.Text;
            double price = Convert.ToDouble(sPrice);

            //Create SolarPanel object
            PublicPage.SolarPanel aSP = new PublicPage.SolarPanel(name, number, price, true);

            //This block is used to set the different elements of the catalog
            string num = Convert.ToString(Session.Count-1);
            string catalogKey = "sSP" + num;
            Session[catalogKey] = aSP;
            Response.Redirect("~/ShoppingCart.aspx");

        }



    }
}