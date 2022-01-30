using System.Windows;
using System.Windows.Controls;

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
