using DbRest.DAL;
using DbRest.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DbRest
{
    public class ProductRestService : IProductRestService
    {
        PocketDbContext db;

        public ProductRestService()
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

        public ProductDto GetProductById(string Id)
        {
            try
            {
                long ProductId = Int64.Parse(Id);
                var result = (from prdt in db.Products
                              where prdt.Id == ProductId
                              select prdt).SingleOrDefault();

                //Mapping
                var productsDto = new ProductDto()
                {
                    Id = result.Id,
                    Name = result.Name,
                    Price = result.Price,
                    CreatedBy = result.CreatedBy,
                    CreatedDate = result.CreatedDate,
                    ModifiedBy = result.ModifiedBy,
                    ModifiedDate = result.ModifiedDate
                };

                return productsDto;

            }
            catch (Exception ex)
            {
                var m = ex.Message;
                throw;
            }

                     

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
