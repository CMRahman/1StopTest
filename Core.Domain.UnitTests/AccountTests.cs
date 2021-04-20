using Domain.Entities;
using Domain.Exception;
using FluentAssertions;
using Xunit;

namespace Core.Domain.UnitTests
{
    public class AccountTests
    {
        [Fact]
        public void Account_When_Trying_To_Withdraw_More_Than_Available_Balance_Should_Raise_Exception()
        {
            var sut = new Account();
            sut.Balance = 10.0m;
            var withdrawAmount = 150.0m;


            sut.Invoking(a => a.WithdrawAccount(withdrawAmount))
                .Should()
                .Throw<DomainException>()
                .WithMessage("Withdraw amount cannot exceed available balance");



        }

        [Theory]
        [InlineData(105.0, 2.0, 103.0)]
        [InlineData(10.0, 2.40, 6.60)]
        [InlineData(105.65, 2.30, 103.35)]
        [InlineData(100.0, 0.05, 99.95)]
      
        public void Account_When_Withdrawing_Should_Deduct_Amount_From_Balance(decimal availableBalance, decimal withdrawAmount, decimal remainingBalance)
        {
            var sut = new Account();
            sut.Balance = availableBalance;


            sut.WithdrawAccount(withdrawAmount);


            sut.Balance.Should().Equals(remainingBalance);
        }

        [Theory]
        [InlineData(105.0, 2.0, 107.0)]
        [InlineData(10.0, 2.40, 12.40)]
        [InlineData(105.65, 2.30, 107.95)]
        [InlineData(100.0, 0.05, 100.05)]
        public void Account_When_Depositing_Should_Increase_Balance(decimal currentBalance, decimal deposit,
            decimal expectedBalance)
        {
            var sut = new Account();
            sut.Balance = currentBalance;

            sut.DepositAccount(deposit);

            sut.Balance.Should().Equals(expectedBalance);

        }
    }
}
