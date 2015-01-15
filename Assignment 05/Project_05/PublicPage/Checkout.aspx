<%@ Page Language="C#" AutoEventWireup="true" EnableViewStateMac="False" CodeBehind="Checkout.aspx.cs" Inherits="PublicPage.Checkout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>The Checkout Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h2>Your Order is complete</h2>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Return to main page" />
        </p>
    </div>
    </form>
</body>
</html>
