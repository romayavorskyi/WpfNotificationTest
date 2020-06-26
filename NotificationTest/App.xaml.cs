using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
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
                Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu),
                "NotificationTest.lnk");

            var execPath = Process.GetCurrentProcess().MainModule?.FileName;

            if (!File.Exists(shortcutPath))
            {
                CreateShortcut(shortcutPath,
                    execPath,
                                Storage.AppUserModelId,
                                Storage.ToastActivatorId);
            }

            // Register AUMID and COM server (for MSIX/sparse package apps, this no-ops)
            DesktopNotificationManagerCompat.RegisterAumidAndComServer<MyNotificationActivator>(Storage.AppUserModelId);
            // Register COM server and activator type
            DesktopNotificationManagerCompat.RegisterActivator<MyNotificationActivator>();

            base.OnStartup(e);
            var window = new MainWindow();
            window.Show();
        }

        private void CreateShortcut(string shortcutPath,
                                    string executablePath,
                                    string appUserModelId,
                                    string toastActivatorId)
        {

            try
            {
                using (ShellLink shortcut = new ShellLink())
                {
                    shortcut.TargetPath = executablePath;
                    shortcut.AppUserModelID = appUserModelId;
                    shortcut.ToastActivatorId = new Guid(toastActivatorId);
                    shortcut.Save(shortcutPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not created shortcut file. " + ex.Message);
            }
        }
    }
}
