<%@ Page Language="C#" AutoEventWireup="true" EnableViewStateMac="False" CodeBehind="StaffPage2.aspx.cs" Inherits="PublicPage.StaffPage2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>The Staff Page 02</title>
    <h2>The Staff Page 02 - Administrator Access</h2>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h4>This page has can modifie the available items, can add new members, and can add staff to the XML database</h4>
        The administrator has access to the other features and can also specify the access level. (i.e. Administrator, Staff, or Member)<br />
        <p><asp:TextBox ID="userName" runat="server">Username</asp:TextBox>
        </p>
        <p>
            <asp:TextBox ID="password1" runat="server">Password</asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="password2" runat="server">Re-enter Password</asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;</p>
        <p>
            &nbsp;<asp:TextBox ID="type" runat="server">Access Type</asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add Member" />
        </p>
        <p>
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Go to Staff Page" />
        </p>
        <p>
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Go to Member Page" />
        </p>
    </div>
    </form>
</body>
</html>
