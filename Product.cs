﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanasInventoryManagementSystem
{
    public class Product
    {
        private int id = 0;
        public int Id { get; private set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }


        public Product(string name, decimal price, int quantity)
        {
            Id = ++id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
}
