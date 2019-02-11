using System;
using System.Linq;
using System.Collections.Generic;
using lab1.Data;
using static System.Console;

namespace lab1
{
    class Program
    {
        static StockContext db = new StockContext();
        static void Main(string[] args)
        {
            DbInitializer.Initialize(db);
            WriteLine("1.	Выборку всех данных из таблицы, стоящей в схеме базы данных нас стороне отношения «один»\n");
            WriteLine("Товары: ");
            var products = db.Products.ToList();
            foreach (Product product in products)
                WriteLine($"Название: {product.Name} Производитель: {product.Manufacturer} Упаковка: {product.Packaging}");

            WriteLine("\n2.	Выборку данных из таблицы, стоящей в схеме базы данных нас стороне отношения «один», отфильтрованные по определенному условию, налагающему ограничения на одно или несколько полей\n");
            WriteLine("Товары,отфильтрованные по произвдителю 'Колхоз Заря'");
            products = db.Products.Where(p => p.Manufacturer == "Колхоз Заря").ToList();
            foreach (Product product in products)
                WriteLine($"Название: {product.Name} Производитель: {product.Manufacturer} Упаковка: {product.Packaging}");

            WriteLine("\n3.	Выборку данных, сгруппированных по любому из полей данных с выводом какого-либо итогового результата (min, max, avg, сount или др.) по выбранному полю из таблицы, стоящей в схеме базы данных нас стороне отношения «многие»\n");
            Write("кол-во поставок за 01.02.2019 : ");
            WriteLine(db.Stocks.Where(p => p.DateOfDelivery == "01.02.2019").Count());

            WriteLine("\n4.	Выборку данных из двух полей двух таблиц, связанных между собой отношением «один-ко-многим» \n");
            WriteLine("Поставки продуктов: ");
            var list1=db.Products.Join(db.Stocks, p => p.Id, c => c.ProductId, (p, c) => new { Date = c.DateOfDelivery, c.Count, ProductName = p.Name, Packaging = p.Packaging });
            foreach (var item in list1)
                WriteLine($"Дата: {item.Date} Кол-во: {item.Count} Товар: {item.ProductName} Упаковка: {item.Packaging} ");

            WriteLine("\n5.	Выборку данных из двух таблиц, связанных между собой отношением «один-ко-многим» и отфильтрованным по некоторому условию, налагающему ограничения на значения одного или нескольких полей \n");
            WriteLine("Поставки продуктов за 01.02.2019 :");
            list1 = db.Products.Join(db.Stocks, p => p.Id, c => c.ProductId, (p, c) => new { Date = c.DateOfDelivery, c.Count, ProductName = p.Name, Packaging = p.Packaging }).Where(p=>p.Date=="01.02.2019");
            foreach (var item in list1)
                WriteLine($"Дата: {item.Date} Кол-во: {item.Count} Товар: {item.ProductName} Упаковка: {item.Packaging} ");

            WriteLine("\n 6 и 8.	Вставка и удаление данных в таблицы, стоящей на стороне отношения «Один>\n");
            WriteLine("до добавления продуктов");
            products = db.Products.ToList();
            foreach (Product product in products)
                WriteLine($"Название: {product.Name} Производитель: {product.Manufacturer} Упаковка: {product.Packaging}");
            WriteLine("после добавления продуктов");
            Product prod = new Product() { Name = "Тестовый продукт", Manufacturer = "1", Packaging = "1" };
            db.Products.Add(prod);
            db.SaveChanges();
            products = db.Products.ToList();
            foreach (Product product in products)
                WriteLine($"Название: {product.Name} Производитель: {product.Manufacturer} Упаковка: {product.Packaging}");
            WriteLine("после удаления продуктов");
            db.Products.Remove(prod);
            db.SaveChanges();
            products = db.Products.ToList();
            foreach (Product product in products)
                WriteLine($"Название: {product.Name} Производитель: {product.Manufacturer} Упаковка: {product.Packaging}");

            WriteLine("\n7 и 9.	Вставку и удаление данных в таблицы, стоящей на стороне отношения «Многие» \n");
            WriteLine("до добавления поставки: ");
            var stocks = db.Stocks.ToList();
            foreach (Stock stock in stocks)
                WriteLine($"Id: {stock.Id} id товара: {stock.ProductId} id поставщика: {stock.ProviderId} дата: {stock.DateOfDelivery}");
            Stock st = new Stock() { DateOfDelivery = "01.01.2000", ProviderId = 1, ProductId = 1 };
            db.Stocks.Add(st);
            db.SaveChanges();
            WriteLine("после добавления поставки: ");
            stocks = db.Stocks.ToList();
            foreach (Stock stock in stocks)
                WriteLine($"Id: {stock.Id} id товара: {stock.ProductId} id поставщика: {stock.ProviderId} дата: {stock.DateOfDelivery}");
            db.Stocks.Remove(st);
            db.SaveChanges();
            WriteLine("после удаления поставки: ");
            stocks = db.Stocks.ToList();
            foreach (Stock stock in stocks)
                WriteLine($"Id: {stock.Id} id товара: {stock.ProductId} id поставщика: {stock.ProviderId} дата: {stock.DateOfDelivery}");

            WriteLine("\n10.	Обновление удовлетворяющих определенному условию записей в любой из таблиц базы данных\n");
            WriteLine("поставки до обновления");
            stocks = db.Stocks.ToList();
            foreach (Stock stock in stocks)
                WriteLine($"Id: {stock.Id} id товара: {stock.ProductId} кол-во: {stock.Count} дата: {stock.DateOfDelivery}");
            stocks = db.Stocks.Where(p => p.Count < 100).ToList();
            foreach (Stock stock in stocks)
                stock.Count = 77;
            db.SaveChanges();
            WriteLine("поставки после обновления");
            stocks = db.Stocks.ToList();
            foreach (Stock stock in stocks)
                WriteLine($"Id: {stock.Id} id товара: {stock.ProductId} кол-во: {stock.Count} дата: {stock.DateOfDelivery}");
            ReadKey();
        }
    }
}
