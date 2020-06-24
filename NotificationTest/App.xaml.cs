using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DesktopNotifications;

namespace NotificationTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            // Register AUMID and COM server (for MSIX/sparse package apps, this no-ops)
            DesktopNotificationManagerCompat.RegisterAumidAndComServer<MyNotificationActivator>("Notification.Test123");
            // Register COM server and activator type
            DesktopNotificationManagerCompat.RegisterActivator<MyNotificationActivator>();
            base.OnStartup(e);
            var window = new MainWindow();
            window.Show();
        }
    }
}
