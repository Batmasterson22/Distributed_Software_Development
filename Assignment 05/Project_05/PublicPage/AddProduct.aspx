<%@ Page Language="C#" AutoEventWireup="true" EnableViewStateMac="False" CodeBehind="AddProduct.aspx.cs" Inherits="PublicPage.AddProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Products To Catalog</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h3>This page is used to add another product to the existing catalog using Session States</h3>
        <p><strong>Enter the solar panel manufacture:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </strong></p>
        <p style="font-weight: 700">Enter the solar panel model number:&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <p style="font-weight: 700">Enter the solat panel price:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </p>
        <p style="font-weight: 700">
            <asp:Button ID="Button2" runat="server" Height="22px" OnClick="Button2_Click" Text="Add to Catalog" Width="157px" />
        </p>
    </div>
    </form>
</body>
</html>
