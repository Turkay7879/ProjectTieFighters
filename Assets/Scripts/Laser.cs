using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Spaceship"))
        {
            Destroy(GameObject.Find(collision.name));
            Destroy(GameObject.Find("Laser1(Clone)"));
        }
    }
}
