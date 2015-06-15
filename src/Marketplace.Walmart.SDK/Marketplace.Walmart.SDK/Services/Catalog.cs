using Marketplace.Walmart.SDK.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Walmart.SDK.Services
{
    public class Catalog : APIServiceBase, ICatalog
    {
        #region ctor
        
        public Catalog()
            : base()
        {
        }
        public Catalog(string sellerId, string username, string password, bool sandbox = false)
            : base(sellerId, username, password, sandbox)
        {
        }

        #endregion

        public OffersResult GetOffers(OffersRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            OffersResult apiResult = new OffersResult();

            try
            {               
                var webRequest = CreateWebRequest();
                
                if (!String.IsNullOrWhiteSpace(request.display))
                {
                    webRequest.AddParameter("display", request.display);
                }
                if (!String.IsNullOrWhiteSpace(request.name))
                {
                    webRequest.AddParameter("name", request.name);
                }
                if (!String.IsNullOrWhiteSpace(request.name_exact))
                {
                    webRequest.AddParameter("name.exact", request.name_exact);
                }
                webRequest.AddParameter("page", request.page.ToString());
                webRequest.AddParameter("page.size", request.page_size.ToString());

                var resource = String.Format("/ws/seller/{0}/catalog/offers", GetSellerId());
                using (var webResponse = webRequest.GET(resource))
                {
                    apiResult.StatusCode = webResponse.StatusCode;

                    if (webResponse.StatusCode != HttpStatusCode.OK)
                    {
                        apiResult.Error = GetError(webResponse);
                    }

                    using (var stream = new StreamReader(webResponse.GetResponseStream()))
                    {
                        apiResult.Offers = JsonConvert.DeserializeObject<List<Offer>>(stream.ReadToEnd());
                    }
                }
            }
            catch (Exception exception)
            {
                apiResult = ThreatException(exception, apiResult);
            }

            return apiResult;
        }
    }
}