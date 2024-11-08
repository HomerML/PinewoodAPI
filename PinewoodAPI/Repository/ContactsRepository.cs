using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PinewoodAPI.Data;
using PinewoodAPI.Interfaces;
using PinewoodAPI.Models;
using System.Diagnostics;

namespace PinewoodAPI.Repository
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly DataContext _dataContext;

        public ContactsRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool ContactExists(int id)
        {
            return _dataContext.Contacts.Any(c => c.ContactId == id);
        }

        public bool CustomerContactExists(int id)
        {
            return _dataContext.Contacts.Any(c => c.CustomerId == id);
        }

        public ICollection<Contact> GetContacts(int id)
        {
            return _dataContext.Contacts.Where(e => e.CustomerId == id).ToList();
        }

        public ICollection<ContactViewModel> GetContactsList(int id)
        {
            var contactsWithDetails = (from contact in _dataContext.Contacts
                                        join status in _dataContext.Statuses on contact.StatusId equals status.StatusId into statusJoin
                                        from status in statusJoin.DefaultIfEmpty() // LEFT OUTER JOIN with Statuses
                                        join user in _dataContext.Users on contact.UpdatedBy equals user.UserId into userJoin
                                        from user in userJoin.DefaultIfEmpty() // LEFT OUTER JOIN with Users
                                        join contactType in _dataContext.ContactTypes on contact.ContactTypeId equals contactType.ContactTypeId into contactTypeJoin
                                        from contactType in contactTypeJoin.DefaultIfEmpty() // LEFT OUTER JOIN with ContactTypes
                                        where contact.StatusId == 1 && contact.CustomerId == id
                                        select new
                                        {
                                            contact.ContactId,
                                            contact.CustomerId,
                                            contact.Description,
                                            contact.ContactDetail,
                                            contact.MarketingAllowed,
                                            ContactDescription = contactType != null ? contactType.ContactDescription : null,
                                            StatusDescription = status != null ? status.StatusDescription : null,
                                            UpdatedBy = user != null ? (user.FirstName + " " + user.LastName) : null // Concatenating FirstName and LastName
                                        })
                                 .ToList();

            var viewModelList = contactsWithDetails.Select(c => new ContactViewModel
            {
                ContactId = c.ContactId,
                CustomerId = c.CustomerId,
                Description = c.Description,
                ContactDetail = c.ContactDetail,
                MarketingAllowed = c.MarketingAllowed,
                ContactDescription = c.ContactDescription,
                StatusDescription = c.StatusDescription,
                UpdatedBy = c.UpdatedBy
            }).ToList();

            return viewModelList;
        }

        public Contact GetContact(int id)
        {
            return _dataContext.Contacts.Where(e => e.ContactId == id).FirstOrDefault();
        }

        public bool CreateContact(Contact contact)
        {
            _dataContext.Contacts.Add(contact);
            return Save();
        }

        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateContact(Contact contact)
        {
            _dataContext.Update(contact);
            return Save();
        }
    }
}
