using System;
using System.Collections.Generic;
using System.Text;

namespace lab1.Data
{
    public class Stock
    {
        public int Id { get; set; }
        public string DateOfDelivery { get; set; }
        public int Count { get; set; }
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
