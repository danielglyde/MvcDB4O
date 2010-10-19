using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDB4O.Models
{
    public class ProductByNameEquality : IEqualityComparer<Product> 
    {
        public bool Equals(Product x, Product y)
        {
            return x.Name.Equals(y.Name);
        }

        public int GetHashCode(Product obj)
        {
            return obj.Name.GetHashCode();
        } 
    }
}