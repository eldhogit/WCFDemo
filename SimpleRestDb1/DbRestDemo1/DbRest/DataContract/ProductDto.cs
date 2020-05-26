using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DbRest.DataContract
{
    [DataContract]
    public class ProductDto
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Nullable<int> Price { get; set; }
        [DataMember]
        public Nullable<System.DateTime> CreatedDate { get; set; }
        [DataMember]
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        [DataMember]
        public Nullable<long> CreatedBy { get; set; }
        [DataMember]
        public Nullable<long> ModifiedBy { get; set; }
    }
}