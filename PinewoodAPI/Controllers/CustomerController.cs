using Microsoft.AspNetCore.Mvc;
using PinewoodAPI.Interfaces;
using PinewoodAPI.Models;
using PinewoodAPI.Repository;

namespace WebPinewoodAPIApplication2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private ICustomersRepository _customersRepository;

        public CustomerController(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]
        public IActionResult GetCustomers()
        {
            var customers = _customersRepository.GetCustomers();

            if (!ModelState.IsValid)
                return BadRequest(customers);

            return Ok(customers);
        }


        [HttpGet("{customerId}")]
        [ProducesResponseType(200, Type = typeof(Activity))]
        [ProducesResponseType(400)]
        public IActionResult GetCustomer(int customerId)
        {
            if (!_customersRepository.CustomerExists(customerId))
                return NotFound();

            var customer = _customersRepository.GetCustomer(customerId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(customer);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCustomer([FromBody] Customer customerCreate)
        {
            if (CreateCustomer == null)
                return BadRequest(ModelState);

            var customer = _customersRepository.GetCustomers()
                .Where(c => c.FirstName.Trim().ToUpper() == customerCreate.FirstName.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (customer != null)
            {
                ModelState.AddModelError("", "Customer already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!_customersRepository.CreateCustomer(customerCreate))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }


        [HttpPut("{customerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCustomer(int customerId, [FromBody] Customer updatedCustomer)
        {
            if (updatedCustomer == null)
                return BadRequest(ModelState);

            if (customerId != updatedCustomer.CustomerId)
                return BadRequest(ModelState);

            if (!_customersRepository.CustomerExists(customerId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();


            if (!_customersRepository.UpdateCustomer(updatedCustomer))
            {
                ModelState.AddModelError("", "Something went wrong updating");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }

    }
}
