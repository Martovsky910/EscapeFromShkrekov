using UnityEngine;
[System.Serializable]
public class NodeCreatorSettings
{
    public Vector2 bottomLeftCorner;
    public Vector2 topRightCorner;
    public float cellSize;
    public LayerMask unwalkableLayers;
    public bool enableVisualDebug;
    public float visualDebugTime;
}
