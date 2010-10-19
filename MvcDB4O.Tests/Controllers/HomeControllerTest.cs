using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcDB4O;
using MvcDB4O.Controllers;
using MvcDB4O.Models;
using MvcDB4O.ViewModels;

namespace MvcDB4O.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
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


    }
}
