using AmazonProductFilter.Interfaces;
using System.Collections.Generic;

namespace AmazonProductFilter.Models
{
    public class ProductFilter<T> : IProductFilter<T> where T : class
    {
        public IEnumerable<T> BasicFilter(IEnumerable<T> products, params IFilterCriteria<T>[] filterCriterias)
        {
            foreach (var product in products)
            {
                if(FilterProduct(product, filterCriterias)) yield return product;
            }
        }

        public bool FilterProduct(T item, IFilterCriteria<T>[] filterCriterias)
        {
            foreach(var filter in filterCriterias)
            {
                if (!filter.AppliesTo(item)) return false;
            }
            return true;
        }
    }
}
