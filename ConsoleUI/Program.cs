using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProductTest();

            //CategoryTest();

            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetProductDetailDtos())
            {
                Console.WriteLine("{0} --> {1}", product.ProductName, product.CategoryName);
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

            foreach (var product in productManager.GetByUnitPrice(10, 300))
            {
                Console.WriteLine("{0} --> {1}", product.ProductName, product.UnitPrice);
            }
        }
    }
}
