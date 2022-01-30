using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace RoutedEvents.CustomRoutedEvent.CSharp
{
    public class SendBox : UserControl
    {
        private readonly TextBox _inputTextBox = new TextBox();
        private readonly Button _sendButton = new Button();

        // Определение идентификатора маршрутизируемого события.
        public static readonly RoutedEvent SendEvent =
            EventManager.RegisterRoutedEvent(   // Регистрирует событие в системе событий.
                "Send",                         // Имя события.
                RoutingStrategy.Bubble,         // Стратегия маршрутизации.
                typeof(RoutedEventHandler),     // Тип делегата события.
                typeof(SendBox));               // Тип владельца события.

        // CLR оболочка события.
        public event RoutedEventHandler Send
        {
            add => AddHandler(SendEvent, value);
            remove => RemoveHandler(SendEvent, value);
        }

        // Метод, инициирующий событие.
        protected virtual void OnSend()
        {
            RoutedEventArgs args = new RoutedEventArgs(SendEvent);
            RaiseEvent(args);
        }

        public SendBox()
        {
            Initialize();
        }

        private void Initialize()
        {
            Grid grid = new Grid { Margin = new Thickness(1) };
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            _inputTextBox.VerticalContentAlignment = VerticalAlignment.Center;
            _inputTextBox.Margin = new Thickness(1);
            grid.Children.Add(_inputTextBox);
            Grid.SetColumn(_inputTextBox, 0);

            _sendButton.Content = "Send";
            _sendButton.Padding = new Thickness(12, 3, 12, 3);
            _sendButton.Margin = new Thickness(1);
            _sendButton.IsDefault = true;
            _sendButton.Click += OnSendButtonClick;

            var binding = new Binding("Text.Length") { Source = _inputTextBox };
            _sendButton.SetBinding(IsEnabledProperty, binding);
            grid.Children.Add(_sendButton);
            Grid.SetColumn(_sendButton, 1);

            Border border = new Border
            {
                Child = grid,
                Background = SystemColors.ControlBrush,
                BorderBrush = SystemColors.ActiveBorderBrush,
                BorderThickness = new Thickness(1)
            };

            Content = border;
        }

        public string Message => _inputTextBox.Text;

        private void OnSendButtonClick(object sender, RoutedEventArgs e)
        {
            OnSend();
            _inputTextBox.Clear();
        }
    }
}
