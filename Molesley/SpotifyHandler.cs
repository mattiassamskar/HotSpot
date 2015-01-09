using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Molesley
{
  public class SpotifyHandler
  {
    private const uint WmAppcommand = 0x0319;

    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
    private static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    private static extern int GetWindowTextLength(IntPtr hWnd);

    public void SendAction(SpotifyAction a)
    {
      var spotify = FindWindow("SpotifyMainWindow", null);

      if (spotify == IntPtr.Zero)
        return;

      SendMessage(spotify, WmAppcommand, IntPtr.Zero, new IntPtr((long)a));
    }

    public void PauseIfPlaying()
    {
      if(this.IsPlaying())
        this.SendAction(SpotifyAction.PlayPause);
    }

    private static IntPtr GetSpotify()
    {
      return FindWindow("SpotifyMainWindow", null);
    }

    private bool IsAvailable()
    {
      return (GetSpotify() != IntPtr.Zero);
    }

    private bool IsPlaying()
    {
      return this.GetCurrentTrack() != string.Empty;
    }

    private string GetCurrentTrack()
    {
      if (!IsAvailable())
        return string.Empty;

      IntPtr hWnd = GetSpotify();
      int length = GetWindowTextLength(hWnd);
      StringBuilder sb = new StringBuilder(length + 1);
      GetWindowText(hWnd, sb, sb.Capacity);
      return sb.ToString().Replace("Spotify", "").TrimStart(' ', '-').Trim();
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