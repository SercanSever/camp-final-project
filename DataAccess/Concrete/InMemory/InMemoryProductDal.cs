using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
                new Product{ProductID = 1,CategoryID = 1,ProductName = "Bardak",UnitPrice = 15,UnitsInStock=125},
                new Product{ProductID = 2,CategoryID = 2,ProductName = "Kamera",UnitPrice = 1566,UnitsInStock=1445},
                new Product{ProductID = 3,CategoryID = 2,ProductName = "Telefon",UnitPrice = 2000,UnitsInStock=315},
                new Product{ProductID = 4,CategoryID = 3,ProductName = "Klavye",UnitPrice = 900,UnitsInStock=215},
                new Product{ProductID = 5,CategoryID = 3,ProductName = "Fare",UnitPrice = 250,UnitsInStock=10},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            var productToDelete = _products.SingleOrDefault(p => p.ProductID == product.ProductID);
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products.ToList();
        }

        public void Update(Product product)
        {
            var updatedProduct = _products.SingleOrDefault(p => p.ProductID == product.ProductID);
            updatedProduct.ProductID = product.ProductID;
            updatedProduct.ProductName = product.ProductName;
            updatedProduct.UnitPrice = product.UnitPrice;
            updatedProduct.UnitsInStock = product.UnitsInStock;
            updatedProduct.CategoryID = product.CategoryID;
        }
        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryID == categoryId).ToList();
        }
    }
}
