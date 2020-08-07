using System;
using System.Collections.Generic;
using System.Linq;
//3. * Дан фрагмент программы:
//Dictionary<string, int> dict = new Dictionary<string, int>()
//{
//{ "four" , 4 },
//{ "two" , 2 },
//{ "one" , 1 },
//{ "three" , 3 },
//};
//var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) {
//    return pair.Value;
//});
//foreach (var pair in d)
//{
//Console.WriteLine( "{0} - {1}" , pair.Key , pair.Value );
//}
//а.Свернуть обращение к OrderBy с использованием лямбда-выражения =>.
//b. * Развернуть обращение к OrderBy с использованием делегата.
//Рощупкин
namespace hw4task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nа.Свернуть обращение к OrderBy с использованием лямбда-выражения =>.\n");
            Task_a.Solution();
            
            Console.WriteLine("\nb. * Развернуть обращение к OrderBy с использованием делегата.\n");
            Task_b.Solution();
            Console.ReadLine();
        }

    public static class Task_a
    {
        public static void Solution()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
            { "four" , 4 },
            { "two" , 2 },
            { "one" , 1 },
            { "three" , 3 },
            };
            var d = dict.OrderBy((pair) => { return pair.Value; });
            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
        }
    }

    public static class Task_b
    {
            public static void Solution()
            {
                Func<KeyValuePair<string, int>, int> myDelegate = myFunc;

                Dictionary<string, int> dict = new Dictionary<string, int>()
            {
            { "four" , 4 },
            { "two" , 2 },
            { "one" , 1 },
            { "three" , 3 },
            };
                var d = dict.OrderBy(myDelegate);

                foreach (var pair in d)
                {
                    Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
                }
                Console.ReadLine();
            }

            private static int myFunc(KeyValuePair<string, int> arg)
            {
                return arg.Value;
            }
        }
    }
}
