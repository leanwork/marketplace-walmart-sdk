using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Walmart.SDK.Models
{
    public class OffersRequest
    {
        public string display { get; set; }

        public int page { get; set; }

        public int page_size { get; set; }

        public string name { get; set; }

        public string name_exact { get; set; }

        public OffersRequest()
        {
            page_size = 10; // default
        }
    }
}
