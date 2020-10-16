using System;
using UnityEngine;
using UnityEngine.UI;

public class IngamePresetToggle : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] Toggle toggle;
    Action<bool> onToggleChange;
    public void Initialize(Action<bool> onToggleChange, bool startState, string text)
    {
        toggle.isOn = startState;
        toggle.onValueChanged.AddListener(OnValueChanged);
        this.text.text = text;
        this.onToggleChange = onToggleChange;
    }
    public void OnValueChanged(bool value)
    {
        if (onToggleChange != null)
            onToggleChange.Invoke(value);
    }
}
