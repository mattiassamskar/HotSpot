using System.Windows;
using GlobalHotKey;
using Hardcodet.Wpf.TaskbarNotification;

namespace Hotspot
{

  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    private SpotifyHandler spotifyHandler;
    private HotkeyHandler hotkeyHandler;
    private LockScreenHandler lockScreenHandler;

    private TaskbarIcon notifyIcon;

    protected override void OnStartup(StartupEventArgs e)
    {
      spotifyHandler = new SpotifyHandler();
      hotkeyHandler = new HotkeyHandler(new HotKeyManager(), spotifyHandler);
      lockScreenHandler = new LockScreenHandler(spotifyHandler);

      hotkeyHandler.SetupHotKeys();
//      lockScreenHandler.SetupLockScreenListener();
      
      notifyIcon = (TaskbarIcon)FindResource("NotifyIcon");

      base.OnStartup(e);
    }

    protected override void OnExit(ExitEventArgs e)
    {
      notifyIcon.Dispose();
      base.OnExit(e);
    }
  }
}
