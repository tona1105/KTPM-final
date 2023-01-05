using CakeShop.Controllers;
using CakeShop.Models;
using CakeShop.Tests.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace TestCakeShop.Test
{
    [TestClass]
    public class ContactTest
    {
        [TestMethod]
        public void GetContact_ShouldReturnAllCustomer()
        {
            var context = new TestCakeShopContext();
            context.Contact.Add(new Contact { Id = 1, Name = "Demo1", Email = "abc@gmail.com", Description = "Avx"});
            context.Contact.Add(new Contact { Id = 2, Name = "Demo2", Email = "abc1@gmail.com", Description = "abc"});

            var controller = new ContactController(context);
            var result = controller.GetAllContact() as TestContactDbSet;

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Local.Count);
        }

        [TestMethod]
        public void PostContact_ShouldPass()
        {

            var controller = new ContactController(new TestCakeShopContext());
            var item = GetDemoContact();

            var result = controller.PostContact(item);

            Assert.IsInstanceOfType(result, typeof(OkResult));

        }

        [TestMethod]
        public void DeleteContact_ShouldReturnOK()
        {
            var context = new TestCakeShopContext();
            var item = GetDemoContact();
            context.Contact.Add(item);

            var controller = new ContactController(context);
            var result = controller.DeleteContact(3) as OkNegotiatedContentResult<Contact>;

            Assert.IsNotNull(result);
            Assert.AreEqual(item.Id, result.Content.Id);
        }

        [TestMethod]
        public void DeleteContact_ShouldFail_WhenDifferentID()
        {
            var controller = new ContactController(new TestCakeShopContext());

            var notfoundresult = controller.DeleteContact(999);

            Assert.IsInstanceOfType(notfoundresult, typeof(NotFoundResult));
        }

        Contact GetDemoContact()
        {
            return new Contact() { Id = 3, Name = "Demo1", Email = "abc@abc.com", Description = "Aapx"};
        }
    }
    
}
