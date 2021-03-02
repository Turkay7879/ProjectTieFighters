using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArea : MonoBehaviour
{
    public GameManagement Management;
    public AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Laser") || collision.tag.Equals("Enemy2") || collision.tag.Equals("Enemy3"))
        {
            Destroy(GameObject.Find(collision.name));
            audioSource.Play();
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
