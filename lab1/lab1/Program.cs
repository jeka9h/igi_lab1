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

            WriteLine("1.	Выборка всех данных из таблицы, стоящей в схеме базы данных нас стороне отношения «один»");
            List<Discount> discounts = db.Discounts.ToList();
            WriteLine("Скидки:");
            foreach (Discount d in discounts)
                WriteLine($"id : {d.Id} Скидка : {d.Rebate}%");

            WriteLine("\n2.	Выборку данных из таблицы, стоящей в схеме базы данных нас стороне отношения «один», отфильтрованные по определенному условию, налагающему ограничения на одно или несколько полей");
            discounts = db.Discounts.Where(p=>p.Rebate<15).ToList();
            WriteLine("Скидки меньше 15%: ");
            foreach (Discount d in discounts)
                WriteLine($"id : {d.Id} Скидка : {d.Rebate}%");

            WriteLine("\n3.	Выборку данных, сгруппированных по любому из полей данных с выводом какого-либо итогового результата (min, max, avg, сount или др.) по выбранному полю из таблицы, стоящей в схеме базы данных нас стороне отношения «многие»");
            Write("Кол-во Продуктов производителя 'Колхоз Заря' : ");
            WriteLine(db.Products.Where(p => p.Manufacturer == "Колхоз Заря").Count());

            WriteLine("\n4.	Выборку данных из двух полей двух таблиц, связанных между собой отношением «один-ко-многим» ");
            WriteLine("Товары со скидкой: ");
            var list = db.Discounts.Join(db.Products, p => p.ProductId, c => c.Id, (p, c) => new { Name = c.Name, Rebate = p.Rebate });
            foreach (var p in list)
                WriteLine($"Продукт: {p.Name} Скидка: {p.Rebate}%");

            WriteLine("\n5.	Выборку данных из двух таблиц, связанных между собой отношением «один-ко-многим» и отфильтрованным по некоторому условию, налагающему ограничения на значения одного или нескольких полей ");
            WriteLine("Товары со скидкой меньше 15%");
            list = db.Discounts.Join(db.Products, p => p.ProductId, c => c.Id, (p, c) => new { Name = c.Name, Rebate = p.Rebate }).Where(p=>p.Rebate<15);
            foreach (var p in list)
                WriteLine($"Продукт: {p.Name} Скидка: {p.Rebate}%");

            WriteLine("6 и 8.	Вставка и удаление данных в таблицы, стоящей на стороне отношения «Один»");
            discounts = db.Discounts.ToList();
            WriteLine("Скидки до вставки:");
            foreach (Discount d in discounts)
                WriteLine($"id : {d.Id} Скидка : {d.Rebate}%");
            Product product = db.Products.Where(p => p.Name == "чай").First();
            Discount discount = new Discount() { Rebate = 70, ProductId = product.Id };
            db.Discounts.Add(discount);
            db.SaveChanges();
            discounts = db.Discounts.ToList();
            WriteLine("Скидки после вставки:");
            foreach (Discount d in discounts)
                WriteLine($"id : {d.Id} Скидка : {d.Rebate}%");
            db.Discounts.Remove(discount);
            db.SaveChanges();
            WriteLine("Скидки удаления:");
            discounts = db.Discounts.ToList();
            foreach (Discount d in discounts)
                WriteLine($"id : {d.Id} Скидка : {d.Rebate}%");

            WriteLine("7 и 9.	Вставка и удаление данных в таблицы, стоящей на стороне отношения «Многие»");
            WriteLine("Продукты до вставки: ");
            var products = db.Products.ToList();
            foreach (Product prod in products)
                WriteLine($"Название: {prod.Name} Id: {prod.Id}");
            Stock stock = db.Stocks.First();
            product = new Product() { Name = "тестовое продукт", Stock = stock, Manufacturer = "Тестовый производитель" };
            db.Products.Add(product);
            db.SaveChanges();
            WriteLine("Продукты после вставки: ");
            products = db.Products.ToList();
            foreach (Product prod in products)
                WriteLine($"Название: {prod.Name} Id: {prod.Id}");
            db.Products.Remove(product);
            db.SaveChanges();
            WriteLine("Продукты после удаления: ");
            products = db.Products.ToList();
            foreach (Product prod in products)
                WriteLine($"Название: {prod.Name} Id: {prod.Id}");

            WriteLine("10.	Обновление удовлетворяющих определенному условию записей в любой из таблиц базы данных ");
            WriteLine("Скидки до обновления: ");
            discounts = db.Discounts.ToList();
            foreach (Discount d in discounts)
                WriteLine($"Id: {d.Id} Скидка: {d.Rebate}");
            discounts = db.Discounts.Where(p => p.Rebate < 10).ToList();
            foreach (Discount d in discounts)
                d.Rebate = 7;
            db.SaveChanges();
            WriteLine("Скидки после обновления: ");
            discounts = db.Discounts.ToList();
            foreach (Discount d in discounts)
                WriteLine($"Id: {d.Id} Скидка: {d.Rebate}");
            ReadKey();

        }
    }
}
