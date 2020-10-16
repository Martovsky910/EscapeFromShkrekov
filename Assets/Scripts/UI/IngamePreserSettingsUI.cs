using UnityEngine;

public class IngamePreserSettingsUI : MonoBehaviour
{
    [SerializeField] GameObject togglePrefab;
    void Awake()
    {
        IngamePresetToggle toggle = CreateNewToggle();
        toggle.Initialize(InGameSettings.ChangeFogOfWar,
            InGameSettings.FogOfWarEnabled, "Fog of War");
        Input.IngamePreserMenuClick += OnIngamePresetMenuClick;
        gameObject.SetActive(false);
    }

    void OnIngamePresetMenuClick(bool opened)
    {
        gameObject.SetActive(opened);
    }

    IngamePresetToggle CreateNewToggle()
    {
        GameObject toggleGO = Instantiate(togglePrefab, transform);
        IngamePresetToggle toggle = toggleGO.GetComponent<IngamePresetToggle>();
        return toggle;
    }

}
