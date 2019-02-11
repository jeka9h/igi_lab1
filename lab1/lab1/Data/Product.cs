﻿using System;
using System.Collections.Generic;
using System.Text;

namespace lab1.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Packaging { get; set; }
        public List<Stock> Stocks { get; set; }
    }
}
