using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    Camera camera;
    [SerializeField]
    Transform playerTransform;
    [SerializeField]
    float Coeff;
    Vector3 playerPos;
    Quaternion playerRotation;
    void Update()
    {
        if (playerPos != playerTransform.position || playerRotation != playerTransform.rotation)
        {
            camera.transform.position = new Vector3
                (playerTransform.position.x, playerTransform.position.y, -10);
            camera.transform.position += Camera.main.transform.up * Coeff;
            camera.transform.rotation = playerTransform.rotation;
        }
        playerPos = playerTransform.position;
        playerRotation = playerTransform.rotation;
    }
}
