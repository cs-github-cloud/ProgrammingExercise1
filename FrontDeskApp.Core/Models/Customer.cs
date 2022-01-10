using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FrontDeskApp.Core.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerPhoneNumer { get; set; }
    }
}
