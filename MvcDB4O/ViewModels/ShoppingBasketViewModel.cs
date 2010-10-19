using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcDB4O.Models;

namespace MvcDB4O.ViewModels
{
    public class ShoppingBasketViewModel
    {
        public List<Basket> BasketItems { get; set; }
        public decimal BasketTotal { get; set; }
    }
}