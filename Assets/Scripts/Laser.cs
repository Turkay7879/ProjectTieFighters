using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    GameManagement Management;
    // Start is called before the first frame update
    void Start()
    {
        Management = GameObject.Find("GameManagement").GetComponent<GameManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
        {
            Destroy(GameObject.Find(collision.name));
            Destroy(GameObject.Find("Laser1(Clone)"));
            int tempCount = Management.EnemyCount;
            tempCount--;
            Management.EnemyCount = tempCount;
        }
        else if (collision.name.Equals("Laser2(Clone)"))
        {
            Destroy(GameObject.Find(collision.name));
            Destroy(GameObject.Find("Laser1(Clone)"));
        }
    }
}
