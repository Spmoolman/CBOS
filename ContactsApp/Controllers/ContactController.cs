using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CBOS.Repositories;
using ContactsApp.Models;
using System.ComponentModel.DataAnnotations;

namespace ContactsApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IContactRepository _contactRepo;
        
        public ContactController(ILogger<ContactController> logger, IContactRepository contactRepo)
        {
            _logger = logger;
            _contactRepo = contactRepo;
        }
        
        [HttpPost]
        public IActionResult CreateContact([FromBody]ContactViewModel newContact)
        {
            try
            {
                return Ok(_contactRepo.CreateNewContact(newContact));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        [HttpGet]
        public ContactViewModel GetContact([FromQuery]int Id)
        {
            try
            {
                return _contactRepo.ReadContact(Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        [HttpGet("Contacts")]
        public IActionResult GetContacts()
        {
            try
            {
                return Ok(_contactRepo.GetAllContacts());
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        [HttpPut]
        public IActionResult UpdateContact([FromBody]ContactViewModel contactToUpdate)
        {
            try
            {
                return Ok(_contactRepo.UpdateContact(contactToUpdate));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        [HttpDelete]
        public IActionResult DeleteContact([FromQuery]int Id)
        {
            try
            {
                return Ok(_contactRepo.DeleteContact(Id));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }
    }
}