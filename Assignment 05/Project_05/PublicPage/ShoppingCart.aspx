<%@ Page Language="C#" AutoEventWireup="true" EnableViewStateMac="False" CodeBehind="ShoppingCart.aspx.cs" Inherits="PublicPage.ShoppingCart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Shopping Cart Page</title>
    <h2>Shopping Cart Page</h2>
    <p style="font-weight: 700">This shopping cart uses session states to save the items in the cart.</p>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <p>

            <asp:ListBox ID="ListBox1" runat="server" Height="147px" Width="290px"></asp:ListBox>

        </p>
        <p>

        &nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Height="26px" OnClick="Button1_Click" Text="Solar Panel Info" Width="115px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Height="26px" OnClick="Button2_Click" Text="Add New Product" Width="115px" />

        </p>
        <p>

        &nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" Height="26px" OnClick="Button3_Click" Text="Add to Cart" Width="116px" />

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="blank"></asp:Label>

        </p>
        <p>

            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>

        </p>
        <p>

            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>

        </p>
        <p>

            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>

        </p>
    </div>
    </form>
</body>
</html>
