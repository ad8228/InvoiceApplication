<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="CreateInvoice.aspx.cs" Inherits="InvoiceApplication.CreateInvoice" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <script type="text/javascript">
        function NumericValidation(val, control, errorMessage) {
            var orignalValue = val;
            val = val.replace(/[0-9]*/g, "");
            if (val != '') {
                alert(errorMessage);
                control.val(null);
                return false;
            }
        }
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            //$("input#MainContent_txtAmount").attr("disabled", "disabled");
            //1
            $('input#MainContent_txtHours').change(function () {
                if (($("input#MainContent_txtHours").val() != null && $("input#MainContent_txtHours").val() != "") && ($("input#MainContent_txtRate").val() != null && $("input#MainContent_txtRate").val() != "")) {
                    $("input#MainContent_txtAmount").val(parseInt(($("input#MainContent_txtHours").val())) * parseInt(($("input#MainContent_txtRate").val())));

                }
                else
                    $("input#MainContent_txtAmount").val(null);
                TotalSumAmount();
                NumericValidation(($(this).val()), $('input#MainContent_txtHours'), "Hours should be numeric value.");

            });
            $('input#MainContent_txtRate').change(function () {
                if (($("input#MainContent_txtHours").val() != null && $("input#MainContent_txtHours").val() != "") && ($("input#MainContent_txtRate").val() != null && $("input#MainContent_txtRate").val() != "")) {
                    $("input#MainContent_txtAmount").val(parseInt(($("input#MainContent_txtHours").val())) * parseInt(($("input#MainContent_txtRate").val())));

                }
                else
                    $("input#MainContent_txtAmount").val(null);
                TotalSumAmount();
                NumericValidation(($(this).val()), $('input#MainContent_txtRate'), "Rate should be numeric value.");

            });
            //2
            $('input#MainContent_txtHours1').change(function () {
                if (($("input#MainContent_txtHours1").val() != null && $("input#MainContent_txtHours1").val() != "") && ($("input#MainContent_txtRate1").val() != null && $("input#MainContent_txtRate1").val() != "")) {
                    $("input#MainContent_txtAmount1").val(parseInt(($("input#MainContent_txtHours1").val())) * parseInt(($("input#MainContent_txtRate1").val())));
                }
                else
                    $("input#MainContent_txtAmount1").val(null);
                TotalSumAmount();
                NumericValidation(($(this).val()), $('input#MainContent_txtHours1'), "Hours should be numeric value.");
            });
            $('input#MainContent_txtRate1').change(function () {
                if (($("input#MainContent_txtHours1").val() != null && $("input#MainContent_txtHours1").val() != "") && ($("input#MainContent_txtRate1").val() != null && $("input#MainContent_txtRate1").val() != "")) {
                    $("input#MainContent_txtAmount1").val(parseInt(($("input#MainContent_txtHours1").val())) * parseInt(($("input#MainContent_txtRate1").val())));
                }
                else
                    $("input#MainContent_txtAmount1").val(null);
                TotalSumAmount();
                NumericValidation(($(this).val()), $('input#MainContent_txtRate1'), "Rate should be numeric value.");
            });
            //3
            $('input#MainContent_txtHours2').change(function () {
                if (($("input#MainContent_txtHours2").val() != null && $("input#MainContent_txtHours2").val() != "") && ($("input#MainContent_txtRate2").val() != null && $("input#MainContent_txtRate2").val() != "")) {
                    $("input#MainContent_txtAmount2").val(parseInt(($("input#MainContent_txtHours2").val())) * parseInt(($("input#MainContent_txtRate2").val())));
                }
                else
                    $("input#MainContent_txtAmount2").val(null);
                TotalSumAmount();
                NumericValidation(($(this).val()), $('input#MainContent_txtHours2'), "Hours should be numeric value.");
            });
            $('input#MainContent_txtRate2').change(function () {
                if (($("input#MainContent_txtHours2").val() != null && $("input#MainContent_txtHours2").val() != "") && ($("input#MainContent_txtRate2").val() != null && $("input#MainContent_txtRate2").val() != "")) {
                    $("input#MainContent_txtAmount2").val(parseInt(($("input#MainContent_txtHours2").val())) * parseInt(($("input#MainContent_txtRate2").val())));
                }
                else
                    $("input#MainContent_txtAmount2").val(null);
                TotalSumAmount();
                NumericValidation(($(this).val()), $('input#MainContent_txtRate2'), "Rate should be numeric value.");
            });
            //4
            $('input#MainContent_txtHours3').change(function () {
                if (($("input#MainContent_txtHours3").val() != null && $("input#MainContent_txtHours3").val() != "") && ($("input#MainContent_txtRate3").val() != null && $("input#MainContent_txtRate3").val() != "")) {
                    $("input#MainContent_txtAmount3").val(parseInt(($("input#MainContent_txtHours3").val())) * parseInt(($("input#MainContent_txtRate3").val())));
                }
                else
                    $("input#MainContent_txtAmount3").val(null);
                TotalSumAmount();
                NumericValidation(($(this).val()), $('input#MainContent_txtHours3'), "Hours should be numeric value.");
            });
            $('input#MainContent_txtRate3').change(function () {
                if (($("input#MainContent_txtHours3").val() != null && $("input#MainContent_txtHours3").val() != "") && ($("input#MainContent_txtRate3").val() != null && $("input#MainContent_txtRate3").val() != "")) {
                    $("input#MainContent_txtAmount3").val(parseInt(($("input#MainContent_txtHours3").val())) * parseInt(($("input#MainContent_txtRate3").val())));
                } else
                    $("input#MainContent_txtAmount3").val(null);
                TotalSumAmount();
                NumericValidation(($(this).val()), $('input#MainContent_txtRate3'), "Rate should be numeric value.");
            });
            //5
            $('input#MainContent_txtHours4').change(function () {
                if (($("input#MainContent_txtHours4").val() != null && $("input#MainContent_txtHours4").val() != "") && ($("input#MainContent_txtRate4").val() != null && $("input#MainContent_txtRate4").val() != "")) {
                    $("input#MainContent_txtAmount4").val(parseInt(($("input#MainContent_txtHours4").val())) * parseInt(($("input#MainContent_txtRate4").val())));
                } else
                    $("input#MainContent_txtAmount4").val(null);
                TotalSumAmount();
                NumericValidation(($(this).val()), $('input#MainContent_txtHours4'), "Hours should be numeric value.");
            });
            $('input#MainContent_txtRate4').change(function () {
                if (($("input#MainContent_txtHours4").val() != null && $("input#MainContent_txtHours4").val() != "") && ($("input#MainContent_txtRate4").val() != null && $("input#MainContent_txtRate4").val() != "")) {
                    $("input#MainContent_txtAmount4").val(parseInt(($("input#MainContent_txtHours4").val())) * parseInt(($("input#MainContent_txtRate4").val())));
                } else
                    $("input#MainContent_txtAmount4").val(null);
                TotalSumAmount();
                NumericValidation(($(this).val()), $('input#MainContent_txtRate4'), "Rate should be numeric value.");
            });
        });
        function TotalSumAmount() {
            var v1 = (($("input#MainContent_txtAmount").val()) != null && ($("input#MainContent_txtAmount").val() != "") ? parseInt($("input#MainContent_txtAmount").val()) : 0)
                    + (($("input#MainContent_txtAmount1").val()) != null && ($("input#MainContent_txtAmount1").val() != "") ? parseInt($("input#MainContent_txtAmount1").val()) : 0)
                    + (($("input#MainContent_txtAmount2").val()) != null && ($("input#MainContent_txtAmount2").val() != "") ? parseInt($("input#MainContent_txtAmount2").val()) : 0)
                    + (($("input#MainContent_txtAmount3").val()) != null && ($("input#MainContent_txtAmount3").val() != "") ? parseInt($("input#MainContent_txtAmount3").val()) : 0)
                    + (($("input#MainContent_txtAmount4").val()) != null && ($("input#MainContent_txtAmount4").val() != "") ? parseInt($("input#MainContent_txtAmount4").val()) : 0)
            $("input#MainContent_txtTotalAmount").val(v1);
            // $("input#txtTotalAmount").val(v1);
        }
    </script>


    <script type="text/javascript">
        $(document).submit(function () {
            var dropdown = $('#MainContent_ddlClientList').val();
            if (dropdown == "Choose Client") {
                alert("Please select the client");
                return false;
            }

        });
    </script>

    
    <div id="MainContent">

        <table style="float: right" class="CreateInvoice">
            <tr>
                <td>Invoice Number:</td>
                <td>
                    <asp:TextBox ID="txtInvoiceNum" runat="server" Style="width: 60px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Invoice Date:</td>
                <td>
                    <asp:TextBox ID="txtInvoiceDate" runat="server" Style="width: 60px"></asp:TextBox>
                </td>
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
                    <asp:DropDownList ID="ddlClientList" runat="server" OnSelectedIndexChanged="ddlClientList_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList></td>
                <td></td>
                <td></td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="lblClientAddress" runat="server" Text=""></asp:Label></td>
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
                    <asp:TextBox ID="txtAmount" runat="server" Style="width: 80px" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtDescription1" runat="server" Style="width: 300px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtHours1" runat="server" Style="width: 60px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtRate1" runat="server" Style="width: 60px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtAmount1" runat="server" Style="width: 80px" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtDescription2" runat="server" Style="width: 300px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtHours2" runat="server" Style="width: 60px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtRate2" runat="server" Style="width: 60px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtAmount2" runat="server" Style="width: 80px" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtDescription3" runat="server" Style="width: 300px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtHours3" runat="server" Style="width: 60px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtRate3" runat="server" Style="width: 60px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtAmount3" runat="server" Style="width: 80px" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtDescription4" runat="server" Style="width: 300px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtHours4" runat="server" Style="width: 60px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtRate4" runat="server" Style="width: 60px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtAmount4" runat="server" Style="width: 80px" ReadOnly="true"></asp:TextBox></td>
            </tr>

            <tr>
                <td></td>
                <td></td>
                <td>Total Amount:</td>
                <td>
                    <asp:TextBox ID="txtTotalAmount" runat="server" Style="width: 80px" ReadOnly="true"></asp:TextBox></td>
            </tr>
        </table>
        <table>
            <tr>
                <td>Notes:</td>
                <td>
                    <asp:TextBox ID="txtNotes" TextMode="multiline" Columns="30" runat="server"></asp:TextBox></td>
            </tr>
        </table>
        <br />
        <asp:Button ID="save" runat="server" Text="Save" OnClick="save_Click" />
        <asp:Button ID="cancel" runat="server" Text="Cancel" OnClientClick="window.location.reload();" />
    </div>

</asp:Content>
