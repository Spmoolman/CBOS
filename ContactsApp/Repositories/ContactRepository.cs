using System.Collections.Generic; 
using CBOS.DataModels;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ContactsApp.Models;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Text;
using AutoMapper;

namespace CBOS.Repositories
{
    public class ContactRepository: IContactRepository 
    {
        private readonly ContactContext _context;
        private readonly IMapper _mapper;

        public ContactRepository(ContactContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<bool> CreateNewContact(ContactViewModel newContact)
        {
            try
            {
                var contactToAdd = new Contact
                {  
                    FirstName = newContact.FirstName,
                    LastName = newContact.LastName,
                    ContactNumber = newContact.ContactNumber,
                    EmailAddress = newContact.EmailAddress
                };
                _context.Contact.Add(contactToAdd);
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {                
                throw;
            }
        }

        public ContactViewModel ReadContact(int id)
        {
            try
            {
                var contact = _context.Contact.FirstOrDefault(f => f.ContactId == id);
                var returnVal = _mapper.Map<Contact, ContactViewModel>(contact);
                return returnVal;
            }
            catch (Exception ex)
            {                
                throw;
            }
        }

        public async Task<bool> UpdateContact(ContactViewModel newContact)
        {
            try
            {
                var contactToUpdate = _context.Contact.FirstOrDefault(f => f.ContactId == newContact.ContactId);
                 
                contactToUpdate.FirstName = newContact.FirstName;
                contactToUpdate.LastName = newContact.LastName;
                contactToUpdate.ContactNumber = newContact.ContactNumber;
                contactToUpdate.EmailAddress = newContact.EmailAddress;
                
                return _context.SaveChanges() > 0;
                
            }
            catch (Exception ex)
            {                
                throw;
            }
        }

        public async Task<bool> DeleteContact(int id)
        {
            try
            {
               _context.Contact.Remove(_context.Contact.Find(id));                  
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {                
                throw;
            }
        }

        public IEnumerable<ContactViewModel> GetAllContacts()
        {
            try
            {
                var contact = _context.Contact.ToList();
                var returnVal = _mapper.Map<List<Contact>, List<ContactViewModel>>(contact);
                return returnVal;                
            }
            catch (Exception ex)
            {                
                throw;
            }
        }
    }
}