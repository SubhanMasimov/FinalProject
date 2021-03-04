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

            ProductDetailDtoTest();

        }

        private static void ProductDetailDtoTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));

            var result = productManager.GetProductDetailDtos();

            if (result.Success)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine("{0} -- {1} -- {2} -- {3}", product.ProductId, product.ProductName, product.CategoryName, product.UnitsInStock);
                }
            }

            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            foreach (var category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));

            foreach (var product in productManager.GetByUnitPrice(10, 300).Data)
            {
                Console.WriteLine("{0} --> {1}", product.ProductName, product.UnitPrice);
            }
        }
    }
}
