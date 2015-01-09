using System.Windows.Input;
using GlobalHotKey;

namespace Molesley
{
  public class HotkeyHandler
  {
    private HotKeyManager _hotKeyManager;
    private SpotifyHandler _spotifyHandler;

    public HotkeyHandler(HotKeyManager hotKeyManager, SpotifyHandler spotifyHandler)
    {
      _hotKeyManager = hotKeyManager;
      _spotifyHandler = spotifyHandler;
    }

    public void SetupHotKeys()
    {
      try
      {
        _hotKeyManager.Register(Key.P, ModifierKeys.Alt | ModifierKeys.Control | ModifierKeys.Shift);
        _hotKeyManager.Register(Key.Add, ModifierKeys.Alt | ModifierKeys.Control | ModifierKeys.Shift);
        _hotKeyManager.Register(Key.Subtract, ModifierKeys.Alt | ModifierKeys.Control | ModifierKeys.Shift);
        _hotKeyManager.KeyPressed += HotKeyPressed;
      }
      catch
      {
      }
    }

    private void HotKeyPressed(object sender, KeyPressedEventArgs args)
    {
      switch (args.HotKey.Key)
      {
        case Key.P:
          _spotifyHandler.PlayPause();
          break;
        case Key.Add:
          _spotifyHandler.NextTrack();
          break;
        case Key.Subtract:
          _spotifyHandler.PreviousTrack();
          break;
      }
    }
  }
}
