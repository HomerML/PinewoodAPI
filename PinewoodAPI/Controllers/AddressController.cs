using Microsoft.AspNetCore.Mvc;
using PinewoodAPI.Interfaces;
using PinewoodAPI.Models;
using PinewoodAPI.Repository;

namespace PinewoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : Controller
    {
        private IAddressesRepository _addressesRepository;

        public AddressController(IAddressesRepository addressesRepository)
        {
            _addressesRepository = addressesRepository;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Address>))]
        public IActionResult GetAddresses()
        {
            var addresses = _addressesRepository.GetAddresses();

            if (!ModelState.IsValid)
                return BadRequest(addresses);

            return Ok(addresses);
        }


        [HttpGet("{addressId}")]
        [ProducesResponseType(200, Type = typeof(Address))]
        [ProducesResponseType(400)]
        public IActionResult GetAddress(int addressId)
        {
            if (!_addressesRepository.AddressExists(addressId))
                return NotFound();

            var address = _addressesRepository.GetAddress(addressId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(address);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateAddress([FromBody] Address addressCreate)
        {
            if (CreateAddress == null)
                return BadRequest(ModelState);

            var address = _addressesRepository.GetAddresses()
                .Where(c => c.AddressLine1.Trim().ToUpper() == addressCreate.AddressLine1.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (address != null)
            {
                ModelState.AddModelError("", "Address already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!_addressesRepository.CreateAddress(addressCreate))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }


        [HttpPut("{addressId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateAddress(int addressId, [FromBody] Address updatedAddress)
        {
            if (updatedAddress == null)
                return BadRequest(ModelState);

            if (addressId != updatedAddress.AddressId)
                return BadRequest(ModelState);

            if (!_addressesRepository.AddressExists(addressId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();


            if (!_addressesRepository.UpdateAddress(updatedAddress))
            {
                ModelState.AddModelError("", "Something went wrong updating");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }

    }
}
