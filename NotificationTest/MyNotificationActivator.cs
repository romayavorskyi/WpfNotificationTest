// The GUID CLSID must be unique to your app. Create a new GUID if copying this code.

using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Threading;
using DesktopNotifications;

[ClassInterface(ClassInterfaceType.None)]
[ComSourceInterfaces(typeof(NotificationActivator.INotificationActivationCallback))]
[Guid("b36a1f69-9a84-4a35-a3ee-bfd796c14256"), ComVisible(true)]
public class MyNotificationActivator : NotificationActivator
{
    public override void OnActivated(string invokedArgs, NotificationUserInput userInput, string appUserModelId)
    {
        Dispatcher.CurrentDispatcher.Invoke(() => MessageBox.Show("Notification captured"));
    }
}