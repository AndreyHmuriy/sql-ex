using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using sql_ex.ComputerFirmEntity;
using Microsoft.EntityFrameworkCore;
using sql_ex.ShipsEntities;
using sql_ex.RecyclingFirmEntity;

namespace sql_ex
{
    class Tasks
    {
        //Найдите номер модели, скорость и размер жесткого диска для всех ПК стоимостью менее 500 дол. Вывести: model, speed и hd
        public IEnumerable Task1()
        {
            using (var context = new ComputerFirmContext())
            {
                var data = context.PC.Where(item => item.Price < 500).Select(item => new { item.Model, item.Speed, item.HD }).ToList();
                return data;
            }
        }

        //Найдите производителей принтеров. Вывести: maker
        public IEnumerable Task2()
        {
            using (var context = new ComputerFirmContext())
            {
                var data = context.Product.Where(item => item.Type == "Printer").Select(item => new { item.Maker }).Distinct().ToList();
                return data;
            }
        }

        //Найдите номер модели, объем памяти и размеры экранов ПК-блокнотов, цена которых превышает 1000 дол.
        public IEnumerable Task3()
        {
            using (var context = new ComputerFirmContext())
            {
                var data = context.Laptop.Where(item => item.Price > 1000).Select(item => new { item.Model, item.RAM, item.Screen }).ToList();
                return data;
            }
        }

        //Найдите все записи таблицы Printer для цветных принтеров.
        public IEnumerable Task4()
        {
            using (var context = new ComputerFirmContext())
            {
                var data = context.Printer.Where(item => item.Color == 'y').Select(item => item).ToList();
                return data;
            }
        }

        //Найдите номер модели, скорость и размер жесткого диска ПК, имеющих 12x или 24x CD и цену менее 600 дол.
        public IEnumerable Task5()
        {
            using (var context = new ComputerFirmContext())
            {
                var data = context.PC.Where(item => (item.CD == "12x" || item.CD == "24x") && item.Price < 600)
                    .Select(item => new { item.Model, item.Speed, item.HD })
                    .ToList();
                return data;
            }
        }

        //Для каждого производителя, выпускающего ПК-блокноты c объёмом жесткого диска не менее 10 Гбайт, найти скорости таких ПК-блокнотов. Вывод: производитель, скорость.
        public IEnumerable Task6()
        {
            using (var context = new ComputerFirmContext())
            {
                var data = context.Product.Join(context.Laptop, p => p.Model, l => l.Model, (p, l) => new { p, l })
                    .Where(item => item.p.Type == "Laptop" && item.l.HD >= 10)
                    .Select(item => new { item.p.Maker, item.l.Speed })
                    .Distinct().ToList();
                return data;
            }
        }

        //Найдите номера моделей и цены всех имеющихся в продаже продуктов (любого типа) производителя B (латинская буква).
        public IEnumerable Task7()
        {
            using (var context = new ComputerFirmContext())
            {
                var pcList = context.PC.Join(context.Product, comp => comp.Model, p => p.Model, (comp, p) => new { comp.Model, comp.Price, p.Maker, p.Type })
                    .Where(item => item.Type == "PC");
                var laptopList = context.Laptop.Join(context.Product, l => l.Model, p => p.Model, (l, p) => new { l.Model, l.Price, p.Maker, p.Type })
                    .Where(item => item.Type == "Laptop");
                var printerList = context.PC.Join(context.Product, printer => printer.Model, p => p.Model, (printer, p) => new { printer.Model, printer.Price, p.Maker, p.Type })
                    .Where(item => item.Type == "Printer");
                var data = pcList.Union(laptopList).Union(printerList).Where(item => item.Maker == "B").Select(item => new { item.Model, item.Price }).ToList();
                return data;
            }
        }

        //Найдите производителя, выпускающего ПК, но не ПК-блокноты.
        public IEnumerable Task8()
        {
            using (var context = new ComputerFirmContext())
            {
                var allPC = context.Product.Where(item => item.Type == "PC").Select(item => item.Maker);
                var allLaptop = context.Product.Where(item => item.Type == "Laptop").Select(item => item.Maker);
                var data = allPC.Except(allLaptop).ToList();
                return data;
            }
        }

        //Найдите производителей ПК с процессором не менее 450 Мгц. Вывести: Maker
        public IEnumerable Task9()
        {
            using (var context = new ComputerFirmContext())
            {
                var data = context.Product.Join(context.PC, product => product.Model, pc => pc.Model, (product, pc) => new { product.Maker, product.Type, pc.Speed })
                    .Where(item => item.Speed >= 450 && item.Type == "PC")
                    .Select(item => item.Maker)
                    .Distinct().ToList();
                return data;
            }
        }

        //Найдите модели принтеров, имеющих самую высокую цену. Вывести: model, price
        public IEnumerable Task10()
        {
            using (var context = new ComputerFirmContext())
            {
                var priceMax = context.Printer.Max(item => item.Price);
                var data = context.Printer.Where(item => item.Price == priceMax)
                    .Select(item => new { item.Model, item.Price }).ToList();
                return data;
            }
        }

        //Найдите среднюю скорость ПК.
        public IEnumerable Task11()
        {
            using (var context = new ComputerFirmContext())
            {
                double average = context.PC.Average(item => item.Speed);
                List<double> list = new List<double>() { average };
                return list;
            }
        }

        //Найдите среднюю скорость ПК-блокнотов, цена которых превышает 1000 дол.
        public IEnumerable Task12()
        {
            using (var context = new ComputerFirmContext())
            {
                double average = context.Laptop.Where(item => item.Price > 1000).Average(item => item.Speed);
                List<double> list = new List<double>() { average };
                return list;
            }
        }

        //Найдите среднюю скорость ПК, выпущенных производителем A.
        public IEnumerable Task13()
        {
            using (var context = new ComputerFirmContext())
            {
                double average = context.Product.Join(context.PC, product => product.Model, pc => pc.Model, (product, pc) => new { product.Model, product.Maker, product.Type, pc.Speed })
                    .Where(item => item.Maker == "A" && item.Type == "PC")
                    .Average(item => item.Speed);
                List<double> list = new List<double>() { average };
                return list;
            }
        }

