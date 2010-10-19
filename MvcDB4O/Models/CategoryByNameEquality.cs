using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDB4O.Models
{
    public class CategoryByNameEquality : IEqualityComparer<Category> 
    {
        public bool Equals(Category x, Category y)
        {
            return x.Name.Equals(y.Name);
        }

        public int GetHashCode(Category obj)
        {
            return obj.Name.GetHashCode();
        } 

    }
}