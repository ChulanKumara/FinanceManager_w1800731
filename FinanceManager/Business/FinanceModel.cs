using FinanceManager.DB;
using FinanceManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManager.Business
{
    public class FinanceModel
    {
        public readonly FinancialManagerDatabaseContainer db = new FinancialManagerDatabaseContainer();

        public async Task<bool> SaveFinanceDetails(List<FinanceDetails> oFinanceDetails)
        {
            try
            {
                foreach (var item in oFinanceDetails)
                {
                    Finance financeData = new Finance
                    {
                        ContactId = item.ContactId,
                        Name = item.Name,
                        Type = item.Type,
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

        public List<FinanceDetails> GetAllDataByParams(string type, DateTime fromDate, DateTime toDate)
        {
            try
            {
                List<FinanceDetails> oFinanceDetails = new List<FinanceDetails>();
                List<Finance> results = db.Finances.Where(x => x.Type == type && x.Date >= fromDate.Date && x.Date <= toDate.Date).ToList();

                foreach (var item in results)
                {
                    FinanceDetails financeDetails = new FinanceDetails
                    {
                        Id = item.Id,
                        ContactId = item.ContactId,
                        Name = item.Name,
                        Type = item.Type,
                        Amount = item.Amount,
                        Recurring = item.Recurring,
                        Date = item.Date
                    };
                    oFinanceDetails.Add(financeDetails);
                }

                return oFinanceDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<FinanceDetails> GetAllDataBydate(DateTime fromDate, DateTime toDate)
        {
            try
            {
                List<FinanceDetails> oFinanceDetails = new List<FinanceDetails>();
                List<Finance> results = db.Finances.Where(x => x.Date.Month >= fromDate.Date.Month && x.Date.Month <= toDate.Date.Month).ToList();

                foreach (var item in results)
                {
                    FinanceDetails financeDetails = new FinanceDetails
                    {
                        Id = item.Id,
                        ContactId = item.ContactId,
                        Name = item.Name,
                        Type = item.Type,
                        Amount = item.Amount,
                        Recurring = item.Recurring,
                        Date = item.Date
                    };
                    oFinanceDetails.Add(financeDetails);
                }

                return oFinanceDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateData(FinanceDetails financeDetails)
        {
            try
            {
                Finance financeData = new Finance
                {
                    Id = financeDetails.Id,
                    ContactId = financeDetails.ContactId,
                    Name = financeDetails.Name,
                    Type = financeDetails.Type,
                    Amount = financeDetails.Amount,
                    Recurring = financeDetails.Recurring,
                    Date = financeDetails.Date
                };
                db.Finances.AddOrUpdate(financeData);
                return db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteData(int id)
        {
            try
            {
                var result = db.Finances.Where(x => x.Id == id).FirstOrDefault();
                db.Finances.Remove(result);
                return db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}