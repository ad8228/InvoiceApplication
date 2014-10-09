using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace Model
{
    public class InvoiceDetails
    {
        public int invoiceDetailID { get; set; }
        public int InvoiceID { get; set; }
        public string Description { get; set; }
        public int Hours { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
    }
}
