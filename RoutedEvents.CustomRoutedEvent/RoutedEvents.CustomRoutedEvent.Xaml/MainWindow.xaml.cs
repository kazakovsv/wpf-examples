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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RoutedEvents.CustomRoutedEvent.Xaml
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnSend(object sender, RoutedEventArgs e)
        {
            if (!(e.Source is SendBox sendBox) ||
                string.IsNullOrWhiteSpace(sendBox.Message))
            {
                return;
            }

            _outputListBox.Items.Add(new ListBoxItem { Content = sendBox.Message });
        }
    }
}
