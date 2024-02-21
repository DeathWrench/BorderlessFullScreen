using AutoHotkey.Interop;
using BepInEx;
using HarmonyLib;
using System.Reflection;

namespace BorderlessFullScreen
{
    [BepInPlugin("BorderlessFullScreen", "BorderlessFullScreen", "0.0.2")]
    [HarmonyPatch]
    public class BorderlessFullScreen : BaseUnityPlugin
    {
        void Start()
        {
            var ahk = AutoHotkeyEngine.Instance; 
            ahk.ExecRaw("SetTitleMatchMode, 2 \r\nSetTitleMatchMode, slow \r\nWinActivate, Lethal Company, , BepInEx 5.4.21.0 - Lethal Company\r\nWinGet, WindowID, ID, A\r\nWinSet, Style, -0xC40000, ahk_id %WindowID%\r\nWinMove, ahk_id %WindowID%, , 0, 0, A_ScreenWidth - 0, A_ScreenHeight - 0");
            Logger.LogInfo($"Plugin {"BorderlessFullScreen"} is loaded!");
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
