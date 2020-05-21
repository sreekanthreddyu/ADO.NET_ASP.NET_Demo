using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADODotNetDemoCode
{
    public class Product
    {
        private int productId;

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        private string productName;

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        private double rate;

        public double Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        
    }
}