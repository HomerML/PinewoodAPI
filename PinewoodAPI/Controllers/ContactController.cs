using Microsoft.AspNetCore.Mvc;
using PinewoodAPI.Interfaces;
using PinewoodAPI.Models;
using PinewoodAPI.Repository;

namespace PinewoodAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactController : Controller
    {
        private IContactsRepository _contactsRepository;

        public ContactController(IContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }


        [HttpGet("{customerId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Contact>))]
        public IActionResult GetContacts(int customerId)
        {
            if (!_contactsRepository.CustomerContactExists(customerId))
                return NotFound();

            var contacts = _contactsRepository.GetContacts(customerId);


            if (!ModelState.IsValid)
                return BadRequest(contacts);

            return Ok(contacts);
        }


        [HttpGet("{customerId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ContactViewModel>))]
        public IActionResult GetContactsList(int customerId)
        {
            if (!_contactsRepository.CustomerContactExists(customerId))
                return NotFound();

            var contacts = _contactsRepository.GetContactsList(customerId);


            if (!ModelState.IsValid)
                return BadRequest(contacts);

            return Ok(contacts);
        }


        [HttpGet("{contactId}")]
        [ProducesResponseType(200, Type = typeof(Contact))]
        [ProducesResponseType(400)]
        public IActionResult GetContact(int contactId)
        {
            if (!_contactsRepository.ContactExists(contactId))
                return NotFound();

            var contact = _contactsRepository.GetContact(contactId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(contact);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateContact([FromBody] Contact contactCreate)
        {
            if (CreateContact == null)
                return BadRequest(ModelState);

            //var contact = _contactsRepository.GetContacts()
            //    .Where(c => c.ContactDetail.Trim().ToUpper() == contactCreate.ContactDetail.TrimEnd().ToUpper())
            //    .FirstOrDefault();

            //if (contact != null)
            //{
            //    ModelState.AddModelError("", "Contact already exists");
            //    return StatusCode(422, ModelState);
            //}

            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!_contactsRepository.CreateContact(contactCreate))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }


        [HttpPut("{contactId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateContact(int contactId, [FromBody] Contact updatedContact)
        {
            if (updatedContact == null)
                return BadRequest(ModelState);

            if (contactId != updatedContact.ContactId)
                return BadRequest(ModelState);

            if (!_contactsRepository.ContactExists(contactId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();


            if (!_contactsRepository.UpdateContact(updatedContact))
            {
                ModelState.AddModelError("", "Something went wrong updating");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }

    }
}
