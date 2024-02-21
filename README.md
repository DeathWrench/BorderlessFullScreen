# Borderless Window Mode
- Game must be set to windowed mode for this to work properly.

# Uses [AutoHotkey.Interop](https://github.com/amazing-andrew/AutoHotkey.Interop) to execute the following autohotkey script into the game at runtime.

``SetTitleMatchMode, RegEx``\
``WinActivate, Lethal Company, , BepInEx 5.4.21.0 - Lethal Company``\
``WinActivate, Lethal Company, , BepInEx 5.4.22.0 - Lethal Company``\
``WinGet, WindowID, ID, A``\
``WinSet, Style, -0xC40000, ahk_id %WindowID%``\
``WinMove, ahk_id %WindowID%, , 0, 0, A_ScreenWidth, A_ScreenHeight``

Could possible mess up if another window named Lethal Company is present.
