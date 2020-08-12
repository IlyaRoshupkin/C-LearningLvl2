using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace homework5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DepartmentsWindow dep;
        Add add;
        public class Employee
        {
            public string Name { get; set; }
            public string Position { get; set; }
            public string Department { get; set; }
        }
        public void LoadEmployees(string path)
        {
            StreamReader str = new StreamReader(path);
            int amount = int.Parse(str.ReadLine());
            for (int i = 0; i < amount; i++)
            {
                string[] employeeString = str.ReadLine().Split(':');
                Employee employee = new Employee()
                {
                    Name = employeeString[0],
                    Position = employeeString[1],
                    Department = employeeString[2]
                };
                listEmployees.Items.Add(employee);
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            LoadEmployees("Employees.txt");
        }

        private void btnSwitch_Click(object sender, RoutedEventArgs e)
        {
            dep = new DepartmentsWindow();
            dep.ShowDialog();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            add = new Add(this);
            add.ShowDialog();
        }

        private void listEmployees_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Employee employee = (Employee)listEmployees.SelectedItem;
            if (employee == null) return;
            Add add = new Add(this, employee);
            add.ShowDialog();
        }

    }
}
