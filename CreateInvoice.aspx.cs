//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using Model;
//using System.Data;

//namespace InvoiceApplication
//{
//    public partial class CreateInvoice : System.Web.UI.Page
//    {
//        string ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

//        protected void Page_Load(object sender, EventArgs e)
//        {
//            //string ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
//            using (SqlConnection connection = new SqlConnection(ConnectionString))
//            {
//                SqlCommand cmd = new SqlCommand("select ClientID, ClientName from Client", connection);
//                connection.Open();

//                ddlClientList.DataSource = cmd.ExecuteReader();
//                ddlClientList.DataTextField = "ClientName";
//                ddlClientList.DataValueField = "ClientID";
//                ddlClientList.DataBind();
//            }
//        }

//        protected void save_Click(object sender, EventArgs e)
//        {
//            //Data Source=ANNIDESHAR;Initial Catalog=InvoiceApplication;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False
//            //int invoiceNum = Convert.ToInt32(Request.Form["invoiceNum"]);
//            //DateTime invoiceDate = Convert.ToDateTime(Request.Form["invoiceDate"]); 
//            //double totalAmount = Convert.ToDouble(Request.Form["totalAmount"]);
//            //DateTime createDate = Convert.ToDateTime(Request.Form["createdDate"]);
//            //DateTime updatedDate = Convert.ToDateTime(Request.Form["updatedDate"]);

//            // return List<InvoiceDetails> and Invoice //2 objects 
//            //using (SqlConnection connection = new SqlConnection(ConnectionString))
//            //{
//            //    if (connection.State == ConnectionState.Closed)
//            //    {
//            //        connection.Open();
//            //    }             

//            //    SqlCommand cmdInvoice = new SqlCommand();
//            //    cmdInvoice.Connection = connection;
//            //    cmdInvoice.CommandText = "spCreateInvoice";
//            //    cmdInvoice.CommandType = CommandType.StoredProcedure;
//            //    cmdInvoice.Parameters.AddWithValue("@InvoiceNumber", txtInvoiceNum.Text.ToString());
//            //    cmdInvoice.Parameters.AddWithValue("@InvoiceDate", txtInvoiceDate.Text.ToString());
//            //    cmdInvoice.Parameters.AddWithValue("@ClientID", Convert.ToInt32(ddlClientList.SelectedValue));
//            //    cmdInvoice.Parameters.AddWithValue("@TotalAmount", Convert.ToInt32(txtTotalAmount.Text.ToString()));
//            //    cmdInvoice.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
//            //    cmdInvoice.Parameters.AddWithValue("@UpdatedDate", DBNull.Value);
//            //    cmdInvoice.Parameters.AddWithValue("@Notes", txtNotes.Text.ToString());
//            //    cmdInvoice.Parameters.AddWithValue("@Desc", txtDescription.Text.ToString());
//            //    cmdInvoice.Parameters.AddWithValue("@Hours", txtHours.Text.ToString());
//            //    cmdInvoice.Parameters.AddWithValue("@Rate", txtRate.Text.ToString());
//            //    cmdInvoice.Parameters.AddWithValue("@Amount", txtAmount.Text.ToString());
//            //    cmdInvoice.ExecuteNonQuery();
//            //}
//            //BindInvoiceDetails();
//            SaveInvoiceDetails(BindInvoiceDetail());
//        }

//        protected DataSet BindInvoiceDetail()
//        {
//            DataTable table = new DataTable("ContentTable");
//            DataSet ds = new DataSet();
//            table.Columns.Add("InvoiceNumber", typeof(string));
//            table.Columns.Add("InvoiceDate", typeof(string));
//            table.Columns.Add("ClientID", typeof(int));
//            table.Columns.Add("TotalAmount", typeof(int));
//            table.Columns.Add("CreatedDate", typeof(DateTime));
//            table.Columns.Add("UpdatedDate", typeof(DateTime));
//            table.Columns.Add("Notes", typeof(string));
//            table.Columns.Add("Desc", typeof(string));
//            table.Columns.Add("Hours", typeof(string));
//            table.Columns.Add("Rate", typeof(string));
//            table.Columns.Add("Amount", typeof(string));

