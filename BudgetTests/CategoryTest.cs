using BlavtBudget;
using System;

using Xunit;

namespace BudgetTests
{

    public class CategoryTest
    {
        [Fact]
        public void CategoryCounterTest()
        {
            //Arrange


            var customer = new Customer();
            var category = new Category(customer.Id);
            var category1 = new Category(customer.Id);
            var category2 = new Category(customer.Id);
            //Act            
            //Assert
            Assert.Equal(category1.Id, category.Id + 1);
            Assert.Equal(category2.Id, category1.Id + 1);
        }
    }
}
