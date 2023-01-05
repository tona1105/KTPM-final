using CakeShop.Models;
using StoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace CakeShop.Controllers
{
    public class ContactController : ApiController
    {
        // modify the type of the db field
        private ICakeShopContext db = new CakeShopContext();

        // add these constructors
        public ContactController() { }

        public ContactController(ICakeShopContext context)
        {
            db = context;
        }
        // rest of class not shown
        // POST api/Product
        [ResponseType(typeof(Contact))]
        public IHttpActionResult PostContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Contact.Add(contact);
            db.SaveChanges();
            return Ok();

        }

        // PUT api/Product/5
        
        public IEnumerable<Contact> GetAllContact()
        {
            return db.Contact;
        }

  

        public IHttpActionResult DeleteContact(int id)
        {
            var contact = db.Contact.FirstOrDefault((p) => p.Id == id);
            if (contact == null)
            {
                return NotFound();
            }
            db.Contact.Remove(contact);
            return Ok(contact);
        }

        public IHttpActionResult SearchProduct(string name)
        {
            var search = db.Products.Where(x => x.ProductName.ToLower().Contains(name.ToLower()));
            if (search.Count() > 0) return Ok();
            else return BadRequest();
        }
    }
}
