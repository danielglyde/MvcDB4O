using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDB4O.Models
{
    public class ShoppingBasket
    {
        string shoppingBasketId { get; set; }
        public const string BasketSessionKey = "BasketId";

        public static ShoppingBasket GetBasket(HttpContextBase context)
        {
            var basket = new ShoppingBasket();
            basket.shoppingBasketId = basket.GetBasketId(context);
            return basket;
        }

        public void AddToBasket(Product product)
        {
            Basket basket = StoreDB4O.GetBasketByProduct(shoppingBasketId, product.ProductId);

            if (basket == null)
            {
                // Create a new basket item
                basket = new Basket
                {
                    Product = product,
                    BasketId = shoppingBasketId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                StoreDB4O.StoreObject(basket);
            }
            else
            {
                StoreDB4O.UpdateProductCountForBasketByProduct(shoppingBasketId, product.ProductId, ++basket.Count);
            }

            
        }

        /// <summary>
        /// Return the number of products left - if 0 then the caller knows there were none left
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public int RemoveFromBasket(int productId)
        {
            int numberOfProducts = 0;
            Basket basket = StoreDB4O.GetBasketByProduct(shoppingBasketId, productId);
            if (basket != null)
            {
                numberOfProducts = --basket.Count;
                StoreDB4O.UpdateProductCountForBasketByProduct(shoppingBasketId, productId, numberOfProducts);
               
            }
            return numberOfProducts;
        }

        public void EmptyBasket()
        {
            var basketItems = StoreDB4O.GetBaskets(shoppingBasketId);

            foreach (var basketItem in basketItems)
            {
                StoreDB4O.DeleteObject(basketItem);
            }
        }

        public List<Basket> GetBasketItems()
        {
            return StoreDB4O.GetBaskets(shoppingBasketId).ToList<Basket>();
        }

        public int GetCount()
        {
            return StoreDB4O.GetBasketCount(shoppingBasketId);
        }

        public decimal GetTotal()
        {
            return StoreDB4O.GetBasketTotal(shoppingBasketId);
        }

        // We're using HttpContextBase to allow access to cookies.
        public string GetBasketId(HttpContextBase context)
        {
            if (context.Session[BasketSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    // User is logged in, associate the basket with there username
                    context.Session[BasketSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid Class
                    Guid tempBasketId = Guid.NewGuid();

                    // Send tempBasketId back to client as a cookie
                    context.Session[BasketSessionKey] = tempBasketId.ToString();
                }
            }
            return context.Session[BasketSessionKey].ToString();
        }

        // When a user has logged in, migrate their shopping basket to
        // be associated with their username
        public void MigrateBasket(string userName)
        {
            var basketItems = StoreDB4O.GetBaskets(shoppingBasketId);

            foreach (var basketItem in basketItems)
            {
                basketItem.BasketId = userName;
                StoreDB4O.StoreObject(basketItem);
            }
        }

    }
}