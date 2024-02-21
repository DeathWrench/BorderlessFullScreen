# Borderless Full Screen
- Game must be set to windowed mode for this to work properly.

# Uses [AutoHotkey.Interop](https://github.com/amazing-andrew/AutoHotkey.Interop) to execute the following AutoHotkey script into the game through BepInEx.

``SetTitleMatchMode, 2``\
``SetTitleMatchMode, slow``\
``WinActivate, Lethal Company, , BepInEx 5.4.21.0 - Lethal Company``\
``WinGet, WindowID, ID, A``\
``WinSet, Style, -0xC40000, ahk_id %WindowID%``\
``WinMove, ahk_id %WindowID%, , 0, 0, A_ScreenWidth - 0, A_ScreenHeight - 0``\
\
The benefit of using this is so [DXVK](https://github.com/doitsujin/dxvk) can run... as it seems to crash the game for anything other than windowed mode.\
This could possibly mess up if another window named Lethal Company is present.\
.ahk script modified from: https://www.pcgamingwiki.com/wiki/AutoHotkey#Fullscreen_toggle_script
