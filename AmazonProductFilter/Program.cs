using AmazonProductFilter.Interfaces;
using AmazonProductFilter.Models;
using System;
using System.Collections.Generic;

namespace AmazonProductFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Filter App Started");

                //Products Setup

                IEnumerable<Product> products = CreateTestProducts();

                //Filter Objects Setup

                var filterYellow = new FilterCriteria<Product, Color>("color", Color.Yellow);

                var filterBlue = new FilterCriteria<Product, Color>("color", Color.Blue);

                var filterSmallAndLarge = new FilterCriteria<Product, Size>("size", Size.Small, Size.Large);

                //Filterer Object Setup

                ProductFilter<Product> productFilter = new ProductFilter<Product>();

                //Case 1 : All Products that are Yellow

                IEnumerable<Product> firstFilter = productFilter.BasicFilter(products, filterYellow);

                PrintFilteredProducts(firstFilter, filterYellow);

                Console.WriteLine();

                //Case 2 : All Products that are Small OR Large

                IEnumerable<Product> secondFilter = productFilter.BasicFilter(products, filterSmallAndLarge);

                PrintFilteredProducts(secondFilter, filterSmallAndLarge);

                Console.WriteLine();

                //Case 3: All Products that are Small OR Large AND Blue

                IEnumerable<Product> thirdFilter = productFilter.BasicFilter(products, filterSmallAndLarge, filterBlue);

                PrintFilteredProducts(thirdFilter, filterSmallAndLarge, filterBlue);

                Console.WriteLine();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        static IEnumerable<Product> CreateTestProducts()
        {
            return new List<Product>()
            {
                new Product(1, Size.Medium, Color.Red),
                new Product(2, Size.Large, Color.Blue),
                new Product(3, Size.Large, Color.Green),
                new Product(4, Size.Small, Color.Red),
                new Product(5, Size.Small, Color.Blue),
                new Product(6, Size.Medium, Color.Yellow),
                new Product(7, Size.Large, Color.Yellow),
                new Product(8, Size.Small, Color.Yellow),
            };
        }

        static void PrintFilteredProducts(IEnumerable<Product> products, params IFilterCriteria<Product>[] filterCriterias)
        {
            Console.WriteLine("Filter Result bellow for:");

            foreach(var filter in filterCriterias)
            {
                Console.WriteLine(filter.FilterDescription());
            }

            foreach (var product in products)
            {
                Console.WriteLine(product.ProductDescription());
            }
        }
    }
}
