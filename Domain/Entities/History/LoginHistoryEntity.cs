using System;

namespace Domain.Entities.History
{
    public class LoginHistoryEntity
    {
        public string Name { get; set; }
        public string Email {get;set; }
        public DateTime Date { get; set; }
        public string Ip { get; set; }
    }
}
