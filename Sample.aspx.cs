using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.Data;

namespace InvoiceApplication
{
    public partial class Sample : System.Web.UI.Page
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("select ClientID, ClientName from Client", connection);
                connection.Open();

                ddlClientList.DataSource = cmd.ExecuteReader();
                ddlClientList.DataTextField = "ClientName";
                ddlClientList.DataValueField = "ClientID";
                ddlClientList.DataBind();
            }
        }
        protected void save_Click(object sender, EventArgs e)
        {
            //SaveInvoiceDetails(BindInvoiceDetails());
            int iInvoiceID = SaveInvoice(BindInvoice());
            if (iInvoiceID > 0)
                SaveInvoiceDetails(BindInvoiceDetails(iInvoiceID));
        }
        protected Invoice BindInvoice()
        {
            Invoice objinvoice = new Invoice();
            objinvoice.InvoiceNumber = Convert.ToInt32(txtInvoiceNum.Text.Trim());
            objinvoice.InvoiceDate = Convert.ToDateTime(txtInvoiceDate.Text);
            objinvoice.ClientID = Convert.ToInt32(ddlClientList.SelectedValue);
            objinvoice.TotalAmount = Convert.ToInt32(txtTotalAmount.Text);
            objinvoice.CreatedDate = DateTime.Now;
            objinvoice.UpdatedDate = DateTime.Now;
            objinvoice.Note = txtNotes.Text;
            return objinvoice;
        }
        protected int SaveInvoice(Invoice objinvoice)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand cmdInvoice = new SqlCommand();
                cmdInvoice.Connection = connection;
                cmdInvoice.CommandText = "spCreateInvoice_New_New";
                cmdInvoice.CommandType = CommandType.StoredProcedure;
                cmdInvoice.Parameters.AddWithValue("@InvoiceNumber", objinvoice.InvoiceNumber);
                cmdInvoice.Parameters.AddWithValue("@InvoiceDate", objinvoice.InvoiceDate);
                cmdInvoice.Parameters.AddWithValue("@ClientID", objinvoice.ClientID);
                cmdInvoice.Parameters.AddWithValue("@TotalAmount", objinvoice.TotalAmount);
                cmdInvoice.Parameters.AddWithValue("@CreatedDate", objinvoice.CreatedDate);
                cmdInvoice.Parameters.AddWithValue("@UpdatedDate", DBNull.Value);
                cmdInvoice.Parameters.AddWithValue("@Notes", objinvoice.Note);
                cmdInvoice.Parameters.AddWithValue("@IsInvoice", "YES");
                //Add the output parameter to the command object
                SqlParameter outPutParameter = new SqlParameter();
                outPutParameter.ParameterName = "@InvoiceID";
                outPutParameter.SqlDbType = System.Data.SqlDbType.Int;
                outPutParameter.Direction = System.Data.ParameterDirection.Output;
                cmdInvoice.Parameters.Add(outPutParameter);
                cmdInvoice.ExecuteNonQuery();
                //Retrieve the value of the output parameter
                return Convert.ToInt32(outPutParameter.Value);
            }
        }
        protected DataSet BindInvoiceDetails(int iInvoiceID)
        {
            DataTable table = new DataTable("ContentTable");
            DataSet ds = new DataSet();
            table.Columns.Add("Desc", typeof(string));
            table.Columns.Add("Hours", typeof(string));
            table.Columns.Add("Rate", typeof(string));
            table.Columns.Add("Amount", typeof(string));
            table.Columns.Add("ID", typeof(int));
            if (txtDescription.Text != "" || txtHours.Text != "" || txtRate.Text != "" || txtAmount.Text != "")
                table.Rows.Add(txtDescription.Text, txtHours.Text, txtRate.Text, txtAmount.Text, iInvoiceID);
            if (txtDescription1.Text != "" || txtHours1.Text != "" || txtRate1.Text != "" || txtAmount1.Text != "")
                table.Rows.Add(txtDescription1.Text, txtHours1.Text, txtRate1.Text, txtAmount1.Text, iInvoiceID);
            if (txtDescription2.Text != "" || txtHours2.Text != "" || txtRate2.Text != "" || txtAmount2.Text != "")
                table.Rows.Add(txtDescription2.Text, txtHours2.Text, txtRate2.Text, txtAmount2.Text, iInvoiceID);
            if (txtDescription3.Text != "" || txtHours3.Text != "" || txtRate3.Text != "" || txtAmount3.Text != "")
                table.Rows.Add(txtDescription3.Text, txtHours3.Text, txtRate3.Text, txtAmount3.Text, iInvoiceID);
            if (txtDescription4.Text != "" || txtHours4.Text != "" || txtRate4.Text != "" || txtAmount4.Text != "")
                table.Rows.Add(txtDescription4.Text, txtHours4.Text, txtRate4.Text, txtAmount4.Text, iInvoiceID);
            ds.Tables.Add(table);
            return ds;
        }
        protected void SaveInvoiceDetails(DataSet dsInvoiceDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmdInvoice = new SqlCommand();
                cmdInvoice.Connection = connection;
                cmdInvoice.CommandText = "spCreateInvoiceDetails_New_New";
                cmdInvoice.CommandType = CommandType.StoredProcedure;
                cmdInvoice.Parameters.AddWithValue("XMLdataInvoiceDetails", dsInvoiceDetails.GetXml());
                cmdInvoice.ExecuteNonQuery();
            }
        }
        protected void SaveInvoiceDetails(Invoice objinvoice, InvoiceDetails objinvoicedetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand cmdInvoice = new SqlCommand();
                cmdInvoice.Connection = connection;
                cmdInvoice.CommandText = "spCreateInvoice_New";
                cmdInvoice.CommandType = CommandType.StoredProcedure;
                cmdInvoice.Parameters.AddWithValue("@InvoiceNumber", objinvoice.InvoiceNumber);
                cmdInvoice.Parameters.AddWithValue("@InvoiceDate", objinvoice.InvoiceDate);
                cmdInvoice.Parameters.AddWithValue("@ClientID", objinvoice.ClientID);
                cmdInvoice.Parameters.AddWithValue("@TotalAmount", objinvoice.TotalAmount);
                cmdInvoice.Parameters.AddWithValue("@CreatedDate", objinvoice.CreatedDate);
                cmdInvoice.Parameters.AddWithValue("@UpdatedDate", DBNull.Value);
                cmdInvoice.Parameters.AddWithValue("@Notes", objinvoice.Note);
                cmdInvoice.Parameters.AddWithValue("@Desc", objinvoicedetails.Description);
                cmdInvoice.Parameters.AddWithValue("@Hours", objinvoicedetails.Hours.ToString());
                cmdInvoice.Parameters.AddWithValue("@Rate", objinvoicedetails.Rate.ToString());
                cmdInvoice.Parameters.AddWithValue("@Amount", objinvoicedetails.Amount.ToString());
                cmdInvoice.ExecuteNonQuery();
            }
        }
    }
}