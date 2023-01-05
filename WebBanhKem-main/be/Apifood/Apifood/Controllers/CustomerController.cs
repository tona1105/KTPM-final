using CakeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CakeShop.Controllers
{
    public class CustomerController : ApiController
    {
        // modify the type of the db field
        private ICakeShopContext db = new CakeShopContext();

        // add these constructors
        public CustomerController() { }

        public CustomerController(ICakeShopContext context)
        {
            db = context;
        }

        public IHttpActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var searchUser = db.Customers.Where(x => x.Username == customer.Username).FirstOrDefault();
            var searchEmail = db.Customers.Where(x => x.Email == customer.Email).FirstOrDefault();

            if (searchEmail != null)
            {
                return BadRequest();
            }
            if (searchUser != null)
            {
                return NotFound();
            }

            db.Customers.Add(customer);
            db.SaveChanges();
            return Ok();

        }



        public IHttpActionResult PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.Id)
            {
                return BadRequest();
            }

            //db.Entry(product).State = EntityState.Modified;
            return Ok();

            // rest of method not shown
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
            return db.Customers;
        }

        public IHttpActionResult GetCustomerByID(int id)
        {
            var customer = db.Customers.FirstOrDefault((p) => p.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        public IHttpActionResult DeleteCustomer(int id)
        {
            var customer = db.Customers.FirstOrDefault((p) => p.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            db.Customers.Remove(customer);
            return Ok(customer);
        }

        public IHttpActionResult Login(Login login)
        {
            var user = db.Customers.Where(x => x.Username == login.UserName).FirstOrDefault();
            var pass = db.Customers.Where(x => x.Password == login.Password).FirstOrDefault();
            if ((user != null) && (pass != null)) return Ok();
            else return BadRequest();
        }


    }
}
