using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] PlayerPropertiesSave playerPropertiesSave;
    [SerializeField] InGameSettingsPreset GamePreset;
    void Awake()
    {
        InGameSettings.ChangePreset(GamePreset);
        GameObject playerGO = Instantiate(playerPrefab);
        Player.SetPlayer(playerGO, playerPropertiesSave);
    }
}
