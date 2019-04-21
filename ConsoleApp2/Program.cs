using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    abstract class ПрограммныйПродукт
    {
        public string name; //Название
        public int year;//Год
        public virtual void Input()
        {
            string s;
            do
            {
            link1:
                Console.Write("Введите название программы ");
                string l;
                try
                {
                    s = Console.ReadLine();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Некорректное значение!");
                    goto link1;
                }
            }
            while (false);
            do
            {
            link2:
                Console.Write("Введите год издания программы ");
                int l1;
                try
                {
                    s = int.Parse(Console.ReadLine()).ToString();
                    if (int.TryParse(s, out l1)) ;
                    { this.year = l1; }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Некорректное значение!");
                    goto link2;
                }
                try
                {
                    if (l1 <= 0)
                        throw new ArgumentException("Некорректное значение!");
                    else { this.year = l1; }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    goto link2;
                }
            }
            while (false);
        }
    }
    class Архиватор : ПрограммныйПродукт
    {
        protected int zip;
        public override void Input()
        {
            base.Input();
            string s;
            do
            {
            link4:
                Console.Write("Введите количество сжимаемых данных : ");
                int num;
                try
                {
                    s = Int32.Parse(Console.ReadLine()).ToString();
                    if (Int32.TryParse(s, out num)) ;
                    { this.zip = num; }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Некорректное значение!");
                    goto link4;
                }
                try
                {
                    if (num <= 0)
                        throw new ArgumentException("Некорректное значение!");
                    else { this.zip = num; }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    goto link4;
                }
            } while (false);
        }
        public override bool Equals(object r)
        {
            Архиватор z = (Архиватор)r;
            if (z.name == this.name && z.year == this.year
            && z.zip == this.zip)
            { return true; }
            else return false;
        }
        public override int GetHashCode()
        { return name.GetHashCode(); }
    }
    class СредаПрограммирования : ПрограммныйПродукт
    {
        string type;
        public override void Input()
        {
            base.Input();
            Console.Write("Введите основную среду : ");
            this.type = Console.ReadLine();
        }
        public override bool Equals(object r)
        {
            СредаПрограммирования z = (СредаПрограммирования)r;
            if (z.name == this.name && z.year == this.year
            && z.type == this.type)
            { return true; }
            else return false;
        }
        public override int GetHashCode()
        { return name.GetHashCode(); }
    }
    class ТекстовыйРедактор : ПрограммныйПродукт
    {
        string type;
        public override void Input()
        {
            base.Input();
            Console.Write("Введите тип сохраняемого файла: ");
            this.type = Console.ReadLine();
        }
        public override bool Equals(object r)
        {
            ТекстовыйРедактор z = (ТекстовыйРедактор)r;
            if (z.name == this.name && z.year == this.year
            && z.type == this.type)
            { return true; }
            else return false;
        }
        public override int GetHashCode()
        { return name.GetHashCode(); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите N = ");
            int N = int.Parse(Console.ReadLine());
            ПрограммныйПродукт[] R = new ПрограммныйПродукт[N];
            int[] n = new int[N];
            for (int i = 0; i < N; i++)
            {
            link5: Console.WriteLine("Выбирите тип программного продукта: " + (i + 1) + " : \n\t1.Архиватор\n\t2.Среда программировани\n\t3.Текстовый редакто\n");
                int x = int.Parse(Console.ReadLine());
                switch (x)
                {
                    case 1:
                        R[i] = new Архиватор();
                        Console.WriteLine("Введите данные о архиваторе " + (i + 1) + " :");
                        R[i].Input();
                        n[i] = 1;
                        break;
                    case 2:
                        R[i] = new СредаПрограммирования();
                        Console.WriteLine("Введите данные о среде прог.  " + (i + 1) + " :");
                        R[i].Input();
                        n[i] = 2;
                        break;
                    case 3:
                        R[i] = new ТекстовыйРедактор();
                        Console.WriteLine("Введите данные о корвете " + (i + 1) + " :");
                        R[i].Input();
                        n[i] = 3;
                        break;
                    default:
                        Console.WriteLine("Некорректное значение!");
                        goto link5;
                }
            }
            for (; ; )
            {
                Console.WriteLine("Сравнение объектов");
                Console.WriteLine("Введите номера объектов одного типа для сравнения :\n");
                Console.WriteLine("Введите первый объект :\n");
                int i1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите второй объект :\n");
                int i2 = int.Parse(Console.ReadLine());
                if (n[i1 - 1] == n[i2 - 1])
                {
                    if (R[i1 - 1].Equals(R[i2 - 1]) == true)
                    { Console.WriteLine("Объекты равны"); }
                    else
                    { Console.WriteLine("Объекты не равны"); }
                    break;
                }
                else
                {
                    Console.WriteLine("Различные типы объектов, сравнение невозможно!");
                }
            }
            Console.ReadKey();
        }
            
    }
}
