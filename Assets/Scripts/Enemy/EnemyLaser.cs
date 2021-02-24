using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.Equals("Boundary"))
        {
            Destroy(gameObject);
        }
        if (collision.tag.Equals("Laser"))
        {
            Destroy(gameObject);
            Destroy(GameObject.Find(collision.name));
        }
    }
    
}
