using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Rigidbody physics;
    [SerializeField] float speed = 10f; // Değişkenlerde serileştirme
    void Start()
    {
        physics = GetComponent<Rigidbody>();

        physics.velocity = transform.forward * speed; // forward blue axis yani z yönünde hareket sağlar
    }

    
}
