using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontDeskApp.Api.Resources
{
    public class CustomerResource
    {
        public int CustomerId { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerPhoneNumer { get; set; }
    }
}
