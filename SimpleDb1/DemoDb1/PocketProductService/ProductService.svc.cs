using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PocketProductService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductService.svc or ProductService.svc.cs at the Solution Explorer and start debugging.
    public class ProductService : IProductService
    {
        PocketDbContext db;
        public ProductService()
        {
            db = new PocketDbContext();
        }
        public List<ProductDto> GetAllProducts()
        {
            var result = (from prdt in db.Products
                          select prdt).ToList();

            var productsDto = new List<ProductDto>();
            //Mapping
            foreach (var item in result)
            {
                productsDto.Add(new ProductDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    ModifiedBy = item.ModifiedBy,
                    ModifiedDate = item.ModifiedDate
                }
                );
            }

            return productsDto;
        }

        public bool AddProduct(ProductDto productDto)
        {
            //Mapping
            var product = new Product()
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Price = productDto.Price,
                CreatedBy = productDto.CreatedBy,
                CreatedDate = productDto.CreatedDate,
                ModifiedBy = productDto.ModifiedBy,
                ModifiedDate = productDto.ModifiedDate
            };

            try
            {
                db.Products.Add(product);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                var errMsg = ex.Message;
                return false;

                throw;
            }
        }
    }
}
