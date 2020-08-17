using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace homework6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Employee> employees;
        ObservableCollection<Department> departments;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void windowMain_Loaded(object sender, RoutedEventArgs e)
        {
            departments = new ObservableCollection<Department>();
            departments.Add(new Department() { Name = "Without Department" });
            departments.Add(new Department() { Name = "Main" });
            departments.Add(new Department() { Name = "Economic" });
            lvDepartments.ItemsSource = departments;
            cbDepartments.ItemsSource = departments;

            employees = new ObservableCollection<Employee>();
            employees.Add(new Employee()
            {
                FullName = "Maria Perova",
                Department = departments[1]
            });
            employees.Add(new Employee()
            {
                FullName = "Sergey Serov",
                Department = departments[2]
            });
            lvEmployees.ItemsSource = employees;
        }

        private void lvEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lvEmployees.SelectedItem != null)
            {
                Employee emp = (Employee)lvEmployees.SelectedItem;
                tbFullName.Text = emp.FullName;
                cbDepartments.SelectedItem = emp.Department;
            }
        }

        private void btnAddEmp_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbFullName.Text))
            employees.Add(new Employee() { FullName = tbFullName.Text,
            Department = (Department) cbDepartments.SelectedItem});
        }

        private void btnChangeEmp_Click(object sender, RoutedEventArgs e)
        {
            if (lvEmployees.SelectedItem != null && !String.IsNullOrWhiteSpace(tbFullName.Text))
            {
                (lvEmployees.SelectedItem as Employee).FullName = tbFullName.Text;
                (lvEmployees.SelectedItem as Employee).Department = (Department)cbDepartments.SelectedItem;
            }
        }

        private void btnDeleteEmp_Click(object sender, RoutedEventArgs e)
        {
            if (lvEmployees.SelectedItem != null)
                employees.Remove(lvEmployees.SelectedItem as Employee);
        }

        private void cbDepartments_Loaded(object sender, RoutedEventArgs e)
        {
            cbDepartments.ItemsSource = departments;
        }

        private void btnAddDep_Click(object sender, RoutedEventArgs e)
        {
            departments.Add(new Department() { Name = tbName.Text });
        }

        private void btnChangeDep_Click(object sender, RoutedEventArgs e)
        {
            if (lvDepartments.SelectedItem != null)
                (lvDepartments.SelectedItem as Department).Name = tbName.Text;
        }

        private void btnDeleteDep_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Department == (Department)lvDepartments.SelectedItem)
                {
                    employees[i].Department = departments[0];
                }
            }
            if (lvDepartments.SelectedItem != null)
                departments.Remove(lvDepartments.SelectedItem as Department);
        }

        private void tbTask_Loaded(object sender, RoutedEventArgs e)
        {
            tbTask.Text = File.ReadAllText("task.txt");
        }

        private void lvDepartments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvDepartments.SelectedItem != null)
            {
                Department dep = (Department)lvDepartments.SelectedItem;
                tbName.Text = dep.Name;
            }
        }
    }
}
