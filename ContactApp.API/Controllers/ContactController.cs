using ContactApp.API.Models;
using ContactAppModels;
using Microsoft.AspNetCore.Mvc;

namespace ContactApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet("Contacts")]
        public async Task<ActionResult<List<Contact>>> GetContacts()
        {
            try
            {
                var result = await _contactRepository.GetContacts();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("Single/{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            try
            {
                var result = await _contactRepository.GetContact(id);

                if (result == null)

                    return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPost("add")] 
        public async  Task<ActionResult<Contact>> AddContact(Contact contact)
        {
            try
            {
                if (contact == null)

                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

              /* var existingContact = _contactRepository.GetContactbyEmail(contact.Email);
                if (existingContact != null)
                {
                    ModelState.AddModelError("email", "Email already in use");
                    return BadRequest(ModelState);
                } */

                var CreatedContact = await _contactRepository.AddContact(contact);

                return CreatedAtAction(nameof(AddContact), new { id = CreatedContact.Id }, CreatedContact);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new contact record");
            }
        }
         
        [HttpPut("Update")] 
        public async Task<ActionResult<Contact>> UpdateContact([FromBody]Contact contact)
        {
            try
            {
                var contactToUpdate = await _contactRepository.GetContact(contact.Id);

                if (contactToUpdate == null)
                {
                    return NotFound($"Employee with Id = {contact.Id} not found");
                }

                return await _contactRepository.UpdateContact(contact);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<Contact>> DeleteContact(int id)
        {
            try
            {
                var employeeToDelete = await _contactRepository.GetContact(id);

                if (employeeToDelete == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }

                return await _contactRepository.DeleteContact(id);
                
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new employee record");
            }
        }

        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<Contact>>> Search(string name)
        {
            try
            {
                var result = await _contactRepository.Search(name);

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

    }
}
