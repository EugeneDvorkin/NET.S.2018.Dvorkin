using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Bll.Interface.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC;
using MVC.Controllers;
using DependencyResolver;
using Ninject;

namespace MVC.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private IKernel kernel;
        
        [TestMethod]
        public void Index()
        {
            kernel = new StandardKernel();
            kernel.ConfigurateResolver();
            IBankService service = kernel.Get<IBankService>();

            // Arrange
            HomeController controller = new HomeController(service);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            kernel = new StandardKernel();
            kernel.ConfigurateResolver();
            IBankService service = kernel.Get<IBankService>();

            // Arrange
            HomeController controller = new HomeController(service);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            kernel = new StandardKernel();
            kernel.ConfigurateResolver();
            IBankService service = kernel.Get<IBankService>();

            // Arrange
            HomeController controller = new HomeController(service);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
