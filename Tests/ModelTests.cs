using System;
using Xunit;
using Models;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CustomerShouldBeValidName()
        {
            //Arrange
            Customer customer = new Customer();
            string testName = "Tenzin";
            
            //Act
            customer.Name = testName;

            //Assert
            Assert.Equal(testName, customer.Name);

        }

        
    }
}
