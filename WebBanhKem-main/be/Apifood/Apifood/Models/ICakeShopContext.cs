using StoreApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Models
{
    public interface ICakeShopContext : IDisposable
    {
        DbSet<Product> Products { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Contact> Contact { get; set; }
        int SaveChanges();
        void MarkAsModified(Product item);
    }
}
