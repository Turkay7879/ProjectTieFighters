using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceship : MonoBehaviour
{
    public float laserSpeed = 10.0f;
    private float FireDelay = 0.75f, FireInterval = 1.00f;
    private bool StartedFiring = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (!StartedFiring)         // d��manlar�n hepsi ayn� anda periodik bir �ekilde ate� eder
        {
            InvokeRepeating("EnemyFire", FireDelay, FireInterval);
            StartedFiring = true;
        }*/

        if (Input.GetKeyDown(KeyCode.F))   // F ye bas�nca d��manlar�n hepsi ate� eder
        {
            Invoke("EnemyFire", 0);
        }
    }

    void EnemyFire()
    {
        GameObject laser2 = (GameObject)Resources.Load("Laser2", typeof(GameObject));
        GameObject enemylaser = Instantiate(laser2, new Vector3(transform.position.x, transform.position.y - 1.075f, 0), Quaternion.identity);
        enemylaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserSpeed);
    }
}
