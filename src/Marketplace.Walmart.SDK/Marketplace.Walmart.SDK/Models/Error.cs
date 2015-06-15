using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Walmart.SDK.Models
{
    public class Error
    {
        public string summary { get; set; }
        public string requestId { get; set; }
        public List<Failure> failures { get; set; }

        public class Failure
        {
            public string type { get; set; }
            public string message { get; set; }
            public string code { get; set; }
            public string moreInfo { get; set; }
            public string domainObject { get; set; }
            public string field { get; set; }
        }
    }
}
