using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDB4O.Models;
using MvcDB4O.ViewModels;

namespace MvcDB4O.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var homeIndexViewModel = new HomeIndexViewModel
            {
                Categories = StoreDB4O.GetCategories()
            };

            return View(homeIndexViewModel);
        }
    }
}
