using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//1. Построить три класса(базовый и 2 потомка), описывающих работников с почасовой
//оплатой(один из потомков) и фиксированной оплатой(второй потомок) :
//a.Описать в базовом классе абстрактный метод для расчета среднемесячной
//заработной платы.Для «повременщиков» формула для расчета такова:
//«среднемесячная заработная плата = 20.8 * 8 * почасовая ставка»; для работников с
//фиксированной оплатой: «среднемесячная заработная плата = фиксированная
//месячная оплата»;
//b.Создать на базе абстрактного класса массив сотрудников и заполнить его;
//c. * Реализовать интерфейсы для возможности сортировки массива, используя
//Array.Sort();
//d. * Создать класс, содержащий массив сотрудников, и реализовать возможность вывода
//данных с использованием foreach .
//    Рощупкин
namespace hw2task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee[] employees = Employee.GetEmployee("Employees.txt");
            
            Console.WriteLine("\nb.Создать на базе абстрактного класса массив сотрудников и заполнить его;\n");
            foreach (var empl in employees)
            {
                Console.WriteLine(@"{0,15}{1,10}", empl.LastName, empl.AverageSalary);
            }
            Console.WriteLine("\nc. * Реализовать интерфейсы для возможности сортировки массива," +
                " используя Array.Sort();\n");
            Array.Sort(employees);
            foreach (var empl in employees)
            {
                Console.WriteLine(@"{0,15}{1,10}", empl.LastName,empl.AverageSalary);
            }
            Console.WriteLine("\nd. * Создать класс, содержащий массив сотрудников, и реализовать возможность вывода" +
                " данных с использованием foreach.\n");
            EmployeesArray employeesArray = new EmployeesArray("EmployeesArray.txt");
            foreach (var empl in employeesArray)
                Console.WriteLine(@"{0,35}", empl);
            Console.ReadLine();
        }
    }
}
