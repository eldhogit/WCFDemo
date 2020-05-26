using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PocketProductService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductService" in both code and config file together.
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        List<ProductDto> GetAllProducts();

        [OperationContract]
        bool AddProduct(ProductDto productDto);
    }

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
