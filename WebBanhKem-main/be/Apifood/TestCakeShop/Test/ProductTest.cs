using CakeShop.Controllers;
using CakeShop.Tests.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreApp.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Web.Http.Results;

namespace CakeShop.ProductTest
{
    [TestClass]
    public class TestProductController
    {
        [TestMethod]
        public void PostProduct_ShouldPass()
        {
            var controller = new ProductController(new TestCakeShopContext());
            var item = GetDemoProduct();

            var result = controller.PostProduct(item);

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void PostProduct_ShouldFail_WhenProductNameIsAlreadyExist()
        {
            var controller = new ProductController(new TestCakeShopContext());
            var item = GetDemoProduct();
            var item2 = GetDemoProduct2();

            controller.PostProduct(item);
            var result = controller.PostProduct(item2);

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void PutProduct_ShouldReturnStatusCode()
        {
            var controller = new ProductController(new TestCakeShopContext());

            var item = GetDemoProduct();

            var result = controller.PutProduct(item.Id, item);

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void PutProduct_ShouldFail_WhenDifferentID()
        {
            var controller = new ProductController(new TestCakeShopContext());

            var badresult = controller.PutProduct(4, GetDemoProduct()); //OK

            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }

        [TestMethod]
        public void GetProduct_ShouldReturnProductWithSameID()
        {
            var context = new TestCakeShopContext();
            context.Products.Add(GetDemoProduct());

            var controller = new ProductController(context);
            var result = controller.GetProduct(3);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }


        [TestMethod]
        public void GetProducts_ShouldReturnAllProducts()
        {
            var context = new TestCakeShopContext();
            context.Products.Add(new Product { Id = 1, ProductName = "Demo1", Price = 20 });
            context.Products.Add(new Product { Id = 2, ProductName = "Demo2", Price = 30 });
            context.Products.Add(new Product { Id = 3, ProductName = "Demo3", Price = 40 });

            var controller = new ProductController(context);
            var result = controller.GetAllProducts() as TestProductDbSet;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }

        [TestMethod]
        public void DeleteProduct_ShouldReturnOK()
        {
            var context = new TestCakeShopContext();
            var item = GetDemoProduct();
            context.Products.Add(item);

            var controller = new ProductController(context);
            var result = controller.DeleteProduct(3) as OkNegotiatedContentResult<Product>;
            Assert.IsNotNull(result);
            Assert.AreEqual(item.Id, result.Content.Id);
        }

        [TestMethod]
        public void DeleteProduct_ShouldFail_WhenDifferentID()
        {
            var controller = new ProductController(new TestCakeShopContext());

            var notfoundresult = controller.DeleteProduct(999);
            Assert.IsInstanceOfType(notfoundresult, typeof(NotFoundResult));
        }


        [TestMethod]
        public void SearchProductName_ShouldPass()
        {
            var controller = new ProductController(new TestCakeShopContext());

            controller.PostProduct(GetDemoProduct());
            var result = controller.SearchProduct(("demo"));

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void SearchProductName_ShouldFail_WhenProductNameIsNotExist()
        {
            var controller = new ProductController(new TestCakeShopContext());

            controller.PostProduct(GetDemoProduct());
            var result = controller.SearchProduct(("abc123"));

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }



        Product GetDemoProduct()
        {
            return new Product() { Id = 3, ProductName = "Demo name", Price = 5, foodimghp = "abcjkl", foodDescriptions = "this is description", foodInStock = 3 };
        }
        Product GetDemoProduct2()
        {
            return new Product() { Id = 4, ProductName = "Demo name", Price = 6, foodimghp = "abcjklabc", foodDescriptions = "this is description 2", foodInStock = 4 };
        }

    }
}
