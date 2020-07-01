using System.Windows;

namespace NotificationTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InstantNotification(object sender, RoutedEventArgs e)
        {
            NotificationManager.InstantNotification();
        }

        private void DeferredNotification(object sender, RoutedEventArgs e)
        {
            NotificationManager.DeferredNotification();
        }
    }
}
