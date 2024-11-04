using Microsoft.AspNetCore.Mvc;
using PinewoodAPI.Interfaces;
using PinewoodAPI.Models;
using PinewoodAPI.Repository;

namespace PinewoodAPI.Controllers
{
    public class EventTypeController : Controller
    {
        private IEventTypesRepository _eventsRepository;

        public EventTypeController(IEventTypesRepository eventTypesRepository)
        {
            _eventsRepository = eventTypesRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<EventType>))]
        public IActionResult GetEventypes()
        {
            var eventtypes = _eventsRepository.GetEventTypes();

            if (!ModelState.IsValid)
                return BadRequest(eventtypes);

            return Ok(eventtypes);
        }
    }
}