        //Найдите класс, имя и страну для кораблей из таблицы Ships, имеющих не менее 10 орудий.
        public IEnumerable Task14()
        {
            using (var context = new ShipsEntities.ShipsContext())
            {
                var data = context.Ships.Join(context.Classes, ship => ship.Class, classes
                    => classes.Class, (ship, classes) => new { classes.Class, ship.Name, classes.Country, classes.NumGuns })
                    .Where(item => item.NumGuns >= 10)
                    .Select(item => new { item.Class, item.Name, item.Country }).ToList();
                return data;
            }
        }

        //Найдите размеры жестких дисков, совпадающих у двух и более PC. Вывести: HD
        public IEnumerable Task15()
        {
            using (var context = new ComputerFirmContext())
            {
                var data = context.PC.GroupBy(item => item.HD)
                    .Select(item => new
                    {
                        HD = item.Key,
                        Models = item.Count()
                    })
                    .Where(item => item.Models >= 2)
                    .Select(item => item.HD).ToList();
                return data.ToList();
            }
        }

        //Найдите пары моделей PC, имеющих одинаковые скорость и RAM. 
        //В результате каждая пара указывается только один раз, т.е. (i,j), но не (j,i), Порядок вывода: модель с большим номером, модель с меньшим номером, скорость и RAM.
        public IEnumerable Task16()
        {
            using (var context = new ComputerFirmContext())
            {
                var pcList = context.PC.Select(item => new { item.Model, item.Speed, item.RAM })
                    .ToList()
                    .Select(item => new { model = Convert.ToInt32(item.Model), item.Speed, item.RAM });

                var data = (from pc1 in pcList
                            from pc2 in pcList
                            where pc1.RAM == pc2.RAM && pc1.Speed == pc2.Speed && pc1.model < pc2.model
                            select new { model2 = pc2.model, model1 = pc1.model, speed = pc1.Speed, ram = pc1.RAM })
                    .Distinct();
                return data;
            }
        }

        //Найдите модели ПК-блокнотов, скорость которых меньше скорости каждого из ПК.
        //Вывести: type, model, speed
        public IEnumerable Task17()
        {
            using (var context = new ComputerFirmContext())
            {
                var data = context.Product.Join(context.Laptop, product => product.Model, laptop => laptop.Model, (product, laptop) => new { product.Type, product.Model, laptop.Speed })
                    .Where(item1 => context.PC.All(pc => pc.Speed > item1.Speed))
                    .Distinct().ToList();
                return data;
            }
        }

        //Найдите производителей самых дешевых цветных принтеров. Вывести: maker, price
        public IEnumerable Task18()
        {
            using (var context = new ComputerFirmContext())
            {
                var minPrice = context.Printer.Where(item => item.Color == 'y').Min(item => item.Price);
                var data = context.Product.Join(context.Printer, product => product.Model, printer => printer.Model, (product, printer) => new { product.Maker, printer.Price, product.Type, printer.Color })
                    .Where(item => item.Color == 'y' && item.Type == "Printer" && item.Price == minPrice)
                    .Select(item => new { item.Maker, item.Price })
                    .Distinct();
                return data.ToList();
            }
        }

        //Для каждого производителя, имеющего модели в таблице Laptop, найдите средний размер экрана выпускаемых им ПК-блокнотов.
        //Вывести: maker, средний размер экрана.
        public IEnumerable Task19()
        {
            using (var contex = new ComputerFirmContext())
            {
                var data = contex.Product.Join(contex.Laptop, product => product.Model, laptop => laptop.Model, (product, laptop) => new { product.Maker, product.Type, laptop.Screen })
                    .Where(item => item.Type == "Laptop")
                    .GroupBy(item => new { item.Maker })
                    .Select(item => new { Maker = item.Key.Maker, Average = item.Average(x => x.Screen) })
                    .ToList();
                return data;
            }
        }

        //Найдите производителей, выпускающих по меньшей мере три различных модели ПК. Вывести: Maker, число моделей ПК.
        public IEnumerable Task20()
        {
            using (var context = new ComputerFirmContext())
            {
                var data = (from product in context.Product
                            where product.Type == "PC"
                            group product by product.Maker into allPC
                            where allPC.Count() >= 3
                            select new { Maker = allPC.Key, Count = allPC.Count() }).ToList();
                return data;
            }
        }

        ////Найдите максимальную цену ПК, выпускаемых каждым производителем, у которого есть модели в таблице PC.
        ////Вывести: maker, максимальная цена.
        public IEnumerable Task21()
        {
            using (var context = new ComputerFirmContext())
            {
                var data = (from product in context.Product
                            join pc in context.PC on product.Model equals pc.Model
                            where product.Type == "PC"
                            group new { product, pc } by product.Maker into result
                            select new { Maker = result.Key, Max = result.Max(x => x.pc.Price) }).ToList();
                return data;
            }
        }

        //Для каждого значения скорости ПК, превышающего 600 МГц, определите среднюю цену ПК с такой же скоростью. Вывести: speed, средняя цена.
        public IEnumerable Task22()
        {
            using (var context = new ComputerFirmContext())
            {
                var data = context.PC.Where(item => item.Speed > 600)
                    .GroupBy(item => item.Speed)
                    .Select(item => new { Speed = item.Key, Average = item.Average(x => x.Price) }).ToList();
                return data;
            }
        }

        //Найдите производителей, которые производили бы как ПК
        //со скоростью не менее 750 МГц, так и ПК-блокноты со скоростью не менее 750 МГц.
        //Вывести: Maker
        public IEnumerable Task23()
        {
            using (var context = new ComputerFirmContext())
            {
                var data = (from product in context.Product
                            join pc in context.PC on product.Model equals pc.Model
                            where product.Type == "PC" && pc.Speed >= 750
                            select product.Maker)
                            .Intersect(
                                from product in context.Product
                                join laptop in context.Laptop on product.Model equals laptop.Model
                                where product.Type == "Laptop" && laptop.Speed >= 750
                                select product.Maker).ToList();
                return data;
            }
        }

