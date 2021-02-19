using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceship : MonoBehaviour
{
    public float Speed = 10.0f, laserSpeed = 10.0f;
    private float FireDelay = 0.25f, FireInterval = 0.5f;
    private bool StartedFiring = false;
    public Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

    }

    void Movement()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed, 0);
       
    }

    void Fire()
    {
        GameObject laser1 = (GameObject)Resources.Load("Laser1", typeof(GameObject));
        GameObject laser = Instantiate(laser1, new Vector3(transform.position.x, transform.position.y + 1.075f, 0), Quaternion.identity);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("Enemy1") || collision.CompareTag("Enemy2") || collision.CompareTag("Enemy3")) && !StartedFiring)
        {
            InvokeRepeating("Fire", FireDelay, FireInterval);
            StartedFiring = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.CompareTag("Enemy1") || collision.CompareTag("Enemy2") || collision.CompareTag("Enemy3")) && !StartedFiring)
        {
            InvokeRepeating("Fire", FireDelay, FireInterval);
            StartedFiring = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.CompareTag("Enemy1") || collision.CompareTag("Enemy2") || collision.CompareTag("Enemy3")) && StartedFiring)
        {
            CancelInvoke();
            StartedFiring = false;
        }
    }
}
