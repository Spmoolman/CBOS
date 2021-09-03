using System.Collections.Generic; 
using ContactsApp.Models;
using System.Threading.Tasks;

namespace CBOS.Repositories
{
    public interface IContactRepository
    {
        Task<bool> CreateNewContact(ContactViewModel newContact);
        ContactViewModel ReadContact(int id);
        Task<bool> UpdateContact(ContactViewModel newContact);
        Task<bool> DeleteContact(int id);
        IEnumerable<ContactViewModel> GetAllContacts();
    }
}