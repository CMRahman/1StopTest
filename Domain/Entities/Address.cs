using System;
using Domain.Common;

namespace Domain.Entities
{
    public class Address : BaseEntity
    {
        public Guid AddressId { get; set; }
        public string State { get; set; }
        public int PostCode { get; set; }

        public Guid UserId { get; set; }

    }
}
