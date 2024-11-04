using Microsoft.AspNetCore.Mvc;
using PinewoodAPI.Interfaces;
using PinewoodAPI.Models;
using PinewoodAPI.Repository;

namespace PinewoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressTypeController : Controller
    {
        private IAddressTypesRepository _addressTypesRepository;

        public AddressTypeController(IAddressTypesRepository addressTypesRepository)
        {
            _addressTypesRepository = addressTypesRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AddressType>))]
        public IActionResult GetAddressTypes()
        {
            var addresstypes = _addressTypesRepository.GetAddressTypes();

            if (!ModelState.IsValid)
                return BadRequest(addresstypes);

            return Ok(addresstypes);
        }
    }
}
