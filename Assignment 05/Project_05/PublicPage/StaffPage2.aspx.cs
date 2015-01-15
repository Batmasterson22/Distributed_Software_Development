using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Encryption;
using System.Net;

namespace PublicPage
{
    public partial class StaffPage2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //XmlServices.Service1Client xmlSer = new XmlServices.Service1Client();
            //Project05Services.Service1Client xmlSer = new Project05Services.Service1Client();
            FinalServices.Service1Client xmlSer = new FinalServices.Service1Client();

            string[] theReturned = new String[3];
            bool checBox = true;
            Object thisLock = new Object();

                lock (thisLock)
                {
                    theReturned = xmlSer.checkXML(Encrypt_Decrypt.Encrypt(userName.Text),
                                                  Encrypt_Decrypt.Encrypt(password1.Text),
                                                  checBox);

                    if (theReturned[2].Equals("Administrator") && theReturned[0].Equals("Unavailable")
                        && theReturned[1].Equals("Correct"))
                    {
                        
                    }
                    else if (theReturned[0].Equals("Available") && checBox == false)
                        Label1.Text = "The Username does not exist.";


                    if (theReturned[0].Equals("Available") && password1.Text.Equals(password2.Text) && checBox == true)
                    {
                        Label1.Text = xmlSer.addToXML(userName.Text, password1.Text, type.Text);
                    }
                    else
                    {
                        if (theReturned[0].Equals("Unavailable") && checBox == true)
                        {
                            Label1.Text = "That name is unavailable, please try another variation.";
                        }
                        else if (!password1.Text.Equals(password2.Text) && checBox == true)
                        {
                            Label1.Text = "The two passwords do not match.";
                        }
                    }

                }

            }


        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StaffPage1.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

    }
}
