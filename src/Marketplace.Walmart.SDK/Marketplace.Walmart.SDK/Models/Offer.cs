using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Marketplace.Walmart.SDK.Models
{
    [DataContract]
    public class Offer
    {
        [DataMember]
        public long id { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string skuName { get; set; }

        [DataMember]
        public string description { get; set; }

        [DataMember]
        public bool active { get; set; }

        [DataMember]
        public double price { get; set; }

        [DataMember]
        public double priceDiscount { get; set; }

        [DataMember]
        public long quantity { get; set; }

        [DataMember]
        public string ean { get; set; }

        [DataMember]
        public string url { get; set; }

        [DataMember]
        public string sellerSKU { get; set; }

        [DataMember]
        public int sellerId { get; set; }

        [DataMember]
        public Category category { get; set; }

        [DataMember]
        public string brand { get; set; }

        [DataMember]
        public double height { get; set; }

        [DataMember]
        public double width { get; set; }

        [DataMember]
        public double length { get; set; }

        [DataMember]
        public double weight { get; set; }

        [DataMember]
        public string urlImage { get; set; }

        [DataMember]
        public List<OfferImage> images
        {
            get { return _images ?? (_images = new List<OfferImage>()); }
            set { _images = value; }
        }
        List<OfferImage> _images;

        [DataMember]
        public List<Specification> specifications
        {
            get { return _specifications ?? (_specifications = new List<Specification>()); }
            set { _specifications = value; }
        }
        List<Specification> _specifications;
    }
}