        //Перечислите номера моделей любых типов, имеющих самую высокую цену по всей имеющейся в базе данных продукции.
        public IEnumerable Task24()
        {
            using (var context = new ComputerFirmContext())
            {
                var maxPrice = (from pc in context.PC
                                select pc.Price)
                               .Union(from laptop in context.Laptop
                                      select laptop.Price)
                               .Union(from printer in context.Printer
                                      select printer.Price)
                               .Max();
                var data = (from pc in context.PC
                            select new { pc.Model, pc.Price })
                               .Union(from laptop in context.Laptop
                                      select new { laptop.Model, laptop.Price })
                               .Union(from printer in context.Printer
                                      select new { printer.Model, printer.Price })
                               .Where(x => x.Price == maxPrice)
                               .Select(x => x.Model).ToList();
                return data;
            }
        }

        //Найдите производителей принтеров, которые производят ПК с наименьшим объемом RAM и с самым быстрым процессором среди всех ПК, имеющих наименьший объем RAM. 
        //Вывести: Maker
        public IEnumerable Task25()
        {
            using (var context = new ComputerFirmContext())
            {
                var minRam = context.PC.Min(item => item.RAM);
                var maxSpeed = context.PC.Select(item => item.Speed)
                    .Where(x => context.PC.Where(item => item.RAM == minRam)
                                          .Select(item => item.Speed)
                                          .Contains(x)).Max();
                var containtMaker = (from product in context.Product
                                     join pc in context.PC on product.Model equals pc.Model
                                     where pc.RAM == minRam && pc.Speed == maxSpeed
                                     select product.Maker);
                var data = (from product in context.Product
                            where containtMaker.Contains(product.Maker) && product.Type == "Printer"
                            select product.Maker)
                           .Distinct().ToList();
                return data;
            }
        }

        //Найдите среднюю цену ПК и ПК-блокнотов, выпущенных производителем A (латинская буква). Вывести: одна общая средняя цена.
        public IEnumerable Task26()
        {
            using (var context = new ComputerFirmContext())
            {
                var data = (from pc in context.PC
                            join product in context.Product on pc.Model equals product.Model
                            where product.Type == "PC" && product.Maker == "A"
                            select pc.Price)
                              .Concat
                              (from laptop in context.Laptop
                               join product in context.Product on laptop.Model equals product.Model
                               where product.Type == "Laptop" && product.Maker == "A"
                               select laptop.Price)
                              .Average();
                return new List<double>() { data.Value };
            }
        }

        //Найдите средний размер диска ПК каждого из тех производителей, которые выпускают и принтеры. Вывести: maker, средний размер HD.
        public IEnumerable Task27()
        {
            using (var context = new ComputerFirmContext())
            {
                var containValues = context.Product.Where(x => x.Type == "Printer")
                    .Select(x => x.Maker);
                var data = (from pc in context.PC
                            join product in context.Product on pc.Model equals product.Model
                            where product.Type == "PC" && containValues.Contains(product.Maker)
                            select new { product.Maker, pc.HD })
                            .GroupBy(item => item.Maker)
                            .Select(x => new { Maker = x.Key, Average = x.Average(item => item.HD) }).ToList();
                return data;
            }
        }

        //Используя таблицу Product, определить количество производителей, выпускающих по одной модели.
        public IEnumerable Task28()
        {
            using (var context = new ComputerFirmContext())
            {
                int data = (from product in context.Product
                            group product by product.Maker into makerGroup
                            where makerGroup.Count() == 1
                            select new { Maker = makerGroup.Key, Count = makerGroup.Count() })
                            .Count();
                return new List<int>() { data };
            }
        }

        //В предположении, что приход и расход денег на каждом пункте приема фиксируется не чаще одного раза в день[т.е.первичный ключ(пункт, дата)], 
        //написать запрос с выходными данными(пункт, дата, приход, расход). Использовать таблицы Income_o и Outcome_o.
        public IEnumerable Task29()
        {
            using (var context = new RecyclingFirmContext())
            {
                //var sqlQuery = context.Database.SqlQuery<object>("select point, date, sum(out) as Out,sum(inc) as Inc " +
                //    "from(Select code, point, date, sum(out) as out, null as inc " +
                //    "from Outcome " +
                //    "group by code, point, date " +
                //    "union " +
                //    "Select code, point, date, null as out, sum(inc) as inc " +
                //    "from Income " +
                //    "group by code, point, date) as t1 " +
                //    "group by point, date").ToList() ;

                var leftJoin = (from income_o in context.Income_o
                               join outcome_o in context.Outcome_o on new { income_o.Point, income_o.Date }
                                                                   equals new { outcome_o.Point, outcome_o.Date } into outcome_Left
                               from leftNew in outcome_Left.DefaultIfEmpty()
                               select new
                               {
                                   Income_point = (byte?)income_o.Point,
                                   Outcome_point = (byte?)leftNew.Point,
                                   Income_date = (DateTime?)income_o.Date,
                                   Outcome_date = (DateTime?)leftNew.Date,
                                   Inc = (double?)income_o.Inc,
                                   Out = (double?)null
                               });

                var rightJoin = from outcome_o in context.Outcome_o
                                join income_o in context.Income_o on new { outcome_o.Point, outcome_o.Date }
                                                                   equals new { income_o.Point, income_o.Date } into outcome_Left
                                from rigthNew in outcome_Left.DefaultIfEmpty()
                                select new
                                {
                                    Income_point = (byte?)rigthNew.Point,
                                    Outcome_point = (byte?)outcome_o.Point,
                                    Income_date = (DateTime?)rigthNew.Date,
                                    Outcome_date = (DateTime?)outcome_o.Date,
                                    Inc = (double?)null,
                                    Out = (double?)outcome_o.Out
                                };

                var fulloutjoin = leftJoin.Union(rightJoin)
                    .Select(item => new
                    {
                        Point = (item.Income_point == null) ? item.Outcome_point : item.Income_point,
                        Date = (item.Income_date ==null) ? item.Outcome_date : item.Income_date,
                        Inc = item.Inc,
                        Out = item.Out
                    })
                    .GroupBy(item => new { item.Point, item.Date })
                    .Select(item => new
                    {
                        Point = item.Key.Point,
                        Date = item.Key.Date,
                        Inc = item.Max(x => x.Inc),
                        Out = item.Max(x => x.Out)
                    })
                    .OrderBy(item => item.Point)
                    .ThenBy(item => item.Date).ToList();

                return fulloutjoin;
            }
        }

