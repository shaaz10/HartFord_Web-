using AddressBook.CleanApi.Models;
using System.Collections.Generic;

namespace AddressBook.CleanApi.Services
{
    public interface IAddressBookService
    {
        List<AddressBook1> GetAll();

        AddressBook1? GetById(int id);

        AddressBook1 Create(AddressBook1 book);

        bool Update(int id, AddressBook1 book);

        bool Delete(int id);
    }
}
