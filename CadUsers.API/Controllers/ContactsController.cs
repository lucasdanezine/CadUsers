using CadUsers.Business.ContactService;
using CadUsers.Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CadUsers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetContact(int id)
        {
            var contact = await _contactService.GetContactByIdAsync(id);
            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        [HttpGet("user/{userId}")]
        [Authorize]
        public async Task<IActionResult> GetContactsByUserId(int userId)
        {
            var contacts = await _contactService.GetContactsByUserIdAsync(userId);
            return Ok(contacts);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddContact(ContactDto contactDto)
        {
            await _contactService.AddContactAsync(contactDto);
            return CreatedAtAction(nameof(GetContact), new { id = contactDto.Id }, contactDto);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateContact(int id, ContactDto contactDto)
        {
            if (id != contactDto.Id)
                return BadRequest();

            await _contactService.UpdateContactAsync(contactDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _contactService.DeleteContactAsync(id);
            return NoContent();
        }
    }
}
