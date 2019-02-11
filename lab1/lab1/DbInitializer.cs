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
            if(db.Products.Any()||db.Providers.Any())
            {
                return;
            }
            Product product1 = new Product() { Name = "Гречка", Manufacturer = "Колхоз Заря",Packaging="Пакет"};
            Product product2 = new Product() { Name = "Кофе", Manufacturer = "Якобс",Packaging="Вакуумная упаковка"};
            Product product3 = new Product() { Name = "Банан", Manufacturer = "Африке",Packaging="Сетка"};
            Product product4 = new Product() { Name = "Картофель", Manufacturer = "Колхоз Заря",Packaging="Мешок"};
            Product product5 = new Product() { Name = "Огурец", Manufacturer = "Колхоз Заря",Packaging="Мешок"};
            db.Products.AddRange(new Product[] { product1, product2, product3, product4, product5});
            db.SaveChanges();
            Provider provider1 = new Provider() { Name = "ПромАгрария", Addres = "Минск", Phone = "1234567" };
            Provider provider2 = new Provider() { Name = "Кофе Сервис", Addres = "Москва", Phone = "1232323" };
            Provider provider3 = new Provider() { Name = "Глобус", Addres = "Гомель", Phone = "3212121" };
            db.Providers.AddRange(new Provider[] { provider1, provider2, provider3 });
            db.SaveChanges();
            Stock stock1 = new Stock() { DateOfDelivery = "11.02.2019", Count = 100, Provider =provider1, Product =product1};
            Stock stock2 = new Stock() { DateOfDelivery = "11.02.2019", Count = 20, Provider =provider2, Product = product2 };
            Stock stock3 = new Stock() { DateOfDelivery = "11.02.2019", Count = 1000, Provider = provider1, Product = product4};
            Stock stock4 = new Stock() { DateOfDelivery = "09.02.2019", Count = 200, Provider = provider3, Product = product3 };
            Stock stock5 = new Stock() { DateOfDelivery = "09.02.2019", Count = 1, Provider = provider1, Product = product5 };
            Stock stock6 = new Stock() { DateOfDelivery = "01.02.2019", Count = 500, Provider = provider2, Product = product2 };
            Stock stock7 = new Stock() { DateOfDelivery = "01.02.2019", Count = 10, Provider = provider1, Product = product1 };
            Stock stock8 = new Stock() { DateOfDelivery = "01.02.2019", Count = 123, Provider = provider3, Product = product3 };
            Stock stock9 = new Stock() { DateOfDelivery = "23.01.2019", Count = 500, Provider = provider1, Product = product4 };
            Stock stock10 = new Stock() { DateOfDelivery = "23.01.2019", Count = 300, Provider = provider1, Product = product5 };
            Stock stock11 = new Stock() { DateOfDelivery = "11.01.2019", Count = 600, Provider = provider2, Product = product2 };
            db.Stocks.AddRange(new Stock[] { stock1, stock2, stock3, stock4, stock5, stock6, stock7, stock8, stock9, stock10, stock11 });
            db.SaveChanges();
        }
    }
}
