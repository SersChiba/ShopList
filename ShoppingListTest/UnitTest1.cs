using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ShoppingListOOP;

namespace ShoppingListOOP.Tests
{
    [TestClass()]
    public class UnitTest1
    {
        [TestMethod()]
        public void ListByCategoryTest()
        {
            //arrange
            List<Product> shoppingList = new List<Product>
        {
            new Product() { name="milk", price=.79M, category="food" },
            new Product() { name="beer", price=1.45M, category="alcoholic beverages" },
            new Product() { name="bread", price=2M, category="food" },
            new Product() { name="bulbs", price=6.49M, category="household goods" },
            new Product() { name="socks", price=11.11M, category="clothes" },
        };

            List<Product> expectedList = new List<Product>
        {
            new Product() { name="milk", price=.79M, category="food" },
            new Product() { name="bread", price=2M, category="food" }
        };

            
            //act
            
            //assert
           // Assert.AreEqual(expectedList,);
        }
    }

    internal class Product
    {
        public string category { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
    }
}