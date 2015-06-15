using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Walmart.SDK.Models
{
    public class OffersResult : APIResult
    {
        public List<Offer> Offers
        {
            get { return _offers ?? (_offers = new List<Offer>()); }
            set { _offers = value; }
        }
        List<Offer> _offers;
    }
}
