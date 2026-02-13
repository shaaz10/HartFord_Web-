using Microsoft.AspNetCore.Mvc;
using AddressBook.CleanApi.Services;
using AddressBook.CleanApi.Models;

namespace AddressBook.CleanApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressBook1Controller : ControllerBase
    {
        private readonly IAddressBookService _service;

        public AddressBook1Controller(IAddressBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _service.GetById(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public IActionResult Create(AddressBook1 book)
        {
            var created = _service.Create(book);

            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, AddressBook1 book)
        {
            var success = _service.Update(id, book);
            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _service.Delete(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
