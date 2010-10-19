using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace MvcDB4O.Models
{
    //[Serializable]
    public class Product
    {
        public int ProductId { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Url { get; set; }
    }
}