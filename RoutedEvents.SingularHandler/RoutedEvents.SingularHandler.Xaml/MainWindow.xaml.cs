using System.Windows;

namespace RoutedEvents.SingularHandler.Xaml
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            FrameworkElement frameworkElement = e.Source as FrameworkElement;

            switch (frameworkElement.Name)
            {
                case "Yes":
                    OnYesButtonClick();
                    break;
                case "No":
                    OnNoButtonClick();
                    break;
                case "Cancel":
                    OnCancelButtonClick();
                    break;
                default:
                    OnUnknownButtonClick();
                    break;
            }

            e.Handled = true;
        }

        private void OnYesButtonClick()
        {
            MessageBox.Show("Yes");
        }

        private void OnNoButtonClick()
        {
            MessageBox.Show("No");
        }

        private void OnCancelButtonClick()
        {
            MessageBox.Show("Cancel");
        }

        private void OnUnknownButtonClick()
        {
            MessageBox.Show("Unknown");
        }
    }
}
