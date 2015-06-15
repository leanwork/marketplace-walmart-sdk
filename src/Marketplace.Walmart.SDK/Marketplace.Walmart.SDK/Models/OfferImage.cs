using System;
using System.Runtime.Serialization;

namespace Marketplace.Walmart.SDK.Models
{
    [DataContract]
    public class OfferImage
    {
        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string url { get; set; }

        public OfferImage(string name, string value)
        {
            this.name = name;
            this.url = value;
        }
    }
}
