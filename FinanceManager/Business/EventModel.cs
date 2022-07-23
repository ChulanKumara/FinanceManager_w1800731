using FinanceManager.DB;
using FinanceManager.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceManager.Business
{
    public class EventModel
    {
        public async Task<bool> SaveEventDetails(List<EventDetails> oEventDetails)
        {
            try
            {
                FinancialManagerDatabaseContainer db = new FinancialManagerDatabaseContainer();
                foreach (var item in oEventDetails)
                {
                    Event eventData = new Event
                    {
                        Name = item.Name,
                        Description = item.Description,
                        Type = item.Type,
                        Recurring = item.Recurring,
                        Date = item.Date
                    };
                    db.Events.Add(eventData);
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