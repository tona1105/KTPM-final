using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Apifood.Database;
using Apifood.Models;

namespace Apifood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly DemoDbContext _context;

        public CustomersController(DemoDbContext context)
        {
            _context = context;
        }
        //Get: api/Customer/admin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {

            return await _context.Customer.ToListAsync();

        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customer.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> PutCustomer(int id, [FromBody] UpdataCustomer customer)
        {
            if (await _context.Customer.AnyAsync(x => x.customerid != id))
            {
                return BadRequest();
            }
            var Customer = new Customer()
            {
                customerpassword = BCrypt.Net.BCrypt.HashPassword(customer.customerpassword),
            };

            _context.Entry(Customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> Addcustomer([FromBody] Addcustomer Model)
        {
            if (ModelState.IsValid)
            {
                var Customer = new Customer()
                {
                    customername = Model.customername,
                    customerusername = Model.customerusername,
                    customerpassword = Model.customerpassword,
                    customeremail = Model.customeremail,
                    customernumber = Model.customernumber,
                    customeraddress = Model.customeraddress,
                };
                var searchUsername = _context.Customer.Where(x => x.customerusername == Customer.customerusername).FirstOrDefault();
                var searchEmail = _context.Customer.Where(x => x.customeremail == Customer.customeremail).FirstOrDefault();
                if(searchUsername != null)
                {
                    return BadRequest("Tên đăng nhập đã tồn tại");
                }
                else if (searchEmail != null)
                {
                    return BadRequest("Email đã tồn tại");
                }    
                else
                {
                    _context.Customer.Add(Customer);
                    await _context.SaveChangesAsync();
                    return Ok(Customer);
                }
            }

            return BadRequest(ModelState.Values);

        }
        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.customerid == id);
        }
    }
}
