using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using lab1.Data;

namespace lab1
{
    public static class DbInitializer
    {
        public static void Initialize(StockContext db)
        {
            db.Database.EnsureCreated();
            if(db.Stocks.Any())
            {
                return;
            }
            Stock stock = new Stock();
            db.Stocks.Add(stock);
            db.SaveChanges();
            Product product1 = new Product() { Name = "Гречка", Manufacturer = "Колхоз Заря", Stock = stock };
            Product product2 = new Product() { Name = "Рис", Manufacturer = "Колхоз Заря", Stock = stock };
            Product product3 = new Product() { Name = "Пшенка", Manufacturer = "Колхоз Заря", Stock = stock };
            Product product4 = new Product() { Name = "Чай", Manufacturer = "Липтон", Stock = stock };
            Product product5 = new Product() { Name = "Кофе", Manufacturer = "Якобс", Stock = stock };
            Product product6 = new Product() { Name = "Кисель", Manufacturer = "Баба Валя", Stock = stock };
            Product product7 = new Product() { Name = "Яблоко", Manufacturer = "Колхоз Заря", Stock = stock };
            Product product8 = new Product() { Name = "Апельсин", Manufacturer = "Африка", Stock = stock };
            Product product9 = new Product() { Name = "Банан", Manufacturer = "Африке", Stock = stock };
            Product product10 = new Product() { Name = "Картофель", Manufacturer = "Колхоз Заря", Stock = stock };
            Product product11 = new Product() { Name = "Помидор", Manufacturer = "Колхоз Заря", Stock = stock };
            Product product12 = new Product() { Name = "Огурец", Manufacturer = "Колхоз Заря", Stock = stock };
            db.Products.AddRange(new Product[] { product1, product2, product3, product4, product5, product6, product7, product8, product9, product10, product11, product12 });
            db.SaveChanges();
            Discount discount1 = new Discount() { Rebate = 10, ProductId = product1.Id };
            Discount discount2 = new Discount() { Rebate = 30, ProductId = product5.Id };
            Discount discount3 = new Discount() { Rebate = 15, ProductId = product9.Id };
            Discount discount4 = new Discount() { Rebate = 3, ProductId = product10.Id };
            Discount discount5 = new Discount() { Rebate = 7, ProductId = product8.Id };
            db.Discounts.AddRange(new Discount[] { discount1, discount2, discount3, discount4, discount5 });
            db.SaveChanges();
        }
    }
}
