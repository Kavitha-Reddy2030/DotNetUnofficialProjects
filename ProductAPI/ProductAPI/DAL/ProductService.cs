using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductAPI.Models;

namespace ProductAPI.DAL
{
    public class ProductService
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }

        public void AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }

        public int DeleteProduct(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
                return 1;
            }
            else return 0;
        }

        public int UpdateProduct(Product product)
        {

            var existingProduct = _dbContext.Products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                _dbContext.Products.Update(existingProduct);
                _dbContext.SaveChanges();
                return 1;
            }
            else return 0;

        }

        public Product GetProductById(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                return product;
            }
            else return null;
        }

        public List<ProductDto> GetAllPRoductsWithOutId()
        {
            return _dbContext.Products.Select(p => new ProductDto { Name = p.Name, Description = p.Description }).ToList();
        }
    }
}
