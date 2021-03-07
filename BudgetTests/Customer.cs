using BlavtBudget;
using System;
using Xunit;

namespace BudgetTests
{
    public class CustomerTest
    {
        [Fact]
        public void FullNameTestValid()
        {
            //Arrange
            var customer = new Customer { FirstName = "Volodymyr", LastName = "Yablonskyi" };

            var expected = "Yablonskyi, Volodymyr";

            //Act
            var actual = customer.FullName;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FullNameNoFirstNameTest()
        {
            //Arrange
            var customer = new Customer { LastName = "Yablonskyi" };

            var expected = "Yablonskyi";

            //Act
            var actual = customer.FullName;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FullNameNoLastNameTest()
        {
            //Arrange
            var customer = new Customer { FirstName = "Volodymyr" };

            var expected = "Volodymyr";

            //Act
            var actual = customer.FullName;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValidateValid()
        {
            //Arrange
            var customer = new Customer() { FirstName = "Volodymyr", LastName = "Yablonskyi", Email = "yablonskyi.v.reg@gmail.com" };

            //Act
            var actual = customer.Validate();

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public void ValidateNoName()
        {
            //Arrange
            var customer = new Customer() { Email = "yablonskyi.v.reg@gmail.com" };

            //Act
            var actual = customer.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateNoEmail()
        {
            //Arrange
            var customer = new Customer() { FirstName = "Volodymyr", LastName = "Yablonskyi", Email = "yablonskyi.v.reg@gmail.com" };

            //Act
            var actual = customer.Validate();

            //Assert
            Assert.False(actual);
        }
        //[Fact]
        //public void ValidateNoWallets()
        //{
        //    //Arrange
        //    var customer = new Customer() { FirstName = "Volodymyr", LastName = "Yablonskyi" };

        //    //Act
        //    var actual = customer.Validate();

        //    //Assert
        //    Assert.False(actual);
        //}

        [Fact]
        public void ValidateEmptyCustomer()
        {
            //Arrange
            var customer = new Customer();

            //Act
            var actual = customer.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void CustomerCounterTest()
        {
            //Arrange
            var customer = new Customer();
            var customer1 = new Customer();
            var customer2 = new Customer();

            //Act            

            //Assert
            Assert.Equal(customer1.Id, customer.Id + 1);
            Assert.Equal(customer2.Id, customer1.Id + 1);
        }
    }
}
