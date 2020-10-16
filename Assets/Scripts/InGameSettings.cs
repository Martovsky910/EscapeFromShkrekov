using System;

public static class InGameSettings
{
    public static event Action<bool> FogOfWarEnabledChanged;
    static bool fogOfWarEnabled;

    public static bool FogOfWarEnabled
    {
        get => fogOfWarEnabled;
        private set
        {
            fogOfWarEnabled = value;
            FogOfWarEnabledChanged?.Invoke(value);
        }
    }
    public static void ChangePreset(InGameSettingsPreset preset)
    {
        FogOfWarEnabled = preset.FogOfWarEnabled;
    }
    public static void ChangeFogOfWar(bool value)
    {
        FogOfWarEnabled = value;
    }
}
