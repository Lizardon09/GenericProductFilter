using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonProductFilter.Interfaces
{
    public interface IFilterCriteria<T> where T : class
    {
        bool AppliesTo(T item);
        string FilterDescription();
    }
}
