using AmazonProductFilter.Interfaces;
using System;
using System.Reflection;

namespace AmazonProductFilter.Models
{
    public class FilterCriteria<T,V> : IFilterCriteria<T> where T : class
    {
        public string FilterPorperty { get; set; }
        public V[] FilterValues { get; set; }

        public FilterCriteria(string property, params V[] values)
        {
            this.FilterPorperty = property;
            this.FilterValues = values;
        }

        public bool AppliesTo(T item)
        {
            var filterProperty = typeof(T).GetProperty(FilterPorperty, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (filterProperty == null) return false;

            return Array.Exists(FilterValues, value => value.Equals(filterProperty.GetValue(item)));
        }

        public string FilterDescription()
        {
            return String.Format("Filter against property '{0}' with value '{1}'", this.FilterPorperty, string.Join(", ", this.FilterValues));
        }
    }
}
