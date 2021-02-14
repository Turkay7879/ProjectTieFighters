using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceship : MonoBehaviour
{
    public float laserSpeed = 10.0f;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))   // F ye basýnca düþmanlarýn hepsi ateþ eder
        {
            Invoke("EnemyFire", 0);
        }
    }

    public void EnemyFire()
    {
        GameObject laser2 = (GameObject)Resources.Load("Laser2", typeof(GameObject));
        GameObject enemylaser = Instantiate(laser2, new Vector3(transform.position.x, transform.position.y - 1.075f, 0), Quaternion.identity);
        enemylaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserSpeed);
    }
}
