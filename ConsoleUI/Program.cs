﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main()
        {
             ProductTest();
            //CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new(new EfProductDal());
            var result = productManager.GetProductDetails();

            if(result.Success)
            {
                foreach (var product in result.Data!)
                {
                    Console.WriteLine(product.ProductName + " - " + 
                                      product.CategoryName);
                }
            } else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}

