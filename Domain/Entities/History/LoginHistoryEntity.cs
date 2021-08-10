using System;

namespace Domain.Entities.History
{
    public class LoginHistoryEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Email {get;set; }
    }
}
