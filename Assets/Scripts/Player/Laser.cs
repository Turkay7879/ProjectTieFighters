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

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = GameObject.Find(collision.name);
        if ((collision.tag.Equals("Enemy1") || collision.tag.Equals("Enemy2") || collision.tag.Equals("Enemy3")) && !obj.GetComponent<EnemySpaceship>().isShot)
        {

            obj.GetComponent<EnemySpaceship>().isShot = true;
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

            float scaleX = obj.transform.localScale.x;
            float scaleY = obj.transform.localScale.y;
            obj.transform.localScale = new Vector3(scaleX*2.5f, scaleY*2.5f, -1.89f);
            obj.GetComponent<EnemySpaceship>().anim.Play("Explode");
            Destroy(obj, 0.417f);
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
            Invoke("DewIt", 1.5f);
        }

        else if (collision.tag.Equals("Bonus"))
        {
            if (collision.name.Contains("Star"))
            {
                // Skoru artir ve ekrana yaz
            }

            else if (collision.name.Contains("Heart"))
            {
                int NewLife = Management.Lives;
                NewLife++;
                Management.Lives = NewLife;
                Management.LifeText.GetComponent<UnityEngine.UI.Text>().text = ": " + NewLife.ToString();
            }

            Destroy(obj);
        }
    }

    void DewIt()
    {
        Destroy(gameObject);
    }
}
