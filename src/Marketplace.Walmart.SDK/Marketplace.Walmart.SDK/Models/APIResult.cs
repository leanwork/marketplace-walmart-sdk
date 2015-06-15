using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Walmart.SDK.Models
{
    public class APIResult
    {
        public HttpStatusCode StatusCode { get; set; }

        public Error Error { get; set; }

        public bool HasServerError()
        {
            return (StatusCode == HttpStatusCode.InternalServerError ||
                    StatusCode == HttpStatusCode.ServiceUnavailable ||
                    StatusCode == HttpStatusCode.BadRequest ||
                    StatusCode == HttpStatusCode.Unauthorized ||
                    StatusCode == HttpStatusCode.Forbidden ||
                    StatusCode == HttpStatusCode.GatewayTimeout);
        }
    }
}