//            table.Rows.Add(txtInvoiceNum.Text, txtInvoiceDate.Text, Convert.ToInt32(ddlClientList.SelectedValue), Convert.ToInt32(txtTotalAmount.Text.ToString()),
//              DateTime.Now, DateTime.Now, txtNotes.Text, txtDescription.Text, txtHours.Text, txtRate.Text, txtAmount.Text);
//            table.Rows.Add(txtInvoiceNum.Text, txtInvoiceDate.Text, Convert.ToInt32(ddlClientList.SelectedValue), Convert.ToInt32(txtTotalAmount.Text.ToString()),
//              DateTime.Now, DateTime.Now, txtNotes.Text, txtDescription1.Text, txtHours1.Text, txtRate1.Text, txtAmount1.Text);
//            table.Rows.Add(txtInvoiceNum.Text, txtInvoiceDate.Text, Convert.ToInt32(ddlClientList.SelectedValue), Convert.ToInt32(txtTotalAmount.Text.ToString()),
//              DateTime.Now, DateTime.Now, txtNotes.Text, txtDescription2.Text, txtHours2.Text, txtRate2.Text, txtAmount2.Text);
//            table.Rows.Add(txtInvoiceNum.Text, txtInvoiceDate.Text, Convert.ToInt32(ddlClientList.SelectedValue), Convert.ToInt32(txtTotalAmount.Text.ToString()),
//              DateTime.Now, DateTime.Now, txtNotes.Text, txtDescription3.Text, txtHours3.Text, txtRate3.Text, txtAmount3.Text);
//            table.Rows.Add(txtInvoiceNum.Text, txtInvoiceDate.Text, Convert.ToInt32(ddlClientList.SelectedValue), Convert.ToInt32(txtTotalAmount.Text.ToString()),
//              DateTime.Now, DateTime.Now, txtNotes.Text, txtDescription4.Text, txtHours4.Text, txtRate4.Text, txtAmount4.Text);

//            ds.Tables.Add(table);
//            return ds;
//        }

//        protected void BindInvoiceDetails()
//        {
//            Invoice objinvoice = new Invoice();
//            InvoiceDetails objinvoicedetails = new InvoiceDetails();
//            List<InvoiceDetails> listobjinvoicedetails = new List<InvoiceDetails>(); 
//            objinvoice.InvoiceNumber = Convert.ToInt32(txtInvoiceNum.Text.Trim());
//            objinvoice.InvoiceDate = Convert.ToDateTime(txtInvoiceDate.Text);
//            objinvoice.ClientID = Convert.ToInt32(ddlClientList.SelectedValue);
//            objinvoice.TotalAmount = Convert.ToInt32(txtTotalAmount.Text);
//            objinvoice.CreatedDate = DateTime.Now;
//            objinvoice.UpdatedDate = DateTime.Now;
//            objinvoice.Note = txtNotes.Text;


//            {
//                if (txtDescription != null || txtHours != null || txtRate != null || txtAmount != null)
//                {
//                    objinvoicedetails.Description = txtDescription.Text;
//                    objinvoicedetails.Hours = Convert.ToInt32(txtHours.Text);
//                    objinvoicedetails.Rate = Convert.ToDouble(txtRate.Text);
//                    objinvoicedetails.Amount = Convert.ToDouble(txtAmount.Text);
//                }
//                //listobjinvoicedetails.Add(objinvoicedetails);

//                if (txtDescription1 != null || txtHours1 != null || txtRate1 != null || txtAmount1 != null)
//                    objinvoicedetails.Description = txtDescription1.Text;
//                objinvoicedetails.Hours = Convert.ToInt32(txtHours1.Text);
//                objinvoicedetails.Rate = Convert.ToDouble(txtRate1.Text);
//                objinvoicedetails.Amount = Convert.ToDouble(txtAmount1.Text);

//                //listobjinvoicedetails.Add(objinvoicedetails);

//                if (txtDescription2 != null || txtHours2 != null || txtRate2 != null || txtAmount2 != null)
//                    objinvoicedetails.Description = txtDescription2.Text;
//                objinvoicedetails.Hours = Convert.ToInt32(txtHours2.Text);
//                objinvoicedetails.Rate = Convert.ToDouble(txtRate2.Text);
//                objinvoicedetails.Amount = Convert.ToDouble(txtAmount2.Text);

//                //listobjinvoicedetails.Add(objinvoicedetails);

//                if (txtDescription3 != null || txtHours3 != null || txtRate3 != null || txtAmount3 != null)
//                    objinvoicedetails.Description = txtDescription3.Text;
//                objinvoicedetails.Hours = Convert.ToInt32(txtHours3.Text);
//                objinvoicedetails.Rate = Convert.ToDouble(txtRate3.Text);
//                objinvoicedetails.Amount = Convert.ToDouble(txtAmount3.Text);
//                if (objinvoicedetails != null)
//                {
//                    listobjinvoicedetails.Add(objinvoicedetails);
//                }

