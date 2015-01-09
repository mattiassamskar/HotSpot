using Microsoft.Win32;

namespace Molesley
{
  public class LockScreenHandler
  {
    private SpotifyHandler _spotifyHandler;

    public LockScreenHandler(SpotifyHandler spotifyHandler)
    {
      _spotifyHandler = spotifyHandler;
    }

    public void SetupLockScreenListener()
    {
      SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
    }

    private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
    {
      if (e.Reason == SessionSwitchReason.SessionLock)
      {
        _spotifyHandler.PauseIfPlaying();
      }
    }
  }
}
