using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDB4O.Models;
using MvcDB4O.ViewModels;

namespace MvcDB4O.Controllers
{
    //http://www.asp.net/mvc/tutorials/mvc-music-store-part-3
    public class StoreController : Controller
    {
        //
        // GET: /Store/
        public ActionResult Index()
        {
            var storeIndexViewModel = new StoreIndexViewModel
            {
                Categories = StoreDB4O.GetCategories()
            };

            return View(storeIndexViewModel);
        }

        // 
        // GET: /Store/Browse?Category=Bikes 
        public ActionResult Browse(string category)
        {
            // Retrieve Category and Products from database     
            var storeBrowseViewModel = new StoreBrowseViewModel()
                { 
                    Category = StoreDB4O.GetCategory(category),
                    Products = StoreDB4O.GetProductsByCategoryName(category)
                };
            return View(storeBrowseViewModel);
        }

        // // GET: /Store/Details/5 
        public ActionResult Details(int id) 
        {
            // Retrieve Product from database     
            var storeDetailsViewModel = new StoreDetailsViewModel()
            {
                Product = StoreDB4O.GetProduct(id)
            };
            return View(storeDetailsViewModel);
        }
    }
}
