using System.Windows;
using GlobalHotKey;
using Hardcodet.Wpf.TaskbarNotification;

namespace Molesley
{

  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    private readonly HotkeyHandler hotkeyHandler = new HotkeyHandler(new HotKeyManager(), new SpotifyHandler());

    private TaskbarIcon notifyIcon;

    protected override void OnStartup(StartupEventArgs e)
    {
      base.OnStartup(e);

      hotkeyHandler.SetupHotKeys();

      notifyIcon = (TaskbarIcon)FindResource("NotifyIcon");
    }

    protected override void OnExit(ExitEventArgs e)
    {
      notifyIcon.Dispose();
      base.OnExit(e);
    }
  }
}
