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

        public static void WithdrawAccount(Account accountToUpdate, decimal amount)
        {
            if (accountToUpdate.Balance > amount)
            {
                accountToUpdate.Balance -= amount;
            }
            else
            {
                throw new DomainException("Withdraw amount cannot exceed available balance");
            }
        }
    }
}
