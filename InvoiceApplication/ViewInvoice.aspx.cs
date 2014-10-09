using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer; 

namespace InvoiceApplication
{
    public partial class ViewInvoice : System.Web.UI.Page
    {
        InvoiceBA invoiceBAobj = new InvoiceBA();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int totalRows = 0;
                InvoiceGridView.DataSource = invoiceBAobj.ViewInvoiceBA(0, InvoiceGridView.PageSize, out totalRows);
                InvoiceGridView.DataBind();

                DataBindRepeater(InvoiceGridView.PageIndex, InvoiceGridView.PageSize, totalRows);
            }

        }


        private void DataBindRepeater(int pageIndex, int pageSize, int totalRows)
        {
            int totalPages = totalRows / pageSize; 
            if((totalRows % pageSize) != 0)
            {
                totalPages += 1; 
            }

            List<ListItem> pages = new List<ListItem>(); 
            if(totalPages > 1)
            {
                for(int i = 1; i <= totalPages; i++)
                {
                    //i != (pageIndex + 1)) .. to decide which link to enable
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != (pageIndex + 1))); 
                }
            }
            repeaterPaging.DataSource = pages; 
            repeaterPaging.DataBind(); 
        }

        protected void linkButton_Click(object sender, EventArgs e)
        {
            int totalRows = 0;
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            pageIndex -= 1; //page num starts at 1 and page index starts at 0.
            InvoiceGridView.PageIndex = pageIndex;
            InvoiceGridView.DataSource = invoiceBAobj.ViewInvoiceBA(pageIndex, InvoiceGridView.PageSize, out totalRows);
            InvoiceGridView.DataBind();
            DataBindRepeater(pageIndex, InvoiceGridView.PageSize, totalRows); 

        }

       
    }
}


