using UnityEngine;

public class FogOfWar : MonoBehaviour
{
    void Awake()
    {
        InGameSettings.FogOfWarEnabledChanged += OnFogOfWarEnabledChange;
        OnFogOfWarEnabledChange(InGameSettings.FogOfWarEnabled);
    }
    void OnFogOfWarEnabledChange(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}