        //В предположении, что приход и расход денег на каждом пункте приема фиксируется произвольное число раз (первичным ключом в таблицах является столбец code)
        //, требуется получить таблицу, в которой каждому пункту за каждую дату выполнения операций будет соответствовать одна строка.
        //Вывод: point, date, суммарный расход пункта за день(out), суммарный приход пункта за день(inc). Отсутствующие значения считать неопределенными(NULL).
        public IEnumerable Task30()
        {
            using (var context = new RecyclingFirmContext())
            {
                var Union = (from outcome in context.Outcome
                             group outcome by new
                             {
                                 outcome.Code,
                                 outcome.Point,
                                 outcome.Date
                             } into groupOutcome
                             select new
                             {
                                 Code = groupOutcome.Key.Code,
                                 Point = groupOutcome.Key.Point,
                                 Date = groupOutcome.Key.Date,
                                 Out = groupOutcome.Sum(x => (int?)x.Out),
                                 Inc = (int?)null
                             })
                            .Union
                            (from income in context.Income
                             group income by new
                             {
                                 income.Code,
                                 income.Point,
                                 income.Date
                             } into groupIncome
                             select new
                             {
                                 Code = groupIncome.Key.Code,
                                 Point = groupIncome.Key.Point,
                                 Date = groupIncome.Key.Date,
                                 Out = (int?)null,
                                 Inc = groupIncome.Sum(x => (int?)x.Inc)
                             });
                var data = Union.GroupBy(item => new { item.Point, item.Date })
                                .Select(item => new
                                {
                                    Point = item.Key.Point,
                                    Date = item.Key.Date,
                                    SumOut = item.Sum(x => x.Out),
                                    SumInc = item.Sum(x => x.Inc)
                                }).ToList();
                return data;
            }
        }

        //Для классов кораблей, калибр орудий которых не менее 16 дюймов, укажите класс и страну.
        public IEnumerable Task31()
        {
            using (var context = new ShipsContext())
            {
                var data = context.Classes.Where(item => item.Bore >= 16)
                    .Select(x => new { x.Class, x.Country }).ToList();
                return data;
            }
        }

        //Одной из характеристик корабля является половина куба калибра его главных орудий (mw). 
        //С точностью до 2 десятичных знаков определите среднее значение mw для кораблей каждой страны, у которой есть корабли в базе данных.
        public IEnumerable Task32()
        {
            using (var context = new ShipsContext())
            {
                //var sqlQuery = context.Database.SqlQuery<ClassForTask32>("select country,cast(AVG(power(bore,3)/2.0) as Decimal(10,2)) as Average " +
                //    "from(select country, name, bore " +
                //    "from Ships left join Classes on Classes.class = Ships.class " +
                //    "union " +
                //    "select country, outcomes.ship name, bore " +
                //    "from Outcomes left join classes on Outcomes.ship = classes.class) t1 " +
                //    "where country is not null " +
                //    "group by country").ToList();
                //return sqlQuery;
                var data = (from ships in context.Ships
                            join classes in context.Classes on ships.Class equals classes.Class into joinShips
                            from leftJoin in joinShips.DefaultIfEmpty()
                            select new { Country = leftJoin.Country, Name = ships.Name, Bore = leftJoin.Bore })
                                .Union(
                                from outcomes in context.Outcomes
                                join classes in context.Classes on outcomes.Ship equals classes.Class into joinShips
                                from leftJoin in joinShips.DefaultIfEmpty()
                                select new { Country = leftJoin.Country, Name = outcomes.Ship, Bore = leftJoin.Bore })
                                .Where(item => item.Country != null).AsEnumerable()
                                .GroupBy(item => item.Country)
                                .Select(item => new
                                {
                                    Country = item.Key,
                                    Average = Math.Round(item.Average(x => Math.Pow((double)x.Bore, 3.0)) / 2.0, 2)
                                }).ToList();
                return data;
            }
        }

        //Укажите корабли, потопленные в сражениях в Северной Атлантике (North Atlantic). Вывод: ship.
        public IEnumerable Task33()
        {
            using (var context = new ShipsContext())
            {
                var data = context.Outcomes.Where(item => item.Battle == "North Atlantic" && item.Result == "sunk")
                    .Select(item => item.Ship).ToList();
                return data;
            }
        }

        //По Вашингтонскому международному договору от начала 1922 г. запрещалось строить линейные корабли водоизмещением более 35 тыс.тонн. 
        //Укажите корабли, нарушившие этот договор (учитывать только корабли c известным годом спуска на воду). Вывести названия кораблей.
        public IEnumerable Task34()
        {
            using (var context = new ShipsContext())
            {
                var data = (from ships in context.Ships
                            join classes in context.Classes on ships.Class equals classes.Class
                            where ships.Launched >= 1922 && classes.Displacement > 35000 && classes.Type == "bb"
                            select ships.Name).ToList();
                return data;
            }
        }

        //В таблице Product найти модели, которые состоят только из цифр или только из латинских букв(A-Z, без учета регистра).
        //Вывод: номер модели, тип модели.
        public IEnumerable Task35()
        {
            using (var context = new ComputerFirmContext())
            {
                var data = (from product in context.Product
                            where !EF.Functions.Like(product.Model,"%[^a-zA-Z]%")
                            || !EF.Functions.Like(product.Model,"%[^0-9]%")
                            select new { product.Model, product.Type })
                           .Distinct().ToList();
                return data;
            }
        }

