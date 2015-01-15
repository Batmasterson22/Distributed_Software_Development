<%@ Page Language="C#" AutoEventWireup="true" EnableViewStateMac="False" CodeBehind="MemberPage.aspx.cs" Inherits="PublicPage.MemberPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>The Member Page</title>
    <style type="text/css">


b,
strong {
  font-weight: bold;
}

*,
*:before,
*:after {
  -webkit-box-sizing: border-box;
     -moz-box-sizing: border-box;
          box-sizing: border-box;
}

  * {
    color: #000 !important;
    text-shadow: none !important;
    background: transparent !important;
    box-shadow: none !important;
  }
  
input[type="radio"],
input[type="checkbox"] {
  margin: 4px 0 0;
  margin-top: 1px \9;
  /* IE8-9 */

  line-height: normal;
}

input[type="checkbox"],
input[type="radio"] {
  padding: 0;
  box-sizing: border-box;
}

button,
input,
select[multiple],
textarea {
  background-image: none;
}

input,
button,
select,
textarea {
  font-family: inherit;
  font-size: inherit;
  line-height: inherit;
}

button,
input {
  line-height: normal;
}

button,
input,
select,
textarea {
  margin: 0;
  font-family: inherit;
  font-size: 100%;
}

label {
  display: inline-block;
  margin-bottom: 5px;
  font-weight: bold;
}

input[type="text"],
input[type="password"],
input[type="email"] {
    max-width: 280px;
}

button,
html input[type="button"],
input[type="reset"],
input[type="submit"] {
  cursor: pointer;
  -webkit-appearance: button;
}

    </style>
    <h2>The Member Page</h2>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h4>This page only has access to the shopping cart feature</h4>
    </div>
        <p>
        <asp:Label ID="lblUser" runat="server" Font-Bold="True" Text="Welcome New User!"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;--(Cookie example)</p>
    <p>
        <strong>Check the box to create a account:</strong>&nbsp;&nbsp;</p>
    <p>
        &nbsp;<asp:CheckBox ID="CheckBox1" runat="server" Text="Add Member" />
    </p>
        <p>
            The names currently stored in the XML file (Username/Password): Jason/1245=Admin, Mark/5246=Member, Tom/8546=Staff.</p>
        <p>
            Admin is a staff with more access and can add new members, staff, and other admins. Staff can add new members only.&nbsp;</p>
<p>
        <asp:TextBox ID="nameTB0" runat="server" Width="181px">Enter_Username</asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
<p>
        <asp:TextBox ID="passwordTB0" runat="server" Width="181px">Enter_Password</asp:TextBox>
    </p>
<p>
        <asp:TextBox ID="passwordTB1" runat="server" Width="181px">Re-enter_Password</asp:TextBox>
    </p>
    <p>
        You must generate a verifier string and enter the correct string to login or add a member:</p>
<p>
        <asp:Button ID="verifierBT0" runat="server" Text="Generate A String" OnClick="verifierBT0_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Image ID="verifierImage0" runat="server" />
    </p>
<p>
        <asp:TextBox ID="verifierTB0" runat="server" Width="181px">Enter_String</asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="Login" OnClick="Button2_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="Nothing added yet"></asp:Label>
        </p>
        <p>
            -----------------------------------------------------------------------------------------------------------------------------------</p>
        <p>
            Click the button to go to the shopping cart that uses session states to store shopping cart items.</p>
        <p>
            You must be logged in to an account.</p>
        <p>
            -----&gt;&nbsp;
            <asp:Button ID="Button3" runat="server" Height="22px" OnClick="Button3_Click" Text="Go to cart" Width="76px" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    </p>
        <p>
            &nbsp;</p>
    </form>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</body>
</html>
