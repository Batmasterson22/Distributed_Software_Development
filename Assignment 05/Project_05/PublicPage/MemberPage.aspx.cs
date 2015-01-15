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
    public partial class MemberPage : System.Web.UI.Page
    {
        public static bool loginCheck = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie myCookies = Request.Cookies["myCookieId"];
            if ((myCookies == null) || (myCookies["Name"] == ""))
            {
                lblUser.Text = "Welcome, new user.";
            }
            else
            {
                lblUser.Text = "Welcome Back " + myCookies["Name"];
            }

        }

        //This is used to get and display the image verifier string
        protected void verifierBT0_Click(object sender, EventArgs e)
        {
            ImageVerifier.ServiceClient imVer1 = new ImageVerifier.ServiceClient();
            verifierImage0.ImageUrl = "~/imageProcess.aspx";
            string userLength = "4";
            Session["userLength"] = userLength;
            string myStr = imVer1.GetVerifierString(userLength);
            Session["generatedString"] = myStr;
            verifierImage0.Visible = true;

        }

        //Login Buttons
        protected void Button2_Click(object sender, EventArgs e)
        {
            //This creates an object from my services
            FinalServices.Service1Client xmlSer = new FinalServices.Service1Client();

            //The various variable that are needed for this button
            string[] theReturned = new String[3];
            bool checBox = false;
            string confirmation = "";
            Object thisLock = new Object();

            //This block creates the cookie and sets it to the username
            HttpCookie myCookies = new HttpCookie("myCookieId");
            myCookies["Name"] = nameTB0.Text;
            myCookies.Expires = DateTime.Now.AddDays(5);
            Response.Cookies.Add(myCookies);
            lblUser.Text = "Welcome " + myCookies["Name"]; 

            if (CheckBox1.Checked)
                checBox = true;

            try
            {
                //Checks if the generated string is the same as the one entered into the verifierTB0
                if (Session["generatedString"].Equals(verifierTB0.Text))
                {
                    lock (thisLock)
                    {
                        //Calls the checkXML operation form my services
                        theReturned = xmlSer.checkXML(Encrypt_Decrypt.Encrypt(nameTB0.Text),
                                                      Encrypt_Decrypt.Encrypt(passwordTB0.Text),
                                                      checBox);

                        //Directs to StaffPage2 if the admins credentials are correct else name doesn't exist
                        if (theReturned[2].Equals("Administrator") && theReturned[0].Equals("Unavailable")
                            && theReturned[1].Equals("Correct"))
                        {
                            loginCheck = true;
                            Response.Redirect("~/StaffPage2.aspx");
                        }
                        else if (theReturned[0].Equals("Available") && checBox == false)
                            Label1.Text = "The Username does not exist.";

                        //If the entered name is available and the 2 passwords match then add the person to the XML
                        if (theReturned[0].Equals("Available") && passwordTB0.Text.Equals(passwordTB1.Text) && checBox == true)
                        {
                            confirmation = xmlSer.addToXML(nameTB0.Text, passwordTB0.Text, "Member");
                            confirmation = string.Format(confirmation
                            + "\nYou will be redirected to the Member Page in a few seconds");
                            loginCheck = true;
                            Response.Redirect("~/Default.aspx");

                        }
                        else
                        {
                            //If name is unavailable display unavailabel error, else the passwords don't match
                            if (theReturned[0].Equals("Unavailable") && checBox == true)
                            {
                                Label1.Text = "That name is unavailable, please try another variation.";
                            }
                            else if (!passwordTB0.Text.Equals(passwordTB1.Text) && checBox == true)
                            {
                                Label1.Text = "The two passwords do not match.";
                            }
                        }

                        //This block is used to login the person and direct them the specific site
                        if (theReturned[0].Equals("Unavailable") && checBox == false)
                        {
                            if (theReturned[1].Equals("Correct"))
                            {
                                loginCheck = true;
                                if (theReturned[2].Equals("Member"))
                                    Response.Redirect("~/Default.aspx");

                                else if (theReturned[2].Equals("Staff"))
                                    Response.Redirect("~/StaffPage1.aspx");

                                else
                                    Label1.Text = "Sorry, type does not match.";
                            }
                            else
                            {
                                Label1.Text = "The password does not match the username";
                            }

                        }
                    }

                    //This if the login error check
                    if (theReturned[0].Equals("Available") && theReturned[1].Equals("Correct") && checBox == false)
                    {
                        Label1.Text = string.Format(confirmation
                            + "\nYou will be redirected to the Member Page in a few seconds");
                        loginCheck = true;
                        Response.Redirect("~/Default.aspx");
                    }

                }
                else
                {
                    Label1.Text = "You entered the incorrect verifier string.";
                }

            }
            catch { Label1.Text = "Please generate a verifier string."; }
        }

        //Shopping Cart Button
        protected void Button3_Click(object sender, EventArgs e)
        {
            //Redirect to the shopping cart page if they are logged in
            if (loginCheck == true)
                Response.Redirect("~/ShoppingCart.aspx");
            else
                Label2.Text = "You are not logged in.";
        }

        }
    }
