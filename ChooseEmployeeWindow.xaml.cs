using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using CsharpSB_WPF.Project.Employees;

namespace CsharpSB_WPF
{
    /// <summary>
    /// Логика взаимодействия для ChooseEmployeeWindow.xaml
    /// </summary>
    public partial class ChooseEmployeeWindow : Window
    {
        public ChooseEmployeeWindow()
        {
            InitializeComponent();
            EmployeesComboBox.ItemsSource = new Employee[] {
                new Consultant(),
                new Manager()
            };
            EmployeesComboBox.DisplayMemberPath = "EmployeeName";
            EmployeesComboBox.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Debug.WriteLine("EmployeesComboBox.SelectionBoxItem:" + EmployeesComboBox.SelectionBoxItem);
            Window window = new SelectClientWindow((Employee)EmployeesComboBox.SelectionBoxItem);
            Close();
            // Visibility = Visibility.Hidden;
            window.Show();
        }

        private void EmployeesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("e:" + e);
            Debug.WriteLine("sender:" + sender);
            Debug.WriteLine("EmployeesComboBox.SelectionBoxItem:" + EmployeesComboBox.SelectionBoxItem);
        }
    }
}
