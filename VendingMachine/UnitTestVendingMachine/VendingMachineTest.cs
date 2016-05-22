using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Domain.Entities;

namespace UnitTestVendingMachine
{
    [TestClass]
    public class VendingMachineTest
    {
        // Testing InsertCoin() method.
        [TestMethod]
        public void CanReceiveCoins()
        {
            Mock<VendingMachine> mock = new Mock<VendingMachine>();                    
            Money insertedCoins = new Money(){Cents = 70, Euros = 1};
            mock.Object.InsertCoin(insertedCoins);
            Assert.AreEqual(mock.Object.Amount.Cents, 70);
            Assert.AreEqual(mock.Object.Amount.Euros, 1);
        }
        // Testing ReturnMoney() method.
        [TestMethod]
        public void CanReturnMoney()
        {
            Mock<VendingMachine> mock = new Mock<VendingMachine>();
            Money insertedCoins = new Money() { Cents = 70, Euros = 1 };
            mock.Object.InsertCoin(insertedCoins);

            Money result = mock.Object.ReturnMoney();
            Assert.AreEqual(mock.Object.Amount.Cents, 0);
            Assert.AreEqual(mock.Object.Amount.Euros, 0);
            Assert.AreEqual(result.Cents, 70);
            Assert.AreEqual(result.Euros, 1);
        }
        // Testing Buy() method.
        [TestMethod]
        public void CanBuyProduct()
        {
            Mock<VendingMachine> mock = new Mock<VendingMachine>();

            mock.Object.ProductList = new Product[]
            {
                new Product(){Available = 3, Name = "Sprite", Price = new Money(){Cents = 70, Euros = 0}},
                new Product(){Available = 2, Name = "Cola", Price = new Money(){Cents = 60, Euros = 0}},
                new Product(){Available = 1, Name = "Lays", Price = new Money(){Cents = 80, Euros = 0}},
                new Product(){Available = 1, Name = "Chocolate", Price = new Money(){Cents = 10, Euros = 1}}
            };

            Money insertedCoins = new Money() { Cents = 70, Euros = 2 };
            mock.Object.InsertCoin(insertedCoins);
            Product result = mock.Object.Buy(2);

            Assert.AreEqual(result.Name, "Lays");
            Assert.AreEqual(mock.Object.ProductList[2].Available, 0);
            Assert.AreEqual(mock.Object.Products[0].Name, "Lays");
          
        }
    }
}
