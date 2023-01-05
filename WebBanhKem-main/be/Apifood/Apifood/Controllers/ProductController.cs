using CakeShop.Models;
using StoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace CakeShop.Controllers
{
    public class ProductController : ApiController
    {
        // modify the type of the db field
        private ICakeShopContext db = new CakeShopContext();

        // add these constructors
        public ProductController() { }

        public ProductController(ICakeShopContext context)
        {
            db = context;
        }
        // rest of class not shown
        // POST api/Product
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var searchProductName = db.Products.Where(x => x.ProductName == product.ProductName).FirstOrDefault();
            if (searchProductName != null) return BadRequest();

            db.Products.Add(product);
            db.SaveChanges();
            return Ok();

        }

        // PUT api/Product/5
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            //db.Entry(product).State = EntityState.Modified;
            return Ok();

            // rest of method not shown
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return db.Products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = db.Products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok();
        }

        public IHttpActionResult DeleteProduct(int id)
        {
            var product = db.Products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            db.Products.Remove(product);
            return Ok(product);
        }

        public IHttpActionResult SearchProduct(string name)
        {
            var search = db.Products.Where(x => x.ProductName.ToLower().Contains(name.ToLower()));
            if (search.Count() > 0) return Ok();
            else return BadRequest();
        }
    }
}
