using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBookApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdressBookController : ControllerBase
    {
        // Object intitializer of adressbook
        private static List<AddressBook> _books = new List<AddressBook>
        {
           new AddressBook{ Address="Bachupally",City="Hyderabad",Region=2,PostalCode=2000,Name="shaaz"},
           new AddressBook{Address="Nizampet",City="Banglore",Region=4,PostalCode=3000,Name="Bharath"} 
        };
        [HttpGet(Name = "GetAddressBook")]
        public IActionResult GetAll()
        {
            return Ok(_books);
        }
        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            var book=_books.FirstOrDefault(b => b.Name == name);
            if (book == null)
            {
                return NotFound("Product not Found");
            }
            return Ok(book);
        }
        [HttpGet("{address}")]
        public IActionResult GetByAddress(string address)
        {
            var book=_books.FirstOrDefault(b => b.Address == address);
            if (book == null)
            {
                return NotFound("adress not Found");
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Create(AddressBook book)
        {
                // book.Address=_books[0].Address;
                _books.Add(book);
                return CreatedAtAction(nameof(GetByAddress),new {Address=book.Address,book});
        }

        [HttpPut("{address}")]
        public IActionResult Update(string address,AddressBook Updatedbook)
        {
            var book=_books.FirstOrDefault(b => b.Address == address);
            if(book == null)
            {
                return NotFound("adress not found");

            }
            book.Address=Updatedbook.Address;
            book.Name=Updatedbook.Name;
            return NoContent();
               

        }
        [HttpDelete("{address}")]
        public IActionResult Delete(string address)
        {
            var book=_books.FirstOrDefault(b=>b.Address == address);
            if (book == null)
            {
                return NotFound("the address is not found");
            }
            _books.Remove(book);
            return NoContent();
        }
        
    }
}