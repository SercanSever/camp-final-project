using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryProductDal : IProductDal
    {
        private List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ProductId= 1,CategoryId= 1,ProductName = "Bardak",UnitPrice = 15},
                new Product{ProductId= 2,CategoryId= 2,ProductName = "Kamera",UnitPrice = 1566},
                new Product{ProductId= 3,CategoryId= 2,ProductName = "Telefon",UnitPrice = 2000 },
                new Product{ProductId= 4,CategoryId= 3,ProductName = "Klavye",UnitPrice = 900},
                new Product{ProductId= 5,CategoryId= 3,ProductName = "Fare",UnitPrice = 250}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            var productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products.ToList();
        }

        public void Update(Product product)
        {
            var updatedProduct = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            updatedProduct.ProductId = product.ProductId;
            updatedProduct.ProductName = product.ProductName;
            updatedProduct.UnitPrice = product.UnitPrice;
            updatedProduct.CategoryId = product.CategoryId;
        }
        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
