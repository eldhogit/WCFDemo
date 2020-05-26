using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductProxyServiceReference.ProductServiceClient client = new ProductProxyServiceReference.ProductServiceClient();

            var productDto = new ProductProxyServiceReference.ProductDto()
            {
                Name = "Sanitizer2",
                Price = 100,
                CreatedBy = 1,
                CreatedDate = DateTime.Now,
                ModifiedBy = 1,
                ModifiedDate = DateTime.Now
            };

            try
            {
                //Insert
                var isInserted = client.AddProduct(productDto);

                //Get
                var result = client.GetAllProducts();
            }
            catch (Exception ex)
            {
                var m = ex.Message;
                throw;
            }
        }
    }
}