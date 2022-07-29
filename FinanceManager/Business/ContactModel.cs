using FinanceManager.DB;
using FinanceManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManager.Business
{
    public class ContactModel
    {
        public readonly FinancialManagerDatabaseContainer db = new FinancialManagerDatabaseContainer();

        public async Task<bool> SaveContactDetails(List<ContactDetails> oContactDetails)
        {
            try
            {
                foreach (var item in oContactDetails)
                {
                    Contact contactData = new Contact
                    {
                        Name = item.Name,
                        Type = item.Type,
                        Cotegory = item.Catogery,
                    };
                    db.Contacts.Add(contactData);
                }
                return await db.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ContactDetails> GetAll()
        {
            try
            {
                List<ContactDetails> contacts = new List<ContactDetails>();
                var results = db.Contacts.ToList();
                foreach (var item in results)
                {
                    ContactDetails contactDetails = new ContactDetails
                    {
                        Name = item.Name,
                        Type = item.Type,
                        Catogery = item.Cotegory,
                    };
                    contacts.Add(contactDetails);
                }
                return contacts;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}