using System;
using System.Runtime.Serialization;

namespace Marketplace.Walmart.SDK.Models
{
    [DataContract]
    public class Specification
    {
        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string value { get; set; }

        public Specification(string name, string value)
        {
            this.name = name;
            this.value = value;
        }
    }
}
