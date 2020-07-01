using System;
using System.Windows;

namespace NotificationTest
{
    public static  class NotificationManager
    {

        public static void InstantNotification()
        {
            if (Environment.OSVersion.Version.Major >= 10)
            {
                try
                {
                    ToastCreator.CreateInstantToast();
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"Notification is not supported. Exception type - {exception.GetType()}");
                }
            }
        }

        public static  void DeferredNotification()
        {
            if (Environment.OSVersion.Version.Major >= 10)
            {
                try
                {
                    ToastCreator.CreateDefferedToast();
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"Notification is not supported. Exception type - {exception.GetType()}");
                }
            }
        }
    }
}
