using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceship : MonoBehaviour
{
    public float laserSpeed = 10.0f;
    public Rigidbody2D rb;
    public float Speed = 0.4f; //magnitude of speed can be changed
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))   // F ye basýnca düþmanlarýn hepsi ateþ eder
        {
            Invoke("EnemyFire", 0);
        }
        rb.velocity = new Vector2(0, -Speed);
       
    }

    public void EnemyFire()
    {
        GameObject laser2 = (GameObject)Resources.Load("Laser2", typeof(GameObject));
        GameObject enemylaser = Instantiate(laser2, new Vector3(transform.position.x, transform.position.y - 1.075f, 0), Quaternion.identity);
        enemylaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserSpeed);
    }
}
