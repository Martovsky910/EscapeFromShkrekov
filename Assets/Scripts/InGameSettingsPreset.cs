using UnityEngine;
[CreateAssetMenu(fileName ="new InGameSettingsPreset", menuName = "InGameSettingsPreset")]
public class InGameSettingsPreset : ScriptableObject
{
    [SerializeField] bool fogOfWarEnabled;

    public bool FogOfWarEnabled => fogOfWarEnabled;
}
