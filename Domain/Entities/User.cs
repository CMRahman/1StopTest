using System;
using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
