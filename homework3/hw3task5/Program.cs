using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//5. * Добавить в пример Lesson3 обобщенный делегат.
//    Рощупкин
namespace Delegates_Observer
{
    public delegate void MyDelegate(object o);
    class Source
    {
        public event MyDelegate Run;
        public void Start()
        {
            Console.WriteLine("RUN");
            Run?.Invoke(this);
        }
    }
    class Observer1 // Наблюдатель 1
    {
        public void Do(object o)
        {
            Console.WriteLine("Первый. Принял, что объект {0} побежал", o);
        }
        public void GetNumber(object o, int number)
        {
            Console.WriteLine($"Первый. Докладываю, что объект {o} бежит под номером {number}.");
        }
    }
    class Observer2 // Наблюдатель 2
    {
        public void Do(object o)
        {
            Console.WriteLine("Второй. Принял, что объект {0} побежал", o);
        }
        public void GetNumber(object o, int number)
        {
            Console.WriteLine($"Второй. Докладываю, что объект {o} бежит под номером {number}.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Source s = new Source();
            Observer1 o1 = new Observer1();
            Observer2 o2 = new Observer2();
            MyDelegate d1 = new MyDelegate(o1.Do);
            Action<object,int> num = o1.GetNumber;
            num(s, 5);
            s.Run += d1;
            s.Run += o2.Do;
            s.Start();
            s.Run -= d1;
            s.Start();
            Action<object, int> newNum = o2.GetNumber;
            newNum(s, 5);
            Console.ReadLine();
        }
    }
}

