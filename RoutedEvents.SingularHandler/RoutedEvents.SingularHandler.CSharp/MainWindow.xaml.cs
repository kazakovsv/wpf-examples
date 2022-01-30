using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace RoutedEvents.SingularHandler.CSharp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeProperties();
            InitializeResources();
            InitializeWindowContent();
        }

        private void InitializeProperties()
        {
            Title = "Singular Handler";
            ResizeMode = ResizeMode.CanMinimize;
            SizeToContent = SizeToContent.WidthAndHeight;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void InitializeResources()
        {
            Style style = new Style(typeof(Button));
            style.Setters.Add(new Setter(HorizontalAlignmentProperty,
                HorizontalAlignment.Center));
            style.Setters.Add(new Setter(VerticalAlignmentProperty,
                VerticalAlignment.Center));
            style.Setters.Add(new Setter(MinWidthProperty, 75.0));
            style.Setters.Add(new Setter(MarginProperty, new Thickness(3)));

            Resources.Add(typeof(Button), style);
        }

        private void InitializeWindowContent()
        {
            Border border = new Border
            {
                Background = SystemColors.ControlBrush,
                BorderBrush = SystemColors.ActiveBorderBrush,
                BorderThickness = new Thickness(1),
                Margin = new Thickness(6),
                MinHeight = 40,
                MinWidth = 300,
            };

            Grid grid = new Grid
            {
                Margin = new Thickness(3)
            };

            border.Child = grid;

            grid.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(
                OnButtonClick));

            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            Button yesButton = new Button
            {
                Name = "Yes",
                Content = "Yes"
            };

            Button noButton = new Button
            {
                Name = "No",
                Content = "No"
            };

            Button cancelButton = new Button
            {
                Name = "Cancel",
                Content = "Cancel"
            };

            grid.Children.Add(yesButton);
            grid.Children.Add(noButton);
            grid.Children.Add(cancelButton);

            Grid.SetColumn(yesButton, 0);
            Grid.SetColumn(noButton, 1);
            Grid.SetColumn(cancelButton, 2);

            Content = border;
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
