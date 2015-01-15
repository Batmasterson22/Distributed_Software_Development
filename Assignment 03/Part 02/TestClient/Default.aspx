<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Test Client for Web Services - Project 03 - Part 01 / Part 02</h2>
    <p style="text-decoration: underline"><strong>Project - 03 / Part - 01</strong></p>
    <p>Enter a Latitude and Longitude to find the Solar Intensity:</p>
    <p>Latitude:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
    <p>Longitude:
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="The Solar Intensity is:"></asp:Label>
&nbsp;<asp:Label ID="Label2" runat="server" Text="blank"></asp:Label>
    </p>
    <p>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</p>
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
    <p>
        ========================================================================================================================</p>
    <p style="text-decoration: underline">
        <strong>Project - 03 / Part - 02:&nbsp;&nbsp; </strong>
    </p>
    <p>
        <strong>Shopping Cart Service</strong>:
        Enter a solar panel item number and the amount to purchase (the vaild item numbers are XCS1432, XDF2283, XKS5476). If there are enough panels in stock to fill the order it will update SolarPanelStock.xml. XKS5476 only has 3 units available so it can be used to test the unavailable error message:</p>
    <p>
        &nbsp;</p>
    <p>
        Item Number:&nbsp;
        <asp:TextBox ID="buyTB1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="buyButton" runat="server" OnClick="buyButton_Click" Text="Submit" />
    </p>
    <p>
        Quantity:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="buyTB2" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="buyLabel" runat="server" Text="Nothing Purchased"></asp:Label>
    </p>
    <p>
        -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</p>
    <p>
        <strong>Credit Card Service</strong>: This service is the required <strong>RESTful service</strong>. The shopping cart service must be used first otherwise there will not be any items to process
        The credit card number should be of the form XXX-XXX-XXX-XXX (i.e.152-648-552-645):</p>
    <p>
        &nbsp;</p>
    <p>
        Credit Card Number: <asp:TextBox ID="creditTB1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="creditButton" runat="server" OnClick="creditButton_Click" Text="Submit" />
    </p>
    <p>
        <asp:Label ID="creditLabel" runat="server" Text="Nothing Processed"></asp:Label>
    </p>
    <p>
        -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</p>
    <p>
        <strong>Scheduling Service</strong>:
        To schedule the appointment enter a name and numbers for month, day, and time between 8AM - 6PM. If the time is available it will add the name to theSchedule.xml. 07/01 at 8AM is already booked so that date can be used to test the unavailable message or just run the same input twice:</p>
    <p>
        &nbsp;</p>
    <p>
        <asp:TextBox ID="nameTB" runat="server">Enter Name</asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="monthTB" runat="server" Width="89px">Enter Month</asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="dayTB" runat="server" Width="82px">Enter Day</asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="timeTB" runat="server" Width="82px">Enter Time</asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="schButton" runat="server" OnClick="schButton_Click" Text="Submit" />
    </p>
    <p>
        <asp:Label ID="schLabel" runat="server" Text="Nothing Scheduled"></asp:Label>
    </p>
    <p>
        &nbsp;</p>

    
</asp:Content>
