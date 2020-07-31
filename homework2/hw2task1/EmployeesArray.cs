using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2task1
{
    class EmployeesArray : IEnumerable
    {
        readonly string _name;
        readonly int _age;
        EmployeesArray[] employees;
        public EmployeesArray(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public EmployeesArray(string path)
        {
            StreamReader sr = new StreamReader(path);
            int n = Int32.Parse(sr.ReadLine());
            employees = new EmployeesArray[n];
            for (var i = 0; i < n; i++)
            {
                string[] empl = sr.ReadLine().Split(' ');
                int age = Int32.Parse(empl[2]);
                employees[i] = new EmployeesArray(empl[0] + " " + empl[1], age);
            }
            sr.Close();
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < employees.Length; i++)
                yield return employees[i]._name + " " + employees[i]._age + " years old.";
        }
    }
}
