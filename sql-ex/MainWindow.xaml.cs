using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace sql_ex
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Tasks selectTasks = new Tasks();
        private DML_ComputerFirm computerFirm = new DML_ComputerFirm();

        public MainWindow()
        {
            InitializeComponent();

            using (var context = new ComputerFirmEntity.ComputerFirmContext())
            {
                context.CreateDatabase();
            }

            using (var context = new ShipsEntities.ShipsContext())
            {
                context.CreateDatabase();
            }

            using (var context = new RecyclingFirmEntity.RecyclingFirmContext())
            {
                context.CreateDatabase();
            }
        }

//#region Select
        public void Task1(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Модель", DisplayMemberBinding = new Binding("Model") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Скорость", DisplayMemberBinding = new Binding("Speed") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Жесткий диск", DisplayMemberBinding = new Binding("HD") });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task1();
        }

        public void Task2(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Производитель", DisplayMemberBinding = new Binding("Maker") });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task2();
        }

        public void Task3(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Модуль", DisplayMemberBinding = new Binding("Model") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Память", DisplayMemberBinding = new Binding("RAM") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Экран", DisplayMemberBinding = new Binding("Screen") });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task3();
        }

        public void Task4(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Код", DisplayMemberBinding = new Binding("Code") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Модель", DisplayMemberBinding = new Binding("Model") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Цвет", DisplayMemberBinding = new Binding("Color") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Тип принтера", DisplayMemberBinding = new Binding("Type") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Цена", DisplayMemberBinding = new Binding("Price") });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task4();
        }

        public void Task5(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Модель", DisplayMemberBinding = new Binding("Model") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Скорость", DisplayMemberBinding = new Binding("Speed") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Жеский диск", DisplayMemberBinding = new Binding("HD") });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task5();
        }

        public void Task6(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Производитель", DisplayMemberBinding = new Binding("Maker") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Скорость ПК-блокнота", DisplayMemberBinding = new Binding("Speed") });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task6();
        }

        public void Task7(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Модель", DisplayMemberBinding = new Binding("Model") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Цена", DisplayMemberBinding = new Binding("Price") });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task7();
        }

        public void Task8(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Производитель" });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task8();
        }

        public void Task9(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Производитель" });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task9();
        }

        public void Task10(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Модель", DisplayMemberBinding = new Binding("Model") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Цена", DisplayMemberBinding = new Binding("Price") });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task10();

        }

        public void Task11(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Средняя скорость" });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task11();
        }

        public void Task12(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Средняя скорость" });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task12();
        }

        public void Task13(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Средняя скорость" });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task13();
        }

        public void Task14(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Класс корабля", DisplayMemberBinding = new Binding("Class") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Название корабля", DisplayMemberBinding = new Binding("Name") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Страна", DisplayMemberBinding = new Binding("Country") });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task14();
        }

        public void Task15(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "HD" });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task15();
        }

        public void Task16(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Модель2", DisplayMemberBinding = new Binding("model2") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Модель1", DisplayMemberBinding = new Binding("model1") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Скорость", DisplayMemberBinding = new Binding("speed") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Память", DisplayMemberBinding = new Binding("ram") });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task16();
        }

        public void Task17(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Тип", DisplayMemberBinding = new Binding("Type") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Модель", DisplayMemberBinding = new Binding("Model") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Скорость", DisplayMemberBinding = new Binding("Speed") });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task17();
        }

        public void Task18(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Производитель", DisplayMemberBinding = new Binding("Maker") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Цена", DisplayMemberBinding = new Binding("Price") });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task18();
        }

        public void Task19(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Производитель", DisplayMemberBinding = new Binding("Maker") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Средний размер экрана", DisplayMemberBinding = new Binding("Average") });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task19();
        }

        public void Task20(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Производитель", DisplayMemberBinding = new Binding("Maker") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Количество", DisplayMemberBinding = new Binding("Count") });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task20();
        }

        public void Task21(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Производитель", DisplayMemberBinding = new Binding("Maker") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Максимальная цена", DisplayMemberBinding = new Binding("Max") });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task21();
        }

        public void Task22(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Скорость", DisplayMemberBinding = new Binding("Speed") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Средняя цена", DisplayMemberBinding = new Binding("Average") });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task22();
        }

        public void Task23(object sender, RoutedEventArgs e)
        {
            GridView gridview = new GridView();
            gridview.Columns.Add(new GridViewColumn() { Header = "Производитель" });

            lstvwQueryResult.View = gridview;
            lstvwQueryResult.ItemsSource = selectTasks.Task23();
        }

        public void Task24(object sender, RoutedEventArgs e)
        {
            GridView gridview = new GridView();
            gridview.Columns.Add(new GridViewColumn() { Header = "Производитель" });

            lstvwQueryResult.View = gridview;
            lstvwQueryResult.ItemsSource = selectTasks.Task24();
        }

        public void Task25(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Производитель" });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task25();
        }

        public void Task26(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Средняя цена" });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task26();
        }

        public void Task27(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Производитель", DisplayMemberBinding = new Binding("Maker") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Средний размер", DisplayMemberBinding = new Binding("Average") });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task27();
        }

        public void Task28(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Количество производителей" });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task28();
        }

        public void Task29(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Пункт", DisplayMemberBinding = new Binding("Point") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Дата", DisplayMemberBinding = new Binding("Date") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Приход", DisplayMemberBinding = new Binding("Inc") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Расход", DisplayMemberBinding = new Binding("Out") });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task29();
        }

        public void Task30(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Точка", DisplayMemberBinding = new Binding("Point") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Дата", DisplayMemberBinding = new Binding("Date") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Расход", DisplayMemberBinding = new Binding("SumOut") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Прибыль", DisplayMemberBinding = new Binding("SumInc") });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task30();
        }

        public void Task31(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Класс корабля", DisplayMemberBinding = new Binding("Class") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Страна", DisplayMemberBinding = new Binding("Country") });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task31();
        }

        public void Task32(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Страна", DisplayMemberBinding = new Binding("Country") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Среднее", DisplayMemberBinding = new Binding("Average") });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task32();
        }

        public void Task33(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Корабль" });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task33();
        }

        public void Task34(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Название" });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task34();
        }

        public void Task35(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Модель", DisplayMemberBinding = new Binding("Model") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Тип", DisplayMemberBinding = new Binding("Type") });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task35();
        }

        public void Task36(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Название" });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task36();
        }

        public void Task37(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Название" });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task37();
        }

        public void Task38(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Страна" });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task38();
        }

        public void Task39(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Название" });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task39();
        }

        public void Task40(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Производитель", DisplayMemberBinding = new Binding("Maker") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Тип", DisplayMemberBinding = new Binding("Type") });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task40();
        }

        public void Task41(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Производитель", DisplayMemberBinding = new Binding("Maker") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Максимум", DisplayMemberBinding = new Binding("Max") });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task41();
        }

        public void Task42(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Название", DisplayMemberBinding = new Binding("Ship") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Битва", DisplayMemberBinding = new Binding("Battle") });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task42();
        }

        public void Task43(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Название" });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task43();
        }

        public void Task44(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Название", DisplayMemberBinding = new Binding("Name") });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task44();
        }

        public void Task45(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Название" });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task45();
        }

        public void Task46(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Название", DisplayMemberBinding = new Binding("Ship") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Водоизмещение", DisplayMemberBinding = new Binding("Displacement") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Количество орудий", DisplayMemberBinding = new Binding("NumGuns") });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task46();
        }

        public void Task47(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Страна" });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task47();
        }

        public void Task48(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Класс корабля" });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task48();
        }

        public void Task49(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Название" });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task49();
        }

        public void Task50(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Название" });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task50();
        }

        public void Task51(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Название" });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task51();
        }

        public void Task52(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Название" });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task52();
        }

        public void Task53(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Среднее значение" });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task53();
        }

        public void Task54(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Среднее значение" });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task54();
        }

        public void Task55(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Класс корабля", DisplayMemberBinding = new Binding("Class") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Дата спуска", DisplayMemberBinding = new Binding("Launched") });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task55();
        }

        public void Task56(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Класс корабля", DisplayMemberBinding = new Binding("Class") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Количество", DisplayMemberBinding = new Binding("Count") });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task56();
        }

        public void Task57(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Класс", DisplayMemberBinding = new Binding("Class") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Потерянных кораблей", DisplayMemberBinding = new Binding("Count") });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task57();
        }

        public void Task58(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Производитель", DisplayMemberBinding = new Binding("Maker") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Тип модели", DisplayMemberBinding = new Binding("Type") });
            gridView.Columns.Add(new GridViewColumn() { Header = "%", DisplayMemberBinding = new Binding("Percent") });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task58();
        }

        public void Task59(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Точка", DisplayMemberBinding = new Binding("Point") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Осталось", DisplayMemberBinding = new Binding("Remainder") });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task59();
        }

        public void Task60(object sender, RoutedEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn() { Header = "Точка", DisplayMemberBinding = new Binding("Point") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Осталось", DisplayMemberBinding = new Binding("Remainder") });

            lstvwQueryResult.View = gridView;
            lstvwQueryResult.ItemsSource = selectTasks.Task60();
        }
        //#endregion

        private void OpenForm(object sender, RoutedEventArgs e)
        {
            ArrayList list = new ArrayList();
            list.AddRange(LaptopWithMaker.GetLaptopsWithMaker());
            list.AddRange(PCWithMaker.GetPCsWithMaker());
            list.AddRange(PrinterWithMaker.GetPrintersWithMaker());

            var c = new ComputerFirm.FmComputerFirm();
            c.lstbxComputerFirm.Items.Clear();
            c.lstbxComputerFirm.ItemsSource = list;
            c.Show();
        }
    }

    class LaptopWithMaker:ComputerFirmEntity.Laptop
    {
        public string Maker { get; set; }

        public LaptopWithMaker(string maker, int code, string model, short speed, short ram, float hd, double? price, byte screen)
            :base(code,model,speed,ram,hd,price,screen)
        {
            Maker = maker;
        }

        public static List<LaptopWithMaker> GetLaptopsWithMaker()
        {
            using (var context = new ComputerFirmEntity.ComputerFirmContext())
            {
                var data = context.Laptop.Include(x => x.Product)
                    .Select(x => new LaptopWithMaker(x.Product.Maker, x.Code, x.Model, x.Speed, x.RAM, x.HD, x.Price, x.Screen))
                    .ToList();
                return data;
            }
        }
    }

    class PCWithMaker : ComputerFirmEntity.PC
    {
        public string Maker { get; set; }

        public PCWithMaker(string maker, int code, string model, short speed, short ram, float hd, string cd, double? price)
            : base(code, model, speed, ram, hd, cd, price)
        {
            Maker = maker;
        }

        public static List<PCWithMaker> GetPCsWithMaker()
        {
            using (var context = new ComputerFirmEntity.ComputerFirmContext())
            {
                var data = context.PC.Include(x => x.Product)
                    .Select(x => new PCWithMaker(x.Product.Maker, x.Code, x.Model, x.Speed, x.RAM, x.HD, x.CD, x.Price))
                    .ToList();
                return data;
            }
        }
    }

    class PrinterWithMaker:ComputerFirmEntity.Printer
    {
        public string Maker { get; set; }

        public PrinterWithMaker(string maker,int code,string model,char color,string type,double? price)
            :base(code,model,color,type,price)
        {
            Maker = maker;
        }

        public static List<PrinterWithMaker> GetPrintersWithMaker()
        {
            using (var context = new ComputerFirmEntity.ComputerFirmContext())
            {
                var data = context.Printer.Include(x => x.Product)
                    .Select(x => new PrinterWithMaker(x.Product.Maker, x.Code, x.Model, x.Color,x.Type, x.Price))
                    .ToList();
                return data;
            }
        }
    }
}
