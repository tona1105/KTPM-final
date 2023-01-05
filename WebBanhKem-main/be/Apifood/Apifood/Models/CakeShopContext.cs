using CakeShop.Models;
using StoreApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CakeShop.Models
{
    public class CakeShopContext : DbContext, ICakeShopContext
    {
        public CakeShopContext() : base()
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Contact> Contact { get; set; }

        public void MarkAsModified(Product item)
        {
            Entry(item).State = EntityState.Modified;
        }
    }
}