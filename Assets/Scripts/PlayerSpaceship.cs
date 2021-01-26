using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceship : MonoBehaviour
{
    public float Speed = 10.0f, laserSpeed = 10.0f;
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

        if (Input.GetKeyDown(KeyCode.F))
            Fire();
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

    
}
