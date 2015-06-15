using Marketplace.Walmart.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Walmart.SDK.Services
{
    public interface ICatalog
    {
        OffersResult GetOffers(OffersRequest request);
    }
}
