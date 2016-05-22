using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class VendingMachine : IVendingMachine
    {
        /// <summary>Vending machine manufacturer.</summary>
        public string Manufacturer { get; set; }
        /// <summary>Amount of money inserted into vending machine. </summary>
        public Money Amount { get; set; }
        /// <summary>Products that are sold.</summary>
        public Product[] Products { get; set; }
        /// <summary>Vending machine productlist.</summary>
        public Product[] ProductList { get; set; }
        public VendingMachine()
        {
            this.Products = new Product[0];
            this.ProductList = new Product[0];
            this.Amount = new Money() { Cents = 0, Euros = 0 };
        }
        /// <summary>Inserts the coin into vending machine.</summary>
       /// <param name="amount">Coin amount.</param>
      
        public Money InsertCoin(Money amount)
        {
            this.Amount = amount;                     
            return this.Amount;
        }
    
        /// <summary>Returns all inserted coins back to user.</summary>
        public Money ReturnMoney()
        {
            Money amount = this.Amount;
            this.Amount = new Money() {Cents = 0, Euros = 0 };
            return amount;
        }
        /// <summary>Buys product from list of product.<./summary>
        /// <param name="productNumber">Product number in vending machine productlist.</param>
        public Product Buy(int productNumber)
        {
            Product product = this.ProductList[productNumber];
            if (product.Available < 1) throw new System.Exception("This product is not available for purchase.");
            else if (this.Amount < product.Price) throw new System.Exception("Inserted money amount is less then selected product's price.");
            else
            {
                this.ProductList[productNumber].Available--;
                this.Amount = this.Amount - product.Price;
                Product [] products = new Product[1]{product};
                this.Products = this.Products.Concat(products).ToArray();                
                return product;

            }
          
        }
    }
}
