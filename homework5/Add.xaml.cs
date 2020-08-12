using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace homework5
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public List<string> depList;
        private MainWindow.Employee employee;
        MainWindow mainWindow = new MainWindow();
        public Add(MainWindow mainWindow)
        {
            InitializeComponent();
            LoadBoxDepartments();
            this.mainWindow = mainWindow;
            btnChange.IsEnabled = false;
        }

        public Add(MainWindow mainWindow, MainWindow.Employee employee) : this(mainWindow)
        {

            if(employee != null)
            {
                this.employee = employee;
                tbName.IsReadOnly = true;
                tbName.Text = employee.Name;
                tbPosition.IsReadOnly = true;
                tbPosition.Text = employee.Position;
                cbDepartment.SelectedItem = employee.Department;

                btnAddNew.IsEnabled = false;
            }
            else
                return;
        }

        public void LoadBoxDepartments()
        {
            DepartmentsWindow dep = new DepartmentsWindow();
            for (int i = 0; i < dep.DepartmentsList.Count; i++)
            {
                cbDepartment.Items.Add(dep.DepartmentsList[i]);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Employee employee = new MainWindow.Employee()
            {
                Name = tbName.Text,
                Position = tbPosition.Text,
                Department = cbDepartment.SelectedItem.ToString()
            };
            
            mainWindow.listEmployees.Items.Add(employee);
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            int index = mainWindow.listEmployees.Items.IndexOf(employee);
            employee.Department = cbDepartment.SelectedItem.ToString();
            mainWindow.listEmployees.Items.RemoveAt(index);
            mainWindow.listEmployees.Items.Add(employee);
        }
    }
}
