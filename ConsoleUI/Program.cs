using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProductTest();
            //CategoryTest();
            //ProductDetailsTest();
            var productManager = new ProductManager(new EfProductDal());
            var result = productManager.GetProductDetails();
            if (result.Success == true)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.ProductName + " / " + item.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            Console.ReadLine();
        }

        private static void ProductDetailsTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var item in productManager.GetProductDetails().Data)
            {
                Console.WriteLine(item.ProductName + " / " + item.CategoryName);
            }
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var item in productManager.GetAllByCategoryId(2).Data)
            {
                Console.WriteLine(item.ProductName);
            }
        }
    }
}
