using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using DesktopNotifications;
using ShellLinkPlus;

namespace NotificationTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {

            string shortcutPath = Path.Combine(
                //Environment.GetFolderPath(Environment.SpecialFolder.Programs),
                Environment.GetFolderPath(Environment.SpecialFolder.Startup),
                "NotificationTest.lnk");

            // Register AUMID and COM server (for MSIX/sparse package apps, this no-ops)
            DesktopNotificationManagerCompat.RegisterAumidAndComServer<MyNotificationActivator>("Notification.Test123");
            // Register COM server and activator type
            DesktopNotificationManagerCompat.RegisterActivator<MyNotificationActivator>();

            CreateShortcut(shortcutPath);

            base.OnStartup(e);
            var window = new MainWindow();
            window.Show();
        }

        private void CreateShortcut(string shortcutPath)
        {

            try
            {
                using (ShellLink shortcut = new ShellLink())
                {
                    shortcut.TargetPath = "C:\\Program Files (x86)\\NotificationsTest123\\NotificationTest.exe";
                    shortcut.Arguments = "";
                    shortcut.AppUserModelID = "Notification.Test123";
                    shortcut.CLSID = new Guid("b36a1f69-9a84-4a35-a3ee-bfd796c14256");
                    shortcut.Save("C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\NotificationsTest123\\Notification Test.lnk");
                    //shortcut.Save(shortcutPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not created shortcut file. " + ex.Message);
            }
        }
    }
}
