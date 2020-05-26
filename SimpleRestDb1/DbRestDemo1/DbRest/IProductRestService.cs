using DbRest.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DbRest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductRestService" in both code and config file together.
    [ServiceContract]
    public interface IProductRestService
    {
        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "/GetAllProducts",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)
        ]
        List<ProductDto> GetAllProducts();

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "/GetProductById/{Id}",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)
        ]
        ProductDto GetProductById(string Id);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/AddProduct",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)
        ]
        bool AddProduct(ProductDto productDto);
    }
}
