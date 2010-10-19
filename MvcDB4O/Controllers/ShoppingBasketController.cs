using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDB4O.Models;
using MvcDB4O.ViewModels;

namespace MvcDB4O.Controllers
{
    public class ShoppingBasketController : Controller
    {
        //
        // GET: /ShoppingBasket/

        public ActionResult Index()
        {
            var basket = ShoppingBasket.GetBasket(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new ShoppingBasketViewModel
            {
                BasketItems = basket.GetBasketItems(),
                BasketTotal = basket.GetTotal()
            };

            // Return the view
            return View(viewModel);
        }

                //
        // GET: /Store/AddToBasket/5

        public ActionResult AddToBasket(int id)
        {

            // Retrieve the Product from the database
            Product addedProduct =  StoreDB4O.GetProduct(id);

            // Add it to the shopping Basket
            var shoppingBasket = ShoppingBasket.GetBasket(this.HttpContext);

            shoppingBasket.AddToBasket(addedProduct);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }

        //
        // AJAX: /ShoppingBasket/RemoveFromBasket/5

        [HttpPost]
        public ActionResult RemoveFromBasket(int id)
        {
            // Remove the item from the Basket
            ShoppingBasket shoppingBasket = ShoppingBasket.GetBasket(this.HttpContext);

            // Get the name of the Product to display confirmation
            string productName = StoreDB4O.GetProduct(id).Name;

            // Remove from Basket. Note that for simplicity, we're 
            // removing all rather than decrementing the count.
            int numberOfProducts = shoppingBasket.RemoveFromBasket(id);

            // Display the confirmation message
            var results = new ShoppingBasketRemoveViewModel { 
                Message = Server.HtmlEncode(productName) + 
                    " has been removed from your shopping basket.",
                BasketTotal = shoppingBasket.GetTotal(),
                BasketCount = shoppingBasket.GetCount(),
                Id = id,
                NumberOfProducts = numberOfProducts
            };

            return Json(results);
        }

        //
        // GET: /ShoppingBasket/BasketSummary

        [ChildActionOnly]
        public ActionResult BasketSummary()
        {
            var Basket = ShoppingBasket.GetBasket(this.HttpContext);

            ViewData["BasketCount"] = Basket.GetCount();

            return PartialView("BasketSummary");
        }
    }

}
