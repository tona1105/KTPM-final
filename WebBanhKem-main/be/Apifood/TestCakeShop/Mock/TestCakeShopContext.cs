using CakeShop.Models;
using StoreApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Tests.Mock
{
    public class TestCakeShopContext : ICakeShopContext
    {
        public TestCakeShopContext()
        {
            this.Products = new TestProductDbSet();
            this.Customers = new TestCustomerDbSet();
            this.Contact = new TestContactDbSet();
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Contact> Contact { get; set; }
        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Product item) { }
        public void Dispose() { }
    }
}
