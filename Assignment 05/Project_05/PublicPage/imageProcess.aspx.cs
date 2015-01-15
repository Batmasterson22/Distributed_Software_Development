using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PublicPage
{
    public partial class imageProcess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Response.Clear();
                //Create an ImageVerifier object
                ImageVerifier.ServiceClient theIma = new ImageVerifier.ServiceClient();

                string myStr = "", userLen = "";

                //Checks if the Session state is already set if not generate one else set myStr to it
                if (Session["generatedString"] == null)
                {
                    if (Session["userLength"] == null)
                    {
                        userLen = "4";
                    }
                    else
                    {
                        userLen = Session["userLength"].ToString();
                    }

                    myStr = theIma.GetVerifierString(userLen);
                    Session["generatedString"] = myStr;

                }
                else
                {
                    myStr = Session["generatedString"].ToString();
                }

                //This block is use to make the string into an image of the Jpeg form
                Stream myStream = theIma.GetImage(myStr);
                System.Drawing.Image myImage = System.Drawing.Image.FromStream(myStream);
                Response.ContentType = "image/jpeg";
                myImage.Save(Response.OutputStream, ImageFormat.Jpeg);
            }
            catch (Exception ecx)
            {
                Console.WriteLine(ecx.Message);
            }
        }
    }
}