using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDB4O.ViewModels
{
    public class ShoppingBasketRemoveViewModel
    {
        public string Message { get; set; }
        public decimal BasketTotal { get; set; }
        public int BasketCount { get; set; }
        public int Id { get; set; }
        public int NumberOfProducts { get; set; }
    }
}