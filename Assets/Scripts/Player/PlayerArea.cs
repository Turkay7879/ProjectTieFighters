using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArea : MonoBehaviour
{
    GameManagement Management;
    void Start()
    {
        Management = GameObject.Find("GameManagement").GetComponent<GameManagement>();   
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Laser"))
        {
            Destroy(GameObject.Find(collision.name));
            int newLives = Management.Lives;
            newLives--;
            Management.Lives = newLives;
            Management.LifeText.GetComponent<UnityEngine.UI.Text>().text = ": " + newLives.ToString();
            if (newLives <= 0)
            {
                Management.LifeText.GetComponent<UnityEngine.UI.Text>().text = ": 0";
                Management.EndGame();
            }       
        }
    }
}
