using System;
using Domain.Common;
using Domain.Exception;

namespace Domain.Entities
{
    public class Account : BaseEntity
    {
        public Guid AccountId { get; set; }

        public string AccountName { get; set; }
        public decimal? Balance { get; set; }
        public Guid UserId { get; set; }

        public void WithdrawAccount(decimal withdrawAmount)
        {
            if (this.Balance > withdrawAmount)
            {
                this.Balance -= withdrawAmount;
            }
            else
            {
                throw new DomainException("Withdraw amount cannot exceed available balance");
            }
        }
    }
}
