using System;

namespace FinanceManager.Models
{
    public class EventDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public bool Recurring { get; set; }
        public DateTime Date { get; set; }
    }
}