<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateInvoice_New.aspx.cs" Inherits="InvoiceApplication.CreateInvoice_New" %>--%>

<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Sample.aspx.cs" Inherits="InvoiceApplication.Sample"  %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <style type="text/css">
        #invoiceTable {
            width: auto;
        }
    </style>
    <hr />
    <div id="invoiceTable">

        <table style="float: right">
            <tr>
                <td>Invoice Number:</td>
                <td>
                    <asp:TextBox ID="txtInvoiceNum" runat="server" Style="width: 60px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Invoice Date:</td>
                <td>
                    <asp:TextBox ID="txtInvoiceDate" runat="server" Style="width: 60px"></asp:TextBox></td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
        <table>
            <tr>
                <td>Choose Client:</td>
                <td>
                    <asp:DropDownList ID="ddlClientList" runat="server"></asp:DropDownList></td>
                <td></td>
                <td></td>
            </tr>
        </table>

        <table>
            <tr>
                <th>Description</th>
                <th>Hours</th>
                <th>Rate</th>
                <th>Amount</th>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" Style="width: 300px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtHours" runat="server" Style="width: 60px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtRate" runat="server" Style="width: 60px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtAmount" runat="server" Style="width: 80px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtDescription1" runat="server" Style="width: 300px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtHours1" runat="server" Style="width: 60px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtRate1" runat="server" Style="width: 60px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtAmount1" runat="server" Style="width: 80px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtDescription2" runat="server" Style="width: 300px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtHours2" runat="server" Style="width: 60px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtRate2" runat="server" Style="width: 60px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtAmount2" runat="server" Style="width: 80px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtDescription3" runat="server" Style="width: 300px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtHours3" runat="server" Style="width: 60px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtRate3" runat="server" Style="width: 60px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtAmount3" runat="server" Style="width: 80px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtDescription4" runat="server" Style="width: 300px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtHours4" runat="server" Style="width: 60px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtRate4" runat="server" Style="width: 60px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtAmount4" runat="server" Style="width: 80px"></asp:TextBox></td>
            </tr>

            <tr>
                <td></td>
                <td></td>
                <td>Total Amount:</td>
                <td>
                    <asp:TextBox ID="txtTotalAmount" runat="server" Style="width: 80px"></asp:TextBox></td>
            </tr>
        </table>
        <table>
            <tr>
                <td>Notes:</td>
                <td>
                    <asp:TextBox ID="txtNotes" TextMode="multiline" Columns="30" runat="server"></asp:TextBox></td>
            </tr>
        </table>
        <asp:Button ID="save" runat="server" Text="Save" OnClick="save_Click" />
        <asp:Button ID="cancel" runat="server" Text="Cancel" />
    </div>

</asp:Content>
