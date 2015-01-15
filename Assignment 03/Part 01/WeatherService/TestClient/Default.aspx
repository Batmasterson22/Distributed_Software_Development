<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Test Client for Web Services</h2>
    <p>Enter a Latitude and Longitude to find the Solar Intensity: </p>
    <p>Latitude:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="The Solar Intensity is:"></asp:Label>
&nbsp;<asp:Label ID="Label2" runat="server" Text="blank"></asp:Label>
    </p>
    <p>Longitude:
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </p>
    <p>----------------------------------------------------------------------------------------------------</p>
    <p>Enter a Zip Code to find the 5 day forecast:</p>
    <p>
        <asp:TextBox ID="zipTextBox" runat="server"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Submit" />
&nbsp;&nbsp; </p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="Today:"></asp:Label>
&nbsp;&nbsp;
        <asp:Label ID="Label8" runat="server" Text="blank"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label4" runat="server" Text="Day 2:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label9" runat="server" Text="blank"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label5" runat="server" Text="Day 3:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label10" runat="server" Text="blank"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label6" runat="server" Text="Day 4:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label11" runat="server" Text="blank"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label7" runat="server" Text="Day 5:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label12" runat="server" Text="blank"></asp:Label>
    </p>

    
</asp:Content>
