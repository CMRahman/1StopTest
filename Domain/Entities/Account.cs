using System;
using Domain.Common;

namespace Domain.Entities
{
    public class Account : BaseEntity
    {
        public Guid AccountId { get; set; }
        public decimal? Balance { get; set; }
        public int UserId { get; set; }
    }
}
