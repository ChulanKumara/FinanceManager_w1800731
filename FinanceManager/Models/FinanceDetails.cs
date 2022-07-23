using System;

namespace FinanceManager.Models
{
    public class FinanceDetails
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; }
        public bool Recurring { get; set; }
        public DateTime Date { get; set; }
    }
}