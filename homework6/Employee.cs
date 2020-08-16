using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redidHW
{
    class Employee : INotifyPropertyChanged
    {
        private string fullName;
        public string FullName
        {
            get { return fullName; }
            set
            {
                if (fullName != value)
                {
                    fullName = value;
                    NotifyPropertyChanged("FullName");
                }
            }
        }
        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        private Department department;
        public Department Department
        {
            get { return department; }
            set
            {
                if (department != value)
                {
                    department = value;
                    NotifyPropertyChanged("Department");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
