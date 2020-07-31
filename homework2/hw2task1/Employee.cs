using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2task1
{
    abstract class Employee : IComparable
    {
        protected readonly string _firstName;
        protected readonly string _lastName;
        protected double _averageSalary;

        protected Employee(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
            _averageSalary = CalcSalary();
        }

        public static Employee[] GetEmployee(string path)
        {
            string[] tempList = File.ReadAllLines(path);
            Employee[] employees = new Employee[tempList.Length];
            for (int i = 0; i < employees.Length; i++)
            {
                string[] tempEmpl = tempList[i].Split(' ');
                if (tempEmpl[0].Contains("_"))
                    employees[i] = new HourEmployee(
                        tempEmpl[0].Substring(1), tempEmpl[1], double.Parse(tempEmpl[2]));
                else
                    employees[i] = new FixEmployee(
                        tempEmpl[0], tempEmpl[1], double.Parse(tempEmpl[2]));
            }
            return employees;
        }
        public abstract double CalcSalary();

        public string LastName => _lastName;
        public double AverageSalary => _averageSalary;

        public int CompareTo(object obj)
        {
            if (_averageSalary < ((Employee)obj).AverageSalary) return -1;
            if (_averageSalary > ((Employee)obj).AverageSalary) return 1;
            return 0;
        }
    }
}
