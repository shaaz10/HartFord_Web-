using AddressBook.CleanApi.Models;

namespace AddressBook.CleanApi.Services
{
    public class AddressBookService : IAddressBookService
    {
        private static List<AddressBook1> _books = new List<AddressBook1>
        {
            new AddressBook1
            {
                Id = 1,
                Address = "Bachupally",
                City = "Hyderabad",
                Region = 2,
                PostalCode = 2000,
                Name = "Shaaz"
            },
            new AddressBook1
            {
                Id = 2,
                Address = "Nizampet",
                City = "Bangalore",
                Region = 4,
                PostalCode = 3000,
                Name = "Bharath"
            }
        };

        public List<AddressBook1> GetAll()
        {
            return _books;
        }

        public AddressBook1? GetById(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public AddressBook1 Create(AddressBook1 book)
        {
            book.Id = _books.Any() ? _books.Max(b => b.Id) + 1 : 1;
            _books.Add(book);
            return book;
        }

        public bool Update(int id, AddressBook1 book)
        {
            var existing = _books.FirstOrDefault(b => b.Id == id);
            if (existing == null) return false;

            existing.Name = book.Name;
            existing.Address = book.Address;
            existing.City = book.City;
            existing.Region = book.Region;
            existing.PostalCode = book.PostalCode;

            return true;
        }

        public bool Delete(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null) return false;

            _books.Remove(book);
            return true;
        }
    }
}
