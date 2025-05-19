using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotater : MonoBehaviour
{
    Rigidbody physics;
    public int speed;
    void Start()
    {
        physics = GetComponent<Rigidbody>();
        physics.angularVelocity = Random.insideUnitSphere * speed; // Random bir açısal hız veriyoruz
    }

    
}
