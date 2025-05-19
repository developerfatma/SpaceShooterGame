using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //  Classlar da serileştirme
public class Boundary
{
    public float xMin, xMax, zMin, zMax;

}
public class playerController : MonoBehaviour
{
    Rigidbody physics;
    AudioSource audioSource;            
    [SerializeField] int speed; // Değişkenlerde serileştirme
    [SerializeField] int tilt;
     [SerializeField] float nextFire;
    [SerializeField] float fireRate;

    public Boundary boundary;
    public GameObject shot;
    public GameObject shotSpawn;


    void Start()
    {
        physics = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

        if (Input.GetButtonDown("Fire1") && Time.time > nextFire) // fire1 sol click
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
            audioSource.Play();
        }
        
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        physics.velocity = movement * speed;


        Vector3 position = new Vector3(
            Mathf.Clamp(physics.position.x, boundary.xMin, boundary.xMax),
            0,
            Mathf.Clamp(physics.position.z, boundary.zMin, boundary.zMax)
        );

        physics.position = position;

        physics.rotation = Quaternion.Euler(0, 0, physics.velocity.x *tilt);

    }
}
