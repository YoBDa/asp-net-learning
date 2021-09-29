using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkingWithVS.Models;
using Xunit;

namespace WorkingWithVS.Tests
{
    public class ProductTests
    {
        [Fact]
        public void CanChangeProductName()
        {
            //Arrange
            var p = new Product { Name = "Test", Price = 100M};
            string newName = "New Name";
            //Action

            p.Name = newName;
            //Assert
            Assert.Equal(newName, p.Name);
        }

        [Fact]
        public void CanChangeProductPrice()
        {
            //Arrange
            var p = new Product { Name = "Test", Price = 100M };
            decimal newPrice= 200M;
            //Action

            p.Price = newPrice;
            //Assert
            Assert.Equal(newPrice, p.Price);
        }
    }
}
