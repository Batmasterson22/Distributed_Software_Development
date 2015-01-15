<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron" style="font-size: 15px">
        <h1>Project 02 - XML Testers</h1>
        <p><a href="http://webstrar11.fulton.asu.edu/index.html" target="_blank">Return To Index</a></p>
        <p><strong>Problem 2.5:</strong></p>
        <p>You can enter one string of the form below or use the individual boxes:</p>
        <p>Enter: LastName,FirstName,ID,Password,Encryption(Yes/No),Work #,Cell #,Cell Provider,Catagory</p>
        <p>
            <asp:TextBox ID="TextBox1" runat="server" Width="650px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Font-Size="10pt" Height="20px" OnClick="Button1_Click" Text="Submit" />
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Nothing Yet"></asp:Label>
        </p>
        <p>----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</p>
        <p><strong>Problem 2.2:</strong></p>
        <p>Enter the URL of the XML and XSL files in which you would like transform into HTML</p>
        <p>XML -
            <asp:TextBox ID="TextBox11" runat="server" Width="600px">http://</asp:TextBox>
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" Font-Size="10pt" Height="20px" Text="Submit" OnClick="Button3_Click" />
        </p>
        <p>XSL -
            <asp:TextBox ID="TextBox12" runat="server" Width="600px">http://</asp:TextBox>
&nbsp;&nbsp;&nbsp; </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Nothing Yet"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;</p>
        <p>&nbsp;</p>
        
</div>
</asp:Content>
