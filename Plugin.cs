using System;
using System.Runtime.InteropServices;
using BepInEx;
using UnityEngine;

[BepInPlugin($"{PLUGIN_GUID}", $"{PLUGIN_NAME}", $"{PLUGIN_VERSION}")]
public class BorderlessFullScreenPlugin : BaseUnityPlugin
{
    public const string PLUGIN_GUID = "DeathWrench.BorderlessFullscreen";
    public const string PLUGIN_NAME = "Borderless Fullscreen";
    public const string PLUGIN_VERSION = "2.0.1";
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
            style &= ~0xC40000;
            SetWindowLong(hWnd, GWL_STYLE, style);

            SetWindowPos(hWnd, IntPtr.Zero, 0, 0, Screen.width, Screen.height, SWP_FRAMECHANGED | SWP_SHOWWINDOW);
        }
        else
        {
            Debug.LogError("Unity window not found.");
        }

        Debug.Log($"Plugin {PLUGIN_NAME} {PLUGIN_VERSION} is loaded!");
    }
}
