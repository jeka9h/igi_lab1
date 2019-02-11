using System;
using System.Collections.Generic;
using System.Text;

namespace lab1.Data
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Addres { get; set; }
        public string Phone { get; set; }
        public List<Stock> Stocks { get; set; }
    }
}
