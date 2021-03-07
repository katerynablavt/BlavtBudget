using BlavtBudget;
using System;
using System.Collections.Generic;
using Xunit;

namespace BudgetTests
{
   public class WalletTest
    {

        [Fact]
        public void WalletNameTestValid()
        {
            //Arrange
            var wallet = new Wallet(1) { WalletName = "My Wallet" };
            var expected = "My Wallet";
            //Act
            var actual = wallet.WalletName;
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void CurrencyTestValid()
        {
            //Arrange
            var wallet = new Wallet(1) { Currency = Currency.grn };
            var expected = Currency.grn;
            //Act
            var actual = wallet.Currency;
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateWallet()
        {
            var customer = new Customer { FirstName = "Kate", LastName = "Blavt", Email = "Email" };
            var wallet = new Wallet(customer.Id) { Description = "New wallet", WalletName = "My wallet" ,
                                                   Currency = Currency.grn, StartBalance = 100};

            Assert.Equal("My wallet", wallet.WalletName);
            Assert.Equal("New wallet", wallet.Description);
            Assert.Equal(Currency.grn, wallet.Currency);
            Assert.Equal(100, wallet.StartBalance);
            Assert.Equal(wallet.CustomerOwnerId, customer.Id) ;
        }

        [Fact]
        public void ValidateValid()
        {
            //Arrange
            var customer = new Customer { FirstName = "Kate", LastName = "Blavt", Email = "Email" };

            var wallet = new Wallet(customer.Id);
            //Act
            var actual = wallet.Validate();
            //Assert
            Assert.True(actual);
        }
        [Fact]
        public void InstanceCountWallet()
        {
            var customer = new Customer { FirstName = "Kate", LastName = "Blavt", Email = "Email" };
            var wallet = new Wallet(customer.Id);
            var wallet1 = new Wallet(customer.Id);

            Assert.NotEqual(wallet.WalletId, wallet1.WalletId);
            Assert.Equal(wallet.WalletId + 1, wallet1.WalletId);
        }
    }
}
