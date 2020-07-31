using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2task1
{
    class FixEmployee : Employee
    {
        double salary;
        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        public FixEmployee(string firstName, string lastName,double salary) : base(firstName, lastName)
        {
            Salary = salary;
            _averageSalary = CalcSalary();
        }

        public override double CalcSalary()
        {
            return salary;
        }
    }
}
