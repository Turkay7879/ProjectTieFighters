using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoundary : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.Equals("Player")) {
            GameObject player = GameObject.Find("Player");
            float magnitude = 10000f;
            var force = transform.position - player.transform.position;
            force.Normalize();
            player.GetComponent<Rigidbody2D>().AddRelativeForce(force * magnitude);
        }

        else if(collision.name.Equals("Laser1(Clone)"))
        {
            Destroy(GameObject.Find("Laser1(Clone)"));
        }

    }
}