//                if (txtDescription4 != null || txtHours4 != null || txtRate4 != null || txtAmount4 != null)
//                    objinvoicedetails.Description = txtDescription4.Text;
//                objinvoicedetails.Hours = Convert.ToInt32(txtHours4.Text);
//                objinvoicedetails.Rate = Convert.ToDouble(txtRate4.Text);
//                objinvoicedetails.Amount = Convert.ToDouble(txtAmount4.Text);

//                listobjinvoicedetails.Add(objinvoicedetails);
//            }

//           // SaveInvoiceDetails(objinvoice, listobjinvoicedetails);
//        }

//        protected void SaveInvoiceDetails(Invoice objinvoice, InvoiceDetails objinvoicedetails)
//        {
//            using (SqlConnection connection = new SqlConnection(ConnectionString))
//            {
//                if (connection.State == ConnectionState.Closed)
//                {
//                    connection.Open();
//                }

//                SqlCommand cmdInvoice = new SqlCommand();
//                cmdInvoice.Connection = connection;
//                cmdInvoice.CommandText = "spCreateInvoice";
//                cmdInvoice.CommandType = CommandType.StoredProcedure;
//                cmdInvoice.Parameters.AddWithValue("@InvoiceNumber", objinvoice.InvoiceNumber);
//                cmdInvoice.Parameters.AddWithValue("@InvoiceDate", objinvoice.InvoiceDate);
//                cmdInvoice.Parameters.AddWithValue("@ClientID", objinvoice.ClientID);
//                cmdInvoice.Parameters.AddWithValue("@TotalAmount", objinvoice.TotalAmount);
//                cmdInvoice.Parameters.AddWithValue("@CreatedDate", objinvoice.CreatedDate);
//                cmdInvoice.Parameters.AddWithValue("@UpdatedDate", DBNull.Value);
//                cmdInvoice.Parameters.AddWithValue("@Notes", objinvoice.Note);
//                cmdInvoice.Parameters.AddWithValue("@Desc", objinvoicedetails.Description);
//                cmdInvoice.Parameters.AddWithValue("@Hours", objinvoicedetails.Hours.ToString());
//                cmdInvoice.Parameters.AddWithValue("@Rate", objinvoicedetails.Rate.ToString());
//                cmdInvoice.Parameters.AddWithValue("@Amount", objinvoicedetails.Amount.ToString());
//                cmdInvoice.ExecuteNonQuery();
//            }
//        }

//        protected void SaveInvoiceDetails(DataSet ds)
//        {
//            using (SqlConnection connection = new SqlConnection(ConnectionString))
//            {
//                if (connection.State == ConnectionState.Closed)
//                {
//                    connection.Open();
//                }

//                SqlCommand cmdInvoice = new SqlCommand();
//                cmdInvoice.Connection = connection;
//                cmdInvoice.CommandText = "spCreateInvoice_New";
//                cmdInvoice.CommandType = CommandType.StoredProcedure;
//                cmdInvoice.Parameters.AddWithValue("XMLdata", ds.GetXml());
//                //cmdInvoice.Parameters.AddWithValue("@InvoiceNumber", objinvoice.InvoiceNumber);
//                //cmdInvoice.Parameters.AddWithValue("@InvoiceDate", objinvoice.InvoiceDate);
//                //cmdInvoice.Parameters.AddWithValue("@ClientID", objinvoice.ClientID);
//                //cmdInvoice.Parameters.AddWithValue("@TotalAmount", objinvoice.TotalAmount);
//                //cmdInvoice.Parameters.AddWithValue("@CreatedDate", objinvoice.CreatedDate);
//                //cmdInvoice.Parameters.AddWithValue("@UpdatedDate", DBNull.Value);
//                //cmdInvoice.Parameters.AddWithValue("@Notes", objinvoice.Note);
//                //cmdInvoice.Parameters.AddWithValue("@Desc", objinvoicedetails.Description);
//                //cmdInvoice.Parameters.AddWithValue("@Hours", objinvoicedetails.Hours.ToString());
//                //cmdInvoice.Parameters.AddWithValue("@Rate", objinvoicedetails.Rate.ToString());
//                //cmdInvoice.Parameters.AddWithValue("@Amount", objinvoicedetails.Amount.ToString());
//                cmdInvoice.ExecuteNonQuery();
//            }
//        }
//    }
//}