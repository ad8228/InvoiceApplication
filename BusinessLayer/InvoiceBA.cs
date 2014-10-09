using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer; 
using Model;
using System.Data;
using System.Web;
using System.Web.UI.WebControls; 

namespace BusinessLayer
{
    public class InvoiceBA
    {
        DBConnection dbConn = new DBConnection();
        public void getClient(string name)
        {
           
        }

        public int SaveInvoiceBA(Invoice invObj)
        {
            int i = dbConn.SaveInvoiceDB(invObj);
            return i; 
        }

        public void SaveInvoiceDetailsBA(DataSet dsInvoiceDetails) {
            dbConn.SaveInvoiceDetailsDB(dsInvoiceDetails); 
        }

        public string GetClientAddressBA(string ClientID)
        {
            string lblAddress = dbConn.GetClientAddressDB(ClientID);
            return lblAddress; 
        }

        public void GetClientList(DropDownList ddlList) {
            dbConn.GetClientList(ddlList); 
        }

        public List<Invoice> ViewInvoiceBA(int pageIndex, int pageSize, out int totalRows)
        {
            List<Invoice> invoices = new List<Invoice>(); 
            invoices = dbConn.ViewInvoiceDB(pageIndex, pageSize, out totalRows);
            return invoices; 
        }
    }
}
