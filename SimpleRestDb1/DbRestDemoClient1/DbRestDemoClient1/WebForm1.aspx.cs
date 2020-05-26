using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DbRestDemoClient1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AddProduct();
        }

        private void GetAll()
        {
            try
            {
                //create request object 
                WebRequest request = WebRequest.Create(@"http://localhost:57655/ProductRestService.svc/GetProductById/14");
                request.Method = "GET";
                request.ContentType = @"application/json; charset=utf-8";

                //get response
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string jsonResponse = string.Empty;

                //read result from stream reader
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    jsonResponse = sr.ReadToEnd();

                }
            }
            catch (Exception e)
            {
                var m = e.Message;
                throw;
            }
        }

        private void AddProduct()
        {
            

            try
            {
                ProductDto productDto = new ProductDto()
                {
                    Name = "Product333",
                    Price = 20
                };



                //DataContractJsonSerializer serialize = new DataContractJsonSerializer(typeof(ProductDto));
                //MemoryStream mem = new MemoryStream();
                //serialize.WriteObject(mem, productDto);
                //string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                //WebClient webClient = new WebClient();
                //webClient.Headers["Content-type"] = "application/json";
                //webClient.Encoding = Encoding.UTF8;
                //webClient.UploadString("http://localhost:57655/ProductRestService.svc/AddProduct", "POST", data);
                //string myResponseBody = JsonConvert.Serialize(message);


                string request = JsonConvert.SerializeObject(productDto);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                webClient.UploadString("http://localhost:57655/ProductRestService.svc/AddProduct", "POST", request);
            }
            catch (Exception e)
            {
                var m = e.Message;
                throw;
            }
           
        }

        [DataContract(Name= "productDto")]
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
}