        //Перечислите названия головных кораблей, имеющихся в базе данных (учесть корабли в Outcomes).
        public IEnumerable Task36()
        {
            using (var context = new ShipsContext())
            {
                var data = (from ships in context.Ships
                            join classes in context.Classes on ships.Class equals classes.Class
                            select new { classes.Class, ships.Name })
                            .Union(
                            from outcomes in context.Outcomes
                            join classes in context.Classes on outcomes.Ship equals classes.Class
                            select new { classes.Class, Name = outcomes.Ship })
                            .Where(item => item.Class == item.Name)
                            .Select(item => item.Name).ToList();
                return data;
            }
        }

        //Найдите классы, в которые входит только один корабль из базы данных(учесть также корабли в Outcomes).
        public IEnumerable Task37()
        {
            using (var context = new ShipsContext())
            {
                var data = (from ships in context.Ships
                            join classes in context.Classes on ships.Class equals classes.Class
                            select new { classes.Class, ships.Name })
                            .Union(
                            from outcomes in context.Outcomes
                            join classes in context.Classes on outcomes.Ship equals classes.Class
                            select new { classes.Class, Name = outcomes.Ship })
                            .GroupBy(item => item.Class)
                            .Select(item => new { Name = item.Key, Count = item.Count() })
                            .Where(item => item.Count == 1)
                            .Select(item => item.Name).ToList();
                return data;
            }
        }

        //Найдите страны, имевшие когда-либо классы обычных боевых кораблей ('bb') и имевшие когда-либо классы крейсеров ('bc')
        public IEnumerable Task38()
        {
            using (var context = new ShipsContext())
            {
                var data = context.Classes.Where(item => item.Type == "bb")
                    .Select(item => item.Country)
                    .Intersect(context.Classes.Where(item => item.Type == "bc")
                                              .Select(item => item.Country))
                    .ToList();
                return data;
            }
        }

        //Найдите корабли, `сохранившиеся для будущих сражений`; т.е. выведенные из строя в одной битве (damaged), они участвовали в другой, произошедшей позже.
        public IEnumerable Task39()
        {
            using (var context = new ShipsContext())
            {
                var damagedShips = (from outcomes in context.Outcomes
                                    join battles in context.Battles on outcomes.Battle equals battles.Name
                                    where outcomes.Result == "damaged"
                                    select new { outcomes.Ship, outcomes.Battle, outcomes.Result, battles.Date });
                var allShipsInOutcomes = (from outcomes in context.Outcomes
                                          join battles in context.Battles on outcomes.Battle equals battles.Name
                                          select new { outcomes.Ship, outcomes.Battle, outcomes.Result, battles.Date });
                var data = (from ds in damagedShips
                            join asio in allShipsInOutcomes on  ds.Ship.ToLower() equals asio.Ship.ToLower()
                            where ds.Date < asio.Date
                            select ds.Ship)
                            .Distinct().ToList();
                return data;
            }
        }

        //Найти производителей, которые выпускают более одной модели, при этом все выпускаемые производителем модели являются продуктами одного типа.
        //Вывести: maker, type
        public IEnumerable Task40()
        {
            //select distinct t1.maker,Product.type
            //from(select maker, count(type) as types
            //from(Select distinct maker, type
            //from Product) as temp
            //group by maker) as t1
            //join(select maker, count(model) as models
            //from Product
            //group by maker
            //having count(model) > 1) as
            //t2 on t1.maker = t2.maker
            //join Product on Product.maker = t1.maker
            //where t1.types = 1 and t2.models > 1
            using (var context = new ComputerFirmContext())
            {
                var countTypes = (from temp in context.Product.Select(item => new { item.Maker, item.Type }).Distinct().AsEnumerable()
                                  group temp by temp.Maker into grouped
                                  select new
                                  {
                                      Maker = grouped.Key,
                                      Types = grouped.Count()
                                  });
                var countModels = (from product in context.Product
                                   group product by product.Maker into grouped
                                   where grouped.Count() > 1
                                   select new
                                   {
                                       Maker = grouped.Key,
                                       Models = grouped.Count()
                                   });
                var data = (from ct in countTypes
                            join cm in countModels on ct.Maker equals cm.Maker
                            join product in context.Product on ct.Maker equals product.Maker
                            where ct.Types == 1 && cm.Models > 1
                            select new
                            {
                                Maker = ct.Maker,
                                Type = product.Type
                            })
                           .Distinct(); 
                //return countTypes;
                return data.ToList();
            }
        }

        //Для каждого производителя, у которого присутствуют модели хотя бы в одной из таблиц PC, Laptop или Printer, определить максимальную цену на его продукцию.
        //Вывод: имя производителя, если среди цен на продукцию данного производителя присутствует NULL, то выводить для этого производителя NULL, иначе максимальную цену.
        public IEnumerable Task41()
        {
            using (var context = new ComputerFirmContext())
            {
                var pcList = from pc in context.PC
                             join product in context.Product on pc.Model equals product.Model
                             where product.Type == "PC"
                             select new { pc.Model, product.Type, product.Maker, pc.Price };
                var laptopList = from laptop in context.Laptop
                                 join product in context.Product on laptop.Model equals product.Model
                                 where product.Type == "Laptop"
                                 select new { laptop.Model, product.Type, product.Maker, laptop.Price };
                var printerList = from printer in context.Printer
                                  join product in context.Product on printer.Model equals product.Model
                                  where product.Type == "Printer"
                                  select new { printer.Model, product.Type, product.Maker, printer.Price };
                var data = pcList.Union(laptopList)
                                 .Union(printerList)
                                 .GroupBy(item => item.Maker)
                                 .Select(item => new
                                 {
                                     Maker = item.Key,
                                     Max = (item.Max(x => x.Price == null ? 1 : 0) == 0) ? item.Max(x => x.Price) : null
                                 }).ToList();
                return data;
            }
        }

