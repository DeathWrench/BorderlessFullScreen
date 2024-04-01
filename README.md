# Borderless Full Screen
- Game must be set to windowed mode for this to work properly. 
#### 1.0.1: The mod will do this for you.
#### 2.0.0: Mod doesn't do this anymore to maintain compatibility with other games that can also utilize BepInEx

# 2.0.0
No longer use Autohotkey.Interop dependency, instead just do what the ahk script did:
```
public class BorderlessFullScreenPlugin : BaseUnityPlugin
{
    [DllImport("user32.dll")]
    private static extern IntPtr FindWindow(string className, string windowName);

    [DllImport("user32.dll")]
    private static extern int GetWindowLong(IntPtr hWnd, int index);

    [DllImport("user32.dll")]
    private static extern int SetWindowLong(IntPtr hWnd, int index, int value);

    [DllImport("user32.dll")]
    private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int width, int height, uint flags);

    private const int GWL_STYLE = -16;
    private const uint SWP_FRAMECHANGED = 0x0020;
    private const uint SWP_SHOWWINDOW = 0x0040;

    private void Start()
    {
        IntPtr hWnd = FindWindow("UnityWndClass", null);
        if (hWnd != IntPtr.Zero)
        {
            int style = GetWindowLong(hWnd, GWL_STYLE);
            style &= ~0xC40000; // Remove WS_BORDER and WS_CAPTION
            SetWindowLong(hWnd, GWL_STYLE, style);

            SetWindowPos(hWnd, IntPtr.Zero, 0, 0, Screen.width, Screen.height, SWP_FRAMECHANGED | SWP_SHOWWINDOW);
        }
        else
        {
            Debug.LogError("Unity window not found.");
        }

        Debug.Log($"Plugin {"BorderlessFullscreen"} is loaded!");
    }
}
```

# Old Description for version 1.0.1
 Uses [AutoHotkey.Interop](https://github.com/amazing-andrew/AutoHotkey.Interop) to execute the following AutoHotkey script into the game through BepInEx.

```
procName := "UnityWndClass"
WinGet Style, Style, % "ahk_class " procName
If (Style & 0xC40000)
{
WinSet, Style, -0xC40000, % "ahk_class " procName
WinMove, % "ahk_class " procName, , 0, 0, A_ScreenWidth + 1, A_ScreenHeight + 1
}
Return
```
The benefit of using this is so [DXVK](https://github.com/doitsujin/dxvk) can run... as it seems to crash the game for anything other than windowed mode.\
.ahk script modified from: 
- https://stackoverflow.com/a/29566263 
- https://www.pcgamingwiki.com/wiki/AutoHotkey#Fullscreen_toggle_script
