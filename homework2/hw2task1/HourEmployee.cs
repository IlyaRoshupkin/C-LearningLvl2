using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2task1
{
    class HourEmployee : Employee
    {
        double hourlyRate;
        public double HourlyRate
        {
            get { return hourlyRate; }
            set { hourlyRate = value; }
        }
        public HourEmployee(string firstName, string lastName,double hourlyRate) : base(firstName, lastName)
        {
            HourlyRate = hourlyRate;
            _averageSalary = CalcSalary();
        }
        public override double CalcSalary()
        {
           return Math.Round(20.8f * 8 * hourlyRate,2);
        }
    }
}
