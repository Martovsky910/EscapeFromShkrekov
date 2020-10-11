using UnityEngine;

public static class Player
{
    static PlayerInteractor playerInteractor;
    static PlayerMover playerMover;
    static PlayerRotator playerRotator;

    public static PlayerProperties Properties;
    public static GameObject GO { get; private set; }
    public static Vector3 PlayerPosition => GO.transform.position;
    public static void SetPlayer(GameObject go, PlayerPropertiesSave playerSave)
    {
        GO = go;
        Properties = new PlayerProperties(playerSave);
        playerMover = new PlayerMover();
        playerMover.ListenToInput();
        playerRotator = new PlayerRotator();
    }
}
