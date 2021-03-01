using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    GameManagement Management;
    public AudioSource audioSrc;

    void Start()
    {
        Management = GameObject.Find("GameManagement").GetComponent<GameManagement>();
        audioSrc = GameObject.Find("Explosion").GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy1") || collision.tag.Equals("Enemy2") || collision.tag.Equals("Enemy3"))
        {
            audioSrc.Play();
            gameObject.transform.localScale = new Vector2(0, 0);
            int tempScore = Management.Score;
            if (collision.tag.Equals("Enemy1"))
                tempScore += 1;
            else if (collision.tag.Equals("Enemy2"))
                tempScore += 3;
            else
                tempScore += 5;
            Management.Score = tempScore;
            Management.ScoreText.GetComponent<UnityEngine.UI.Text>().text = ": " + Management.Score.ToString();

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
            Invoke("DewIt", 1.0f);
        }
        
    }

    void DewIt()
    {
        Destroy(gameObject);
    }
}
