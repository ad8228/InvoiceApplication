using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Client
    {
        public int clientID { get; set; }
        public string ClientName { get; set; }
        public string TelePhoneNUmber { get; set; }
        public string EmailID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string zip { get; set; }
        public string ContactPerson { get; set; }
    }
}
