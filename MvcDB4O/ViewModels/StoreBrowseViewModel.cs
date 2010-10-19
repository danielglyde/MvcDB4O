using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcDB4O.Models;

namespace MvcDB4O.ViewModels
{
    public class StoreBrowseViewModel
    {
        public Category Category { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}