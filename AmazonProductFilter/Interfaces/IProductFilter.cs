using System.Collections.Generic;

namespace AmazonProductFilter.Interfaces
{
    public interface IProductFilter<T> where T : class
    {
        IEnumerable<T> BasicFilter(IEnumerable<T> products, params IFilterCriteria<T>[] filterCriterias);
        bool FilterProduct(T item, IFilterCriteria<T>[] filterCriterias);
    }
}