        //Найдите названия кораблей, потопленных в сражениях, и название сражения, в котором они были потоплены.
        public IEnumerable Task42()
        {
            using (var context = new ShipsContext())
            {
                var data = context.Outcomes.Where(item => item.Result == "sunk")
                    .Select(item => new { item.Ship, item.Battle }).ToList();
                return data;
            }
        }

        //Укажите сражения, которые произошли в годы, не совпадающие ни с одним из годов спуска кораблей на воду.
        public IEnumerable Task43()
        {
            using (var context = new ShipsContext())
            {
                var years = context.Battles.Select(item => item.Date.Year)
                                           .Distinct()
                                           .Except(context.Ships.Select(item => (int)item.Launched)
                                                                .Distinct());
                var data = context.Battles.Where(item => years.Contains(item.Date.Year))
                                          .Select(item => item.Name).ToList();
                return data;
            }
        }

        //Найдите названия всех кораблей в базе данных, начинающихся с буквы R.
        public IEnumerable Task44()
        {
            using (var context = new ShipsContext())
            {
                var data = context.Ships.Where(item => item.Name.StartsWith("R"))
                                        .Select(item => new { Name = item.Name })
                                        .Union(context.Outcomes.Where(item => item.Ship.StartsWith("R"))
                                                               .Select(item => new { Name = item.Ship })).ToList();
                return data;
            }
        }

        //Найдите названия всех кораблей в базе данных, состоящие из трех и более слов(например, King George V).
        //Считать, что слова в названиях разделяются единичными пробелами, и нет концевых пробелов.
        public IEnumerable Task45()
        {
            using (var context = new ShipsContext())
            {
                var data = context.Ships.Select(item => new { name = item.Name })
                                        .Union(context.Outcomes.Select(item => new { name = item.Ship }))
                                        .Where(item => EF.Functions.Like(item.name,"% % %"))
                                        .Select(item => item.name)
                                        .Distinct().ToList();
                return data;
            }
        }

        //Для каждого корабля, участвовавшего в сражении при Гвадалканале (Guadalcanal), вывести название, водоизмещение и число орудий.
        public IEnumerable Task46()
        {
            using (var context = new ShipsContext())
            {
                var allShipsWithStats = (from ships in context.Ships
                                         join classes in context.Classes on ships.Class equals classes.Class
                                         select new { ship = ships.Name, classes.Displacement, classes.NumGuns })
                                         .Union(
                                         from classes in context.Classes
                                         select new { ship = classes.Class, classes.Displacement, classes.NumGuns });
                var data = (from outcomes in context.Outcomes
                            join ships in allShipsWithStats on outcomes.Ship equals ships.ship into leftJoin
                            from temp in leftJoin.DefaultIfEmpty()
                            where outcomes.Battle == "Guadalcanal"
                            select new { outcomes.Ship, temp.Displacement, temp.NumGuns }).ToList();
                return data;
            }
        }



        //Определить страны, которые потеряли в сражениях все свои корабли.
        public IEnumerable Task47()
        {
            using (var context = new ShipsContext())
            {
                var sunkShips = (from outcomes in context.Outcomes
                                 join ships in context.Ships on outcomes.Ship equals ships.Name
                                 where outcomes.Result == "sunk"
                                 select new { name = ships.Name, ships.Class })
                                .Union(
                                 from outcomes in context.Outcomes
                                 join classes in context.Classes on outcomes.Ship equals classes.Class
                                 where outcomes.Result == "sunk"
                                 select new { name = outcomes.Ship, classes.Class });
                var countSunkShips = sunkShips.Join(context.Classes, x => x.Class, x => x.Class, (c, s) => new { c.name, s.Country })
                                              .GroupBy(item => item.Country)
                                              .Select(item => new { Country = item.Key, sunk = item.Count() }).AsEnumerable();

                var allShips = (from ships in context.Ships
                                select new { Name = ships.Name, ships.Class })
                                .Union(
                                 from outcomes in context.Outcomes
                                 join classes in context.Classes on outcomes.Ship equals classes.Class
                                 select new { Name = outcomes.Ship, classes.Class });
                var countAllshipsInCountry = allShips.Join(context.Classes, x => x.Class, x => x.Class, (c, s) => new { c.Name, s.Country })
                                              .GroupBy(item => item.Country)
                                              .Select(item => new { Country = item.Key, count = item.Count() });

                var data = countSunkShips.Join(countAllshipsInCountry, x => x.Country, x => x.Country, (c1, c2) => new { c1.Country, c1.sunk, c2.count })
                                         .Where(item => item.count - item.sunk == 0)
                                         .Select(item => item.Country).ToList();
                return data;
            }
        }

        //Найдите классы кораблей, в которых хотя бы один корабль был потоплен в сражении.
        public IEnumerable Task48()
        {
            using (var context = new ShipsContext())
            {
                var data = (from outcomes in context.Outcomes
                            join ships in context.Ships on outcomes.Ship equals ships.Name
                            where outcomes.Result == "sunk"
                            select new { ships.Class })
                            .Union(
                            from outcomes in context.Outcomes
                            join classes in context.Classes on outcomes.Ship equals classes.Class
                            where outcomes.Result == "sunk"
                            select new { classes.Class })
                            .Select(item => item.Class)
                           .ToList();
                return data;
            }
        }

        //Найдите названия кораблей с орудиями калибра 16 дюймов (учесть корабли из таблицы Outcomes).
        public IEnumerable Task49()
        {
            using (var context = new ShipsContext())
            {
                var allships = (from outcomes in context.Outcomes
                                join ships in context.Ships on outcomes.Ship equals ships.Name
                                select new { name = outcomes.Ship, ships.Class })
                                .Union(
                                from outcomes in context.Outcomes
                                join classes in context.Classes on outcomes.Ship equals classes.Class
                                select new { name = outcomes.Ship, classes.Class })
                                .Union(
                                from ships in context.Ships
                                select new { name = ships.Name, ships.Class });
                var data = allships.Join(context.Classes, x => x.Class, x => x.Class, (a, c) => new {Name = a.name, c.Bore })
                    .Where(item => item.Bore == 16)
                    .Select(item => item.Name).ToList();
                return data;
            }
        }

