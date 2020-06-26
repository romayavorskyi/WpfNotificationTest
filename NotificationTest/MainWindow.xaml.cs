using System;
using System.Windows;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Microsoft.Toolkit.Uwp.Notifications;
using DesktopNotifications;
using DesktopNotificationManagerCompat = DesktopNotifications.DesktopNotificationManagerCompat;

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
            try
            {
                // Construct the visuals of the toast (using Notifications library)
                ToastContent toastContent = new ToastContent()
                {


                    // Arguments when the user taps body of toast
                    Launch = "action=viewConversation&conversationId=5",

                    Visual = new ToastVisual()
                    {
                        BindingGeneric = new ToastBindingGeneric()
                        {
                            Children =
                            {
                                new AdaptiveText()
                                {
                                    Text = "Hello world!"
                                }
                            }
                        }
                    }
                };

                // Create the XML document (BE SURE TO REFERENCE WINDOWS.DATA.XML.DOM)
                var doc = new XmlDocument();
                doc.LoadXml(toastContent.GetContent());

                // And create the toast notification
                var toast = new ToastNotification(doc);

                // And then show it
                DesktopNotificationManagerCompat.CreateToastNotifier().Show(toast);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Notification is not supported. Exception type - {exception.GetType()}");
            }

        }

        private void DeferredNotification(object sender, RoutedEventArgs e)
        {
            try
            {
                // Construct the visuals of the toast (using Notifications library)
                ToastContent toastContent = new ToastContent()
                {
                

                    // Arguments when the user taps body of toast
                    Launch = "action=viewConversation&conversationId=5",

                    Visual = new ToastVisual()
                    {
                        BindingGeneric = new ToastBindingGeneric()
                        {
                            Children =
                            {
                                new AdaptiveText()
                                {
                                    Text = "Hello world!"
                                }
                            }
                        }
                    }
                };

                // Create the XML document (BE SURE TO REFERENCE WINDOWS.DATA.XML.DOM)
                var doc = new XmlDocument();
                doc.LoadXml(toastContent.GetContent());

                // And create the toast notification
                var toast = new ScheduledToastNotification(toastContent.GetXml(), DateTime.Now.AddSeconds(10));

                // And then show it
                DesktopNotificationManagerCompat.CreateToastNotifier().AddToSchedule(toast);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Notification is not supported. Exception type - {exception.GetType()}");
            }
        }
    }
}
