using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform player;
    public GameObject bullet;
    private float shotCooldown;
    public float startCooldown;
    void Start()
    {
        shotCooldown = startCooldown;
    }

    void Update()
    {
        if(shotCooldown <= 0)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            shotCooldown = startCooldown;
        }
        else
        {
            shotCooldown -= Time.deltaTime;
        }
    }
}
