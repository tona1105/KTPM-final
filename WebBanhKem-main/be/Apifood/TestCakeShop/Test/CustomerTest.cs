using CakeShop.Controllers;
using CakeShop.Models;
using CakeShop.Tests.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http.Results;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CakeShop.CustomerTest
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void GetCustomer_ShouldReturnAllCustomer()
        {
            var context = new TestCakeShopContext();
            context.Customers.Add(new Customer { Id = 1, Name = "Demo1", Username = "Demo1", Password = "123456", Address = "Avx", Phone = "12341234" });
            context.Customers.Add(new Customer { Id = 2, Name = "Demo2", Username = "Demo2", Password = "123456", Address = "Abx", Phone = "12341235" });
            context.Customers.Add(new Customer { Id = 3, Name = "Demo3", Username = "Demo3", Password = "123456", Address = "Anx", Phone = "12341236" });

            var controller = new CustomerController(context);
            var result = controller.GetAllCustomer() as TestCustomerDbSet;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }

        [TestMethod]
        public void GetCustomer_ShouldReturnProductWithSameID()
        {
            var context = new TestCakeShopContext();
            context.Customers.Add(GetDemoCustomer());

            var controller = new CustomerController(context);
            var result = controller.GetCustomerByID(3) as OkNegotiatedContentResult<Customer>;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Content.Id);
        }

        [TestMethod]
        public void PostProduct_ShouldPass()
        {

            var controller = new CustomerController(new TestCakeShopContext());
            var item = GetDemoCustomer();

            var result = controller.PostCustomer(item);

            Assert.IsInstanceOfType(result, typeof(OkResult));

        }

        [TestMethod]
        public void PostCustomer_ShouldFail_WhenUsernameIsAlreadyExist()
        {
            var controller = new CustomerController(new TestCakeShopContext());
            var item = GetDemoCustomer();
            var item2 = GetDemoCustomer2();

            controller.PostCustomer(item);
            var result = controller.PostCustomer(item2);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void PostCustomer_ShouldFail_WhenEmailIsAlreadyExist()
        {

            var controller = new CustomerController(new TestCakeShopContext());
            var item = GetDemoCustomer();
            var item2 = GetDemoCustomer3();

            controller.PostCustomer(item);
            var result = controller.PostCustomer(item2);

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }


        [TestMethod]
        public void PutCustomer_ShouldPass()
        {
            var controller = new CustomerController(new TestCakeShopContext());
            var item = GetDemoCustomer();

            var result = controller.PutCustomer(item.Id, item);

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void PutCustomer_ShouldFail_WhenDifferentID()
        {
            var controller = new CustomerController(new TestCakeShopContext());

            var badresult = controller.PutCustomer(4, GetDemoCustomer());

            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }

        [TestMethod]
        public void DeleteCustomer_ShouldReturnOK()
        {
            var context = new TestCakeShopContext();
            var item = GetDemoCustomer();
            context.Customers.Add(item);

            var controller = new CustomerController(context);
            var result = controller.DeleteCustomer(3) as OkNegotiatedContentResult<Customer>;

            Assert.IsNotNull(result);
            Assert.AreEqual(item.Id, result.Content.Id);
        }

        [TestMethod]
        public void DeleteCustoemer_ShouldFail_WhenDifferentID()
        {
            var controller = new CustomerController(new TestCakeShopContext());

            var notfoundresult = controller.DeleteCustomer(999);

            Assert.IsInstanceOfType(notfoundresult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void Login_ShouldPass()
        {
            var controller = new CustomerController(new TestCakeShopContext());
            var item = GetLogin();

            controller.PostCustomer(GetDemoCustomer());
            var result = controller.Login(item);

            Assert.IsInstanceOfType(result, typeof(OkResult), "Sai tài khoản hoặc mật khẩu");
        }

        [TestMethod]
        public void Login_ShouldFail_WhenDifferenUsernamOrPassword()
        {
            var controller = new CustomerController(new TestCakeShopContext());
            var item = GetLogin();

            controller.PostCustomer(GetDemoCustomer2());
            var badresult = controller.Login(item);

            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }


        Customer GetDemoCustomer()
        {
            return new Customer() { Id = 3, Name = "Demo1", Username = "user123", Password = "123456", Email = "abc@abc.com", Address = "Apx", Phone = "12341233" };
        }
        Customer GetDemoCustomer2()
        {
            return new Customer() { Id = 4, Name = "Demo2", Username = "user123", Password = "1234567", Email = "123@abc.com", Address = "Apax", Phone = "123431233" };
        }
        Customer GetDemoCustomer3()
        {
            return new Customer() { Id = 3, Name = "Demo", Username = "Demo123", Password = "123456", Email = "abc@abc.com", Address = "Apx", Phone = "12341233" };
        }

        Login GetLogin()
        {
            return new Login() { UserName = "user123", Password = "123456" };
        }
    }
}
