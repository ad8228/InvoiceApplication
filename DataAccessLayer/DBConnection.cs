using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;

namespace DataAccessLayer
{
    public class DBConnection
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

        #region Save Invoice
        public int SaveInvoiceDB(Invoice objinvoice)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand cmdInvoice = new SqlCommand();
                cmdInvoice.Connection = connection;
                cmdInvoice.CommandText = "spCreateInvoice";
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
        #endregion

        #region save Invoice details
        public void SaveInvoiceDetailsDB(DataSet dsInvoiceDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmdInvoice = new SqlCommand();
                cmdInvoice.Connection = connection;
                cmdInvoice.CommandText = "spCreateInvoiceDetails";
                cmdInvoice.CommandType = CommandType.StoredProcedure;
                cmdInvoice.Parameters.AddWithValue("XMLdataInvoiceDetails", dsInvoiceDetails.GetXml());
                cmdInvoice.ExecuteNonQuery();
            }
        }
        #endregion

        #region get client address
        public string GetClientAddressDB(string ClientID)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                connection.Open();
                cmd.Connection = connection;
                cmd.CommandText = "spGetAddressForClient";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClientID", ClientID);
                SqlDataReader dr = cmd.ExecuteReader();
                string lblClientAddress = "";
                while (dr.Read())
                {
                    lblClientAddress = dr[0].ToString();
                }
                return lblClientAddress;
            }
        }
        #endregion

        #region populate dropdown with client names
        public void GetClientList(DropDownList ddlClientList)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                connection.Open();
                cmd.Connection = connection;
                cmd.CommandText = "spGetClient";
                cmd.CommandType = CommandType.StoredProcedure;
                ddlClientList.DataSource = cmd.ExecuteReader();
                ddlClientList.DataTextField = "ClientName";
                ddlClientList.DataValueField = "ClientID";
                ddlClientList.DataBind();
                ddlClientList.Items.Insert(0, "Choose Client");
            }
        }
        #endregion

        //#region populate gridview with invoice
        //public void ViewInvoiceDB(GridView invoiceGridView)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        connection.Open();
        //        cmd.Connection = connection;
        //        cmd.CommandText = "spViewInvoice";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //        DataSet ds = new DataSet();
        //        adapter.Fill(ds);
        //        invoiceGridView.DataSource = ds;
        //        invoiceGridView.DataBind();
        //    }
        //}
        //#endregion


        #region populate gridview with invoice with paging
        public List<Invoice> ViewInvoiceDB(int pageIndex, int pageSize, out int totalRows)
        {
            totalRows = 0; 
            List<Invoice> invoiceList = new List<Invoice>(); 
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            { 
                SqlCommand cmd = new SqlCommand("spGetInvoice_ByPageIndex_And_PageSize", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramStartIndex = new SqlParameter();
                paramStartIndex.ParameterName = "@PageIndex";
                paramStartIndex.Value = pageIndex;
                cmd.Parameters.Add(paramStartIndex);

                SqlParameter paramPageSize = new SqlParameter();
                paramPageSize.ParameterName = "@PageSize";
                paramPageSize.Value = pageSize;
                cmd.Parameters.Add(paramPageSize);

                SqlParameter paramOutputTotalRows = new SqlParameter();
                paramOutputTotalRows.ParameterName = "@TotalRows";
                paramOutputTotalRows.Direction = ParameterDirection.Output;
                paramOutputTotalRows.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(paramOutputTotalRows);

                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Invoice invoices = new Invoice(); 
                    invoices.InvoiceDate = Convert.ToDateTime(rdr["InvoiceDate"]);
                    invoices.InvoiceNumber = Convert.ToInt32(rdr["InvoiceNumber"]);
                    invoices.TotalAmount = Convert.ToInt32(rdr["TotalAmount"]);
                    invoices.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]); 
                    invoices.clientName = rdr["ClientName"].ToString();

                    invoiceList.Add(invoices); 


                   //rdr.Close(); //close reader before we return output parameter
                }
                    rdr.Close();
                    totalRows = (int)cmd.Parameters["@TotalRows"].Value; 
            }
            return invoiceList; 
        }
        #endregion

    }
}
