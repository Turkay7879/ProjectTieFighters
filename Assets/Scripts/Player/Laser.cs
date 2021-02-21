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
        if (collision.tag.Equals("Enemy1") || collision.tag.Equals("Enemy2") || collision.tag.Equals("Enemy3"))
        {
            Destroy(GameObject.Find(collision.name));
            int tempCount = Management.EnemyCount;
            int temp2Count = Management.frontEnemy_count;
            tempCount--;

            for(int i = 7; i < 14; i++)
            {
                if (collision.name.Equals("Enemy" + i.ToString()))
                {
                    temp2Count--;
                    break;
                }
            }
           
            Management.EnemyCount = tempCount;
            Management.frontEnemy_count = temp2Count;
            Destroy(this.gameObject);
        }
        
    }
}
