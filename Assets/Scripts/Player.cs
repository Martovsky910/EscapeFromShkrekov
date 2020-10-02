using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float forceMultiply;
    PlayerInteractor playerInteractor;
    PlayerMover playerMover;
    PlayerRotator playerRotator;
    public Vector3 PlayerPosition => gameObject.transform.position;
    void Awake()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        playerMover = new PlayerMover(rb, forceMultiply);
        playerMover.ListenToInput();
        playerRotator = new PlayerRotator(transform, rb);
    }
}
