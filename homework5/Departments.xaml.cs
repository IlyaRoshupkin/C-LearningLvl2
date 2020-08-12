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

namespace homework5
{
    /// <summary>
    /// Interaction logic for Departments.xaml
    /// </summary>
    public partial class DepartmentsWindow : Window
    {
        public List<string> DepartmentsList = new List<string>
            {
                "Главный","Производственный","Юридический","Экономический","Общественный",
                "Социальный","Управленческий","Образовательный","Вспомогательный"
            };
        public class Departments
            {
            public string Name { get; set; }
            }
        

        public void LoadDepartments()
        {
            for (int i = 0; i < DepartmentsList.Count; i++)
            {
                Departments department = new Departments()
                {
                    Name = DepartmentsList[i]
                };
                listDepartments.Items.Add(department);
            }
        }
          
        public DepartmentsWindow()
        {
            InitializeComponent();
            LoadDepartments();
            
        }

        private void btnAddDep_Click(object sender, RoutedEventArgs e)
        {
            DepartmentsList.Add(tbNewDep.Text);
            listDepartments.Items.Add(new Departments() { Name = tbNewDep.Text }) ;
        }
    }
}
