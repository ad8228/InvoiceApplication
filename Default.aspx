<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InvoiceApplication._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                
            </hgroup>
         
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Invoice Application:</h3>
    <asp:Label ID="Label1" runat="server" Text="FirstName"></asp:Label>
    <asp:TextBox ID="fName" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label2" runat="server" Text="LastName"></asp:Label>
    <asp:TextBox ID="lName" runat="server"></asp:TextBox>
</asp:Content>