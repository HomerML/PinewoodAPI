using Microsoft.AspNetCore.Mvc;
using PinewoodAPI.Interfaces;
using PinewoodAPI.Models;
using PinewoodAPI.Repository;

namespace PinewoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactTypesController : Controller
    {
        private IContactTypesRepository _contactTypesRepository;

        public ContactTypesController(IContactTypesRepository contactTypesRepository)
        {
            _contactTypesRepository = contactTypesRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ContactType>))]
        public IActionResult GetContactTypes()
        {
            var contacttypes = _contactTypesRepository.GetContactTypes();

            if (!ModelState.IsValid)
                return BadRequest(contacttypes);

            return Ok(contacttypes);
        }
    }
}
