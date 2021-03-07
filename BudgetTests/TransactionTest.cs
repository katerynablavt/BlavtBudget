using BlavtBudget;
using BlavtBudget.Entities;
using System;
using Xunit;

namespace BudgetTests
{
    public class TransactionTest
    {
        [Fact]
        public void TransactionDescriptionTestValid()
        {
            //Arrange
            var customer = new Customer { FirstName = "Kate", LastName = "Blavt", Email = "Email" };
            var wallet = new Wallet(customer.Id);
            var transaction = new Transaction(customer.Id);
            var expected = transaction.CustomerId;
            //Act
            var actual = customer.Id;
            //Assert
            Assert.Equal(expected, actual);
            
        }
        [Fact]
        public void TransactionValid()
        {
            var customer = new Customer { FirstName = "Kate", LastName = "Blavt", Email = "Email" };

            var wallet = new Wallet(customer.Id) { Description = "Daphalt name", WalletName = "My wallet" };
            var transaction = new Transaction(customer.Id) { WalletId = wallet.WalletId, Sum = 100, Currency = Currency.grn, Date = new DateTime(2015, 12, 31) };

            var actual = transaction.Validate();

            Assert.True(actual);
        }
    }
}
