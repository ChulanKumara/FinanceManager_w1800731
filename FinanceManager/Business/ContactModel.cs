using FinanceManager.DB;
using FinanceManager.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceManager.Business
{
    public class ContactModel
    {
        public async Task<bool> SaveContactDetails(List<ContactDetails> oContactDetails)
        {
            try
            {
                FinancialManagerDatabaseContainer db = new FinancialManagerDatabaseContainer();
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
    }
}