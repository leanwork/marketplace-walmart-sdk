using System;
using System.Runtime.Serialization;

namespace Marketplace.Walmart.SDK.Models
{
    [DataContract]
    public class Category
    {
        [DataMember]
        public long id { get; set; }
        
        [DataMember]
        public long id_category { get; set; }
        
        [DataMember]
        public string name { get; set; }

        [DataMember]
        public bool active { get; set; }

        [DataMember]
        public Category parent { get; set; }
    }
}
