using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        if (transform.position.y < -9.6f)
        {
            Destroy(this.gameObject);
            Debug.Log("GG");
        }
            
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Outside"))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name.Equals("Outside"))
        {
            Destroy(this.gameObject);
        }
    }
    */
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.Equals("Boundary"))
        {
            Destroy(gameObject);
        }

        if (collision.tag.Equals("Laser"))
        {
            Destroy(GameObject.Find(collision.name));
            Destroy(gameObject);
        }
    }
    
}
