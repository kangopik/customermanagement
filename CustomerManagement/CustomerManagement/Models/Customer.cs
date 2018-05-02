using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerManagement.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public byte Gender { get; set; }
        public int PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string CompanyName { get; set; }
    }
}