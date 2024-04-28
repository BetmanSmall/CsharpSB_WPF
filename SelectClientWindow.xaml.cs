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
using CsharpSB_WPF.Project.Utils;

namespace CsharpSB_WPF
{
    /// <summary>
    /// Логика взаимодействия для SelectClientWindow.xaml
    /// </summary>
    public partial class SelectClientWindow : Window {
        private Employee _employee;
        public SelectClientWindow(Employee employee)
        {
            InitializeComponent();
            _employee = employee;
            Debug.WriteLine("_employee:" + _employee);
            Debug.WriteLine("ClientsManager.Clients:" + String.Join(",", ClientsManager.Clients));
            ClientsListView.ItemsSource = ClientsManager.Clients;
            Debug.WriteLine("ClientsManager.Clients:" + String.Join(",", ClientsManager.Clients));
            ClientsListView.Items.Refresh();
        }
    }
}
