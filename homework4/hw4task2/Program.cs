using System;
using System.Collections.Generic;
using System.Linq;
//2. Дана коллекция List<T>.Требуется подсчитать, сколько раз каждый элемент встречается в
//данной коллекции:
//a.для целых чисел;
//b. * для обобщенной коллекции;
//c. ** используя Linq.
//Рощупкин
namespace hw4task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\na.для целых чисел\n");
            Task_a task_A = new Task_a();
            task_A.counter = new Dictionary<int, int>();
            task_A.Count(out task_A.counter);
            task_A.Print(task_A.counter);

            Console.WriteLine("\nb. * для обобщенной коллекции;\n");
            List<bool> list = new List<bool>() { true, true, false, false, false };
            Task_b task_B = new Task_b();
            var counter = task_B.Count(list);
            task_B.Print(counter);

            Console.WriteLine("\nc. ** используя Linq.\n");
            int[] nums = { 1, -2, 3, -3, 0, -8, 12, 19, 6, 9, 10,
        1, -2, 3, -3, 2, -8, 12, 319, 6, 9, 10,
        11, -2, 3, -3, 0, -18, 12, 19, 9, 9, 101};
            Task_c Task_C = new Task_c();
            Task_C.PrintWithLinq(nums);
            Console.ReadLine();
        }
        public class Task_a
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5 , 1, 2, 3, 4, 5,
        1, 2, 3, 4, 5 , 1, 2, 3, 6,7 };
            public Dictionary<int, int> counter;
            public void Count(out Dictionary<int, int> counter)
            {
                counter = new Dictionary<int, int>();
                foreach (int num in list)
                {
                    if (!counter.ContainsKey(num))
                        counter.Add(num, 1);
                    else
                        counter[num]++;
                }
            }
            public void Print(Dictionary<int, int> keyValues)
            {
                foreach (int key in keyValues.Keys)
                    Console.Write(key + " - - " + keyValues[key] + "\n");
            }
        }
        public class Task_b
        {
            public Dictionary<T, int> Count<T>(ICollection<T> list)
            {
                Dictionary<T, int> counter = new Dictionary<T, int>();
                foreach (T val in list)
                {
                    if (!counter.ContainsKey(val))
                        counter.Add(val, 1);
                    else
                        counter[val]++;
                }
                return counter;
            }
            public void Print(IDictionary<bool, int> keyValue)
            {
                foreach (var key in keyValue.Keys)
                    Console.Write(key + " - - " + keyValue[key] + "\n");
            }
        }
        public class Task_c
        {
            Task_c[] numbersLinq;
            public Dictionary<int, int> counter;
            public int Number { get; set; }
            public int Amount { get; set; }
            public Task_c()
            {

            }
            public Task_c(int number, int amount)
            {
                Number = number;
                Amount = amount;
            }
            private Dictionary<int, int> Count(int[] nums)
            {
                counter = new Dictionary<int, int>();
                foreach (int num in nums)
                {
                    if (!counter.ContainsKey(num))
                        counter.Add(num, 1);
                    else
                        counter[num]++;
                }
                return counter;
            }
            private Task_c[] CreateLinq(Dictionary<int, int> keyValues)
            {
                Task_c[] linqArr = new Task_c[keyValues.Count];
                int[] keysArr = new int[keyValues.Count];
                keyValues.Keys.CopyTo(keysArr, 0);
                for (int i = 0; i < linqArr.Length; i++)
                    linqArr[i] = new Task_c(keysArr[i], keyValues[keysArr[i]]);
                return linqArr;
            }

            public void PrintWithLinq(int[] numsArr)
            {
                counter = Count(numsArr);
                numbersLinq = CreateLinq(counter);
                var numbers = from num in numbersLinq
                              select new { num.Number, num.Amount };
                foreach (var n in numbers)
                    Console.WriteLine("{0} - {1}", n.Number, n.Amount);
            }
        }
    }
}

