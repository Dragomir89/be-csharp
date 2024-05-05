using BestStoreApi.Models;
using BestStoreApi.Serrvices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BestStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ContactsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetContacts() 
        {
            var contacts = _context.Contacts.ToList();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public IActionResult GetContact(int id) 
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null) 
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpPost]
        public IActionResult CreateContact(ContactDto contactDto) 
        {
            Contact contact = new Contact() 
            { 
                FirstName = contactDto.FirstName,
                LastName = contactDto.LastName,
                Email = contactDto.Email,
                Phone = contactDto.Phone ?? "",
                Subject = contactDto.Subject,
                Message = contactDto.Message,
                CreatedAt = DateTime.Now,
            };
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok(contact);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id, ContactDto contactDto) 
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null) 
            {
                return NotFound();
            }
            contact.FirstName = contactDto.FirstName;
            contact.LastName = contactDto.LastName;
            contact.Email = contactDto.Email;
            contact.Phone = contactDto.Phone ?? "";
            contact.Subject = contactDto.Subject;
            contact.Message = contactDto.Message;

            _context.SaveChanges();

            return Ok(contact);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id) 
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null) 
            { 
                return NotFound();
            }

            _context.Contacts.Remove(contact);
            _context.SaveChanges();

            return Ok(contact);
        }

    }
}
