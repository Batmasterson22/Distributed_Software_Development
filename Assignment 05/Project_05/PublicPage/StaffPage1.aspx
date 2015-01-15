<%@ Page Language="C#" AutoEventWireup="true" EnableViewStateMac="False" CodeBehind="StaffPage1.aspx.cs" Inherits="PublicPage.StaffPage1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>The Staff Page 01</title>
    <h2>The Staff Page 01 - Normal Staff, non-Administrator</h2>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h4>This page has access to the shopping cart feature and can add new members to the XML database</h4>
        <p>Normal staff can add members to the website:</p>
        <p>&nbsp;<asp:TextBox ID="userName" runat="server">Username</asp:TextBox>
        </p>
        <p>
            <asp:TextBox ID="password1" runat="server">Password</asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="password2" runat="server">Re-enter Password</asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add Member" />
        </p>
        <p>
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Go to Member Page" />
        </p>
    </div>
    </form>
</body>
</html>
