using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redidHW
{
    public class Department : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name; }
            set 
            { 
            if(value != name)
                {
                    name = value;
                    INotifyPropertyChanged("Name");
                }
            }
        }

        public void INotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
