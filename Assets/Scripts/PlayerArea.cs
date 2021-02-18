using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArea : MonoBehaviour
{
    GameManagement gameManagement;
    void Start()
    {
        gameManagement = GameObject.Find("GameManagement").GetComponent<GameManagement>();   
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Laser"))
        {
            int newLives = gameManagement.Lives;
            newLives--;
            gameManagement.Lives = newLives;
            Destroy(GameObject.Find(collision.name));
        }
    }
}
