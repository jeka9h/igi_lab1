using System;
using System.Collections.Generic;
using System.Text;

namespace lab1.Data
{
    public class Discount
    {
        public int Id { get; set; }
        public int Rebate { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
