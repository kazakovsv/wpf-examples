using System.Windows;
using System.Windows.Controls;

namespace RoutedEvents.CustomRoutedEvent.CSharp
{
    public partial class MainWindow : Window
    {
        private readonly ListBox _outputListBox = new ListBox();

        public MainWindow()
        {
            InitializeComponent();
            InitializeProperties();
            InitializeWindowContent();
        }

        private void InitializeProperties()
        {
            Title = "Custom Routed Event";
            ResizeMode = ResizeMode.CanMinimize;
            SizeToContent = SizeToContent.WidthAndHeight;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void InitializeWindowContent()
        {
            Grid grid = new Grid
            {
                Margin = new Thickness(1),
                MinHeight = 576,
                MinWidth = 384
            };

            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            _outputListBox.Margin = new Thickness(1);

            var virtualizingStackPanel =
                new FrameworkElementFactory(typeof(VirtualizingStackPanel));
            virtualizingStackPanel.SetValue(VerticalAlignmentProperty, VerticalAlignment.Bottom);

            _outputListBox.ItemsPanel = new ItemsPanelTemplate
            {
                VisualTree = virtualizingStackPanel
            };

            grid.Children.Add(_outputListBox);
            Grid.SetRow(_outputListBox, 0);

            SendBox sendBox = new SendBox
            {
                Margin = new Thickness(1),
                MinHeight = 24
            };

            sendBox.Send += OnSend;

            grid.Children.Add(sendBox);
            Grid.SetRow(sendBox, 1);

            Content = grid;
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
