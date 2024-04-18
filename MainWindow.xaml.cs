using System.Linq;
using System.Windows;

namespace CsharpSB_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnButtonClick_ToTextSplit(object sender, RoutedEventArgs e)
        {
            ListBoxToSplit.ItemsSource = TextBoxToSplit.Text.Split(' ').ToList();
            ListBoxToSplit.Items.Refresh();
        }

        private void OnButtonClick_ToTextRevers(object sender, RoutedEventArgs e)
        {
            TextBlockToRevers.Text = string.Join(" ", TextBoxToRevers.Text.Split(' ').Reverse());
        }
    }
}
