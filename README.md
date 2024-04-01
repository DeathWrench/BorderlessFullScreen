# Borderless Full Screen
- Game must be set to windowed mode for this to work properly. 
#### 1.0.1: The mod will do this for you.
#### 2.0.0: Mod doesn't do this anymore to maintain compatibility with other games that can also utilize BepInEx

# 2.0.0
No longer use Autohotkey.Interop dependency

# Old Description for version 1.0.1
# Uses [AutoHotkey.Interop](https://github.com/amazing-andrew/AutoHotkey.Interop) to execute the following AutoHotkey script into the game through BepInEx.

``procName := "UnityWndClass"``\
``WinGet Style, Style, % "ahk_class " procName``\
``If (Style & 0xC40000)``\
``{``\
``WinSet, Style, -0xC40000, % "ahk_class " procName``\
``WinMove, % "ahk_class " procName, , 0, 0, A_ScreenWidth + 1, A_ScreenHeight + 1``\
``}``\
``Return``\
\
The benefit of using this is so [DXVK](https://github.com/doitsujin/dxvk) can run... as it seems to crash the game for anything other than windowed mode.\
.ahk script modified from: 
- https://stackoverflow.com/a/29566263 
- https://www.pcgamingwiki.com/wiki/AutoHotkey#Fullscreen_toggle_script