        //Найдите сражения, в которых участвовали корабли класса Kongo из таблицы Ships.
        public IEnumerable Task50()
        {
            using (var context = new ShipsContext())
            {
                var data = context.Ships.Join(context.Outcomes, x => x.Name, x => x.Ship, (s, o) => new { o.Battle, s.Class })
                                        .Where(item => item.Class == "Kongo")
                                        .Select(item => item.Battle)
                                        .Distinct().ToList();
                return data;
            }
        }

        //Найдите названия кораблей, имеющих наибольшее число орудий среди всех имеющихся кораблей такого же водоизмещения (учесть корабли из таблицы Outcomes).
        public IEnumerable Task51()
        {
            using (var context = new ShipsContext())
            {
                var allShips = (from ships in context.Ships
                                join classes in context.Classes on ships.Class equals classes.Class
                                select new { ships.Name, classes.NumGuns, classes.Displacement })
                               .Union(
                                from outcomes in context.Outcomes
                                join classes in context.Classes on outcomes.Ship equals classes.Class
                                select new { Name = outcomes.Ship, classes.NumGuns, classes.Displacement });
                var maxNumGuns = (from ships in context.Ships
                                  join classes in context.Classes on ships.Class equals classes.Class
                                  select new { classes.NumGuns, classes.Displacement })
                                  .Union(
                                  from outcomes in context.Outcomes
                                  join classes in context.Classes on outcomes.Ship equals classes.Class
                                  select new { classes.NumGuns, classes.Displacement })
                                  .GroupBy(item => item.Displacement)
                                  .Select(item => new { Max = item.Max(x=>x.NumGuns), Displacement = item.Key });
                var data = allShips.Join(maxNumGuns, x => new { t1 = x.NumGuns, t2 = x.Displacement }
                                                   , y => new { t1 = y.Max, t2 = y.Displacement }
                                                   , (a, m) => a.Name).ToList();
                return data;
            }
        }

        //Определить названия всех кораблей из таблицы Ships, которые могут быть линейным японским кораблем, 
        //имеющим число главных орудий не менее девяти, калибр орудий менее 19 дюймов и водоизмещение не более 65 тыс.тонн
        public IEnumerable Task52()
        {
            using (var context = new ShipsContext())
            {
                var data = context.Ships.Join(context.Classes, x => x.Class, x => x.Class, (ships, classes) => new { ships, classes })
                                        .Where(x => x.classes.Country == "Japan"
                                                    && (x.classes.NumGuns >= 9 || x.classes.NumGuns == null)
                                                    && (x.classes.Bore < 19 || x.classes.Bore == null)
                                                    && (x.classes.Displacement <= 65000 || x.classes.Displacement == null)
                                                    && x.classes.Type == "bb")
                                        .Select(item => item.ships.Name).ToList();
                return data;
            }
        }

        //Определите среднее число орудий для классов линейных кораблей.
        //Получить результат с точностью до 2-х десятичных знаков.
        public IEnumerable Task53()
        {
            using (var context = new ShipsContext())
            {
                var data = context.Classes.Where(item => item.Type == "bb")
                                          .Select(item => (double?)item.NumGuns).ToList();
                return new List<double?> { Math.Round(data.Average().Value, 2) };
            }
        }

        //С точностью до 2-х десятичных знаков определите среднее число орудий всех линейных кораблей (учесть корабли из таблицы Outcomes).
        public IEnumerable Task54()
        {
            using (var context = new ShipsContext())
            {
                var allShips = (from ships in context.Ships
                                join classes in context.Classes on ships.Class equals classes.Class
                                where classes.Type == "bb"
                                select new { ships.Name, classes.NumGuns, classes.Class })
                               .Union(
                                from outcomes in context.Outcomes
                                join classes in context.Classes on outcomes.Ship equals classes.Class
                                where classes.Type == "bb"
                                select new { Name = outcomes.Ship, classes.NumGuns, classes.Class });
                var data = Math.Round(allShips.Average(item => (double)item.NumGuns), 2, MidpointRounding.AwayFromZero);
                return new List<double>() { data };
            }
        }

        //Для каждого класса определите год, когда был спущен на воду первый корабль этого класса. 
        //Если год спуска на воду головного корабля неизвестен, определите минимальный год спуска на воду кораблей этого класса. Вывести: класс, год.
        public IEnumerable Task55()
        {
            using (var context = new ShipsContext())
            {
                var allDates = context.Classes.Join(
                                                    context.Ships, ships => ships.Class, classes => classes.Class, (classes, ships) => new
                                                    {
                                                        ships.Class,
                                                        ships.Launched
                                                    })
                                              .GroupBy(item => item.Class)
                                              .Select(item => new
                                              {
                                                  Class = item.Key,
                                                  Launched = item.Min(x => x.Launched)
                                              });
                var data = context.Classes.GroupJoin(
                   allDates,
                   x => x.Class,
                   y => y.Class,
                   (x1, x2) => new
                   {
                       classes = x1,
                       allDates = x2
                   })
                   .SelectMany(x => x.allDates.DefaultIfEmpty(), (x, y) => new { Class = x.classes.Class, Launched = y.Launched });
                return data.ToList();
            }
        }

        //Для каждого класса определите число кораблей этого класса, потопленных в сражениях. Вывести: класс и число потопленных кораблей.
        public IEnumerable Task56()
        {
            using (var context = new ShipsContext())
            {
                var allShips = (from ships in context.Ships
                                join outcomes in context.Outcomes on ships.Name equals outcomes.Ship
                                where outcomes.Result == "sunk"
                                select new { outcomes.Ship, ships.Class })
                               .Union(
                                from outcomes in context.Outcomes
                                join classes in context.Classes on outcomes.Ship equals classes.Class
                                where outcomes.Result == "sunk"
                                select new { outcomes.Ship, classes.Class })
                                .GroupBy(x => x.Class)
                                .Select(x => new { Class = x.Key, Count = x.Count() });
                var data = context.Classes.GroupJoin(allShips, c => c.Class, a => a.Class, (c, a) => new { c.Class, Count = a })
                                          .SelectMany(x => x.Count.DefaultIfEmpty(),
                                                      (x, y) => new
                                                      {
                                                          Class = x.Class,
                                                          Count = y.Count
                                                      }).ToList();
                return data;
            }
        }

