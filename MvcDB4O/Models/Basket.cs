using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDB4O.Models
{
    public class Basket
    {
        public int RecordId { get; set; }
        public string BasketId { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }
    }
}