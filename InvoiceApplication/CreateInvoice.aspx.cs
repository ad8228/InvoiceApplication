using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.Data;
using BusinessLayer;

namespace InvoiceApplication
{
    public partial class CreateInvoice : System.Web.UI.Page
    {
        InvoiceBA invoiceBAObj = new InvoiceBA();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//upon post back you dont want the default selection (by overriding it by default selected value)
            {
                invoiceBAObj.GetClientList(ddlClientList);
            }
        }

        protected void ddlClientList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = ddlClientList.SelectedItem.Value;
            if (selectedValue != "Choose Client")
                lblClientAddress.Text = invoiceBAObj.GetClientAddressBA(selectedValue);
        }



        protected void save_Click(object sender, EventArgs e)
        {
            int iInvoiceID = invoiceBAObj.SaveInvoiceBA(BindInvoice());
            if (iInvoiceID > 0)
                invoiceBAObj.SaveInvoiceDetailsBA(BindInvoiceDetails(iInvoiceID));
            Response.Redirect("~/ViewInvoice.aspx");
        }

        #region Bind invoice
        protected Invoice BindInvoice()
        {
            Invoice objinvoice = new Invoice();
            if (txtInvoiceNum.Text != "")
            {
                objinvoice.InvoiceNumber = Convert.ToInt32(txtInvoiceNum.Text.Trim());
            }
            if (txtInvoiceDate.Text != "")
            {
                objinvoice.InvoiceDate = Convert.ToDateTime(txtInvoiceDate.Text);
            }
            if (ddlClientList.SelectedValue != "Choose Client")
            {
                objinvoice.ClientID = Convert.ToInt32(ddlClientList.SelectedValue);
            }

            string strTotalAmount = Request.Form[txtTotalAmount.UniqueID];
            if (strTotalAmount != null && strTotalAmount != "")
            {
                objinvoice.TotalAmount = Convert.ToDouble(strTotalAmount);
            }
            objinvoice.CreatedDate = DateTime.Now;
            objinvoice.UpdatedDate = DateTime.Now;
            objinvoice.Note = txtNotes.Text;
            return objinvoice;
        }
        #endregion

        #region BindInvoiceDetails to Dataset
        protected DataSet BindInvoiceDetails(int iInvoiceID)
        {
            string strAmount = Request.Form[txtAmount.UniqueID];
            string strAmount1 = Request.Form[txtAmount1.UniqueID];
            string strAmount2 = Request.Form[txtAmount2.UniqueID];
            string strAmount3 = Request.Form[txtAmount3.UniqueID];
            string strAmount4 = Request.Form[txtAmount4.UniqueID];

            DataTable table = new DataTable("ContentTable");
            DataSet ds = new DataSet();
            table.Columns.Add("Desc", typeof(string));
            table.Columns.Add("Hours", typeof(string));
            table.Columns.Add("Rate", typeof(string));
            table.Columns.Add("Amount", typeof(string));
            table.Columns.Add("ID", typeof(int));
            if (txtDescription.Text != "" || txtHours.Text != "" || txtRate.Text != "" || (strAmount != null && strAmount != ""))
                table.Rows.Add(txtDescription.Text, txtHours.Text, txtRate.Text, txtAmount.Text, iInvoiceID);
            if (txtDescription1.Text != "" || txtHours1.Text != "" || txtRate1.Text != "" || (strAmount1 != null && strAmount1 != ""))
                table.Rows.Add(txtDescription1.Text, txtHours1.Text, txtRate1.Text, txtAmount1.Text, iInvoiceID);
            if (txtDescription2.Text != "" || txtHours2.Text != "" || txtRate2.Text != "" || (strAmount2 != null && strAmount2 != ""))
                table.Rows.Add(txtDescription2.Text, txtHours2.Text, txtRate2.Text, txtAmount2.Text, iInvoiceID);
            if (txtDescription3.Text != "" || txtHours3.Text != "" || txtRate3.Text != "" || (strAmount3 != null && strAmount3 != ""))
                table.Rows.Add(txtDescription3.Text, txtHours3.Text, txtRate3.Text, txtAmount3.Text, iInvoiceID);
            if (txtDescription4.Text != "" || txtHours4.Text != "" || txtRate4.Text != "" || (strAmount4 != null && strAmount4 != ""))
                table.Rows.Add(txtDescription4.Text, txtHours4.Text, txtRate4.Text, txtAmount4.Text, iInvoiceID);
            ds.Tables.Add(table);
            return ds;
        }
        #endregion

    }
}