        //Для классов, имеющих потери в виде потопленных кораблей и не менее 3 кораблей в базе данных, вывести имя класса и число потопленных кораблей.
        public IEnumerable Task57()
        {
            using (var context = new ShipsContext())
            {
                var classWithMore3Ship = context.Ships.Select(item => new { name = item.Name, @class = item.Class })
                                                     .Union(context.Outcomes.Select(item => new { name = item.Ship, @class = item.Ship }))
                                                     .GroupBy(item => item.@class)
                                                     .Where(item => item.Count() >= 3)
                                                     .Select(item => item.Key);
                var countSunkShips = context.Ships.Join(context.Outcomes, x => x.Name, y => y.Ship, (x, y) => new { x.Name, x.Class, y.Result })
                                                  .Where(item => item.Result == "sunk")
                                                  .Select(item => new { item.Name, item.Class })
                                                  .Union(context.Outcomes.Join(context.Classes, x => x.Ship, y => y.Class, (x, y) => new { Name = x.Ship, y.Class, x.Result })
                                                                         .Where(item => item.Result == "sunk")
                                                                         .Select(item => new { item.Name, item.Class }))
                                                  .GroupBy(item => item.Class)
                                                  .Select(item => new { Class = item.Key, Count = item.Count() });
                var data = classWithMore3Ship.Join(countSunkShips, x => x, y => y.Class, (x, y) => new { Class = x, y.Count }).ToList();
                return data;
            }
        }

        //Для каждого типа продукции и каждого производителя из таблицы Product c точностью до двух десятичных знаков 
        //найти процентное отношение числа моделей данного типа данного производителя к общему числу моделей этого производителя.
        //Вывод: maker, type, процентное отношение числа моделей данного типа к общему числу моделей производителя
        public IEnumerable Task58()
        {
            using (var context = new ComputerFirmContext())
            {
                //Все производители со всеми типами
                var allMakerWithTypes = (from Maker in context.Product.Select(item => item.Maker).Distinct()
                                        from Type in context.Product.Select(item => item.Type).Distinct()
                                        select new { Maker, Type }).AsEnumerable();

                //Количество моделей у каждого производителя по типам
                var countModel = context.Product.GroupBy(item => new { item.Maker, item.Type })
                                                .Select(item => new { item.Key.Maker, item.Key.Type, Count = item.Count() });

                //Связка производителей, всех типов и количества моделей
                var allTypesWithCount = allMakerWithTypes.ToList().GroupJoin(countModel,
                                                                    x => new { x.Maker, x.Type },
                                                                    y => new { y.Maker, y.Type },
                                                                    (x, y) => new { x.Maker, x.Type, count = y.Select(z => z.Count) })
                                                         .SelectMany(x => x.count.DefaultIfEmpty(), (x, y) => new { x.Maker, x.Type, Count = y });
                var result = from table1 in allTypesWithCount
                             join sumModels in context.Product.GroupBy(item => item.Maker)
                                                              .Select(item => new { Maker = item.Key, Sum = item.Count() })
                                                    on table1.Maker equals sumModels.Maker
                             select new { table1.Maker, table1.Type, Percent =  Math.Round(table1.Count / (sumModels.Sum / 100.00), 2) };

                return result.ToList();
            }
        }

        //Посчитать остаток денежных средств на каждом пункте приема для базы данных с отчетностью не чаще одного раза в день. Вывод: пункт, остаток.
        public IEnumerable Task59()
        {
            using (var context = new RecyclingFirmContext())
            {
                var result = from sumInc in context.Income_o.GroupBy(item => item.Point)
                                                             .Select(item => new { Point = item.Key, Inc = item.Sum(x => x.Inc) })
                             join sumOut in context.Outcome_o.GroupBy(item => item.Point)
                                                             .Select(item => new { Point = item.Key, Out = item.Sum(x => x.Out) })
                                on sumInc.Point equals sumOut.Point into joinTable
                             from joined in joinTable.DefaultIfEmpty()
                             select new { sumInc.Point, Remainder = sumInc.Inc - joined.Out };
                return result.ToList();
            }
        }

        //Посчитать остаток денежных средств на начало дня 15/04/01 на каждом пункте приема для базы данных с отчетностью не чаще одного раза в день. Вывод: пункт, остаток.
        //Замечание. Не учитывать пункты, информации о которых нет до указанной даты.
        public IEnumerable Task60()
        {
            using (var context = new RecyclingFirmContext())
            {
                var result = from sumInc in context.Income_o.Where(item => item.Date <= new DateTime(2001, 04, 15))
                                                            .GroupBy(item => item.Point)
                                                            .Select(item => new { Point = item.Key, Inc = item.Sum(x => x.Inc) })
                             join sumOut in context.Outcome_o.Where(item => item.Date <= new DateTime(2001, 04, 15))
                                                             .GroupBy(item => item.Point)
                                                             .Select(item => new { Point = item.Key, Out = item.Sum(x => x.Out) })
                                on sumInc.Point equals sumOut.Point into joinTable
                             from joined in joinTable.DefaultIfEmpty()
                             select new { sumInc.Point, Remainder = sumInc.Inc - joined.Out };
                return result.ToList();
            }
        }
    }

    class ClassForTask29
    {

        public byte Point { get; set; }
        public DateTime Date { get; set; }
        public Decimal? Out { get; set; }
        public Decimal? Inc { get; set; }
    }

    class ClassForTask32
    {
        public string Country { get; set; }
        public decimal Average { get; set; }
    }
}