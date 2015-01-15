using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PublicPage
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        PublicPage.SolarPanel aSP1, aSP2, aSP3;
        string indexKey;

        protected void Page_Load(object sender, EventArgs e)
        {
            //This block is used to display the Session items into the ListBox
            if ((Session.Count > 2) && (ListBox1.Items.Count == 0))
            {
                aSP1 = (PublicPage.SolarPanel)Session["sSP1"];
                ListBox1.Items.Add(aSP1.name);
                if (Session.Count > 3)
                {
                    aSP2 = (PublicPage.SolarPanel)Session["sSP2"];
                    ListBox1.Items.Add(aSP2.name);
                }
                if (Session.Count > 4)
                {
                    aSP3 = (PublicPage.SolarPanel)Session["sSP3"];
                    ListBox1.Items.Add(aSP3.name);
                }

            }
        }

        //This button is used to display a specific Session data
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ListBox1.SelectedIndex < 0)
                Label1.Text = "Please select a solar panel from the list above";
            else
            {
                string num = Convert.ToString(ListBox1.SelectedIndex + 1);
                indexKey = "sSP" + num;
                PublicPage.SolarPanel aSP = (PublicPage.SolarPanel)Session[indexKey];

                Label2.Text = "<br />Manufacture: " + aSP.name;
                Label3.Text = "<br />Number: " + aSP.number;
                Label4.Text = "<br />Price: " + aSP.price;

            }
        }

        //This button is used to redirect to the AddProduct page
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddProduct.aspx");
        }

        //This button is used to add a solar panel to the cart if one is highlighted
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (ListBox1.SelectedIndex < 0)
                Label1.Text = "Please select a solar panel from the list above";
            else
            {
                string num = Convert.ToString(ListBox1.SelectedIndex + 1);
                indexKey = "sSP" + num;
                PublicPage.SolarPanel aSP = (PublicPage.SolarPanel)Session[indexKey];
                aSP.inCart = true;
                Session[indexKey] = aSP;
                Response.Redirect("~/MyCart.aspx");
            }
        }


    }
}