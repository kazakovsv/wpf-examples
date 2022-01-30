using System.Windows;
using System.Windows.Controls;

namespace RoutedEvents.CustomRoutedEvent.Xaml
{
    public partial class SendBox : UserControl
    {
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
            InitializeComponent();
        }

        public string Message => _inputTextBox.Text;

        private void OnSendButtonClick(object sender, RoutedEventArgs e)
        {
            OnSend();
            _inputTextBox.Clear();
        }
    }
}
