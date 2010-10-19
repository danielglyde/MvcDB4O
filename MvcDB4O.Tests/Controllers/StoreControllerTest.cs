using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcDB4O.Controllers;
using System.Web.Mvc;
using MvcDB4O.Models;
using MvcDB4O.ViewModels;

namespace MvcDB4O.Tests.Controllers
{
    [TestClass]
    public class StoreControllerTest
    {
        /// <summary>
        ///Initialize() is called once during test execution before
        ///test methods in this test class are executed.
        ///</summary>
        [TestInitialize()]
        public void Initialize()
        {
            StoreDB4O.LoadTestData();
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            StoreController controller = new StoreController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            ViewDataDictionary viewData = result.ViewData;
            StoreIndexViewModel storeIndexViewModel = viewData.Model as StoreIndexViewModel;

            IEnumerable<Category> categories = storeIndexViewModel.Categories;

            Assert.AreEqual("Accessories", categories.ElementAt<Category>(0).Name);
            Assert.AreEqual("Bikes", categories.ElementAt<Category>(1).Name);
            Assert.AreEqual("Clothing", categories.ElementAt<Category>(2).Name);
            Assert.AreEqual("Components", categories.ElementAt<Category>(3).Name);
            Assert.AreEqual("Nutrition", categories.ElementAt<Category>(4).Name);
            Assert.AreEqual("Shoes", categories.ElementAt<Category>(5).Name);
            
        }

        [TestMethod]
        public void Browse()
        {
            // Arrange
            StoreController controller = new StoreController();

            // Act
            ViewResult result = controller.Browse("Accessories") as ViewResult;

            // Assert
            ViewDataDictionary viewData = result.ViewData;
            StoreBrowseViewModel storeBrowseViewModel = viewData.Model as StoreBrowseViewModel;

            Category category = storeBrowseViewModel.Category;

            Assert.AreEqual("Accessories", category.Name);

            IEnumerable<Product> products = storeBrowseViewModel.Products;

            Assert.AreEqual("Fibre Flare Shorty Rear Light", products.ElementAt<Product>(0).Name);
            Assert.AreEqual("Fox Flux Helmet", products.ElementAt<Product>(1).Name);
            Assert.AreEqual("Garmin Edge 500 with Heart Rate, Cadence and Team Jersey", products.ElementAt<Product>(2).Name);
            Assert.AreEqual("Giro Prolight Road Helmet", products.ElementAt<Product>(3).Name);
        }

        [TestMethod]
        public void Details()
        {
            // Arrange
            StoreController controller = new StoreController();

            // Act
            ViewResult result = controller.Details(3) as ViewResult;

            // Assert
            ViewDataDictionary viewData = result.ViewData;
            StoreDetailsViewModel storeDetailsViewModel = viewData.Model as StoreDetailsViewModel;

            Product product = storeDetailsViewModel.Product;

            Assert.AreEqual("Felt Brougham 2010", product.Name);
            Assert.AreEqual(299.99M, product.Price);
            Assert.AreEqual("http://s.wiggle.co.uk/images/felt-brougham-2010-ind.jpg", product.Url);
        }
    }
}
