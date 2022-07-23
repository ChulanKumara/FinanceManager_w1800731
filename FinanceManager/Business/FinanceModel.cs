using FinanceManager.DB;
using FinanceManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Business
{
    public class FinanceModel
    {
        public async Task<bool> SaveFinanceDetails(List<FinanceDetails> oFinanceDetails)
        {
            try
            {
                FinancialManagerDatabaseContainer db = new FinancialManagerDatabaseContainer();
                foreach (var item in oFinanceDetails)
                {
                    Finance financeData = new Finance
                    {
                        ContactId = item.ContactId,
                        Name = item.Name,
                        Amount = item.Amount,
                        Recurring = item.Recurring,
                        Date = item.Date
                    };
                    db.Finances.Add(financeData);
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