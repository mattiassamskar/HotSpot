using System;
using System.Runtime.InteropServices;

namespace Molesley
{
  public class SpotifyHandler
  {
    private const uint WmAppcommand = 0x0319;

    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
    private static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

    public void SendAction(SpotifyAction a)
    {
      var spotify = FindWindow("SpotifyMainWindow", null);

      if (spotify == IntPtr.Zero)
        return;

      SendMessage(spotify, WmAppcommand, IntPtr.Zero, new IntPtr((long)a));
    }
  }

  public enum SpotifyAction : long
  {
    None = 0,
    PlayPause = 917504,
    Mute = 524288,
    VolumeDown = 589824,
    VolumeUp = 655360,
    PreviousTrack = 786432,
    NextTrack = 720896
  }
}