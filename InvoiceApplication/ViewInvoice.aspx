<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewInvoice.aspx.cs" Inherits="InvoiceApplication.ViewInvoice" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <head>
        <title></title>
    </head>

    <style type="text/css">
        .InvoiceGrid tr, td, th {
            border: 1px solid #D8D8D8;
        }

        .InvoiceGrid th {
            background-color: #F8F8F8;
        }
    </style>

    <div id="MainContent">

        <asp:GridView ID="InvoiceGridView" runat="server" AutoGenerateColumns="false"  CssClass="InvoiceGrid" CellSpacing="2" PageSize="15">
        <Columns>
            <asp:BoundField DataField="InvoiceNumber" HeaderText="Invoice Number"/>
            <asp:BoundField DataField="InvoiceDate" HeaderText="Invoice Date"/>
            <asp:BoundField DataField="clientName" HeaderText="Client Name"/>
            <asp:BoundField DataField="CreatedDate" HeaderText="Created Date"/>
            <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount"/>
        </Columns>
        </asp:GridView>
        <br />
        <asp:Repeater ID="repeaterPaging" runat="server">
            <ItemTemplate>
                <asp:LinkButton ID="linkButton" runat="server"
                    Text='<%# Eval("Text")%>' CommandArgument='<%# Eval("Value") %>'
                    Enabled='<%# Eval("Enabled")%>'
                    OnClick="linkButton_Click"
                    >
                    
                </asp:LinkButton>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>



