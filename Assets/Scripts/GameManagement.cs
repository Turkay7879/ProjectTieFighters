using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    public string GameDiff;
    public float EnemySpeed = 2.5f;
    public int Lives = 3, Score = 0, EnemyCount = 0, LaserID = 0;
    GameObject EnemyGroup1, EnemyGroup2, gameOver, tryAgain, yesButton, noButton;
    private float FireDelay = 0.75f, FireInterval = 1.00f;
    private bool StartedFiring = false;
    public int frontEnemy_count;
    public Text ScoreText;
    public Text LifeText;

    void Start()
    {
        Time.timeScale = 1.0f;
        gameOver = GameObject.Find("GameOver");
        gameOver.SetActive(false);
        tryAgain = GameObject.Find("TryAgain");
        tryAgain.SetActive(false);
        yesButton = GameObject.Find("Yes");
        yesButton.SetActive(false);
        noButton = GameObject.Find("No");
        noButton.SetActive(false);

        GameDiff = Difficulty.UsrDifficulty;
        if (GameDiff.Equals("") || GameDiff == null)
            GameDiff = PlayerPrefs.GetString("Difficulty");
        Debug.Log("Hebele --> " + GameDiff);
        ScoreText = GameObject.Find("Score").GetComponent<Text>();
        LifeText = GameObject.Find("Lives").GetComponent<Text>();
        CreateEnemies();
    }
    
    void Update()
    {
        if (EnemyCount == 0)
        {
            GameObject.Destroy(EnemyGroup1);
            GameObject.Destroy(EnemyGroup2);
            Invoke("CreateEnemies", 2.0f);
        }

        if (!StartedFiring)
        {
            InvokeRepeating("randomFire", FireDelay, FireInterval);
            StartedFiring = true;
        }
    }

    public void CreateEnemies()
    {   
        if (GameDiff.Equals("Easy"))
        {
            CreateGroups("Group1", "Group1", 6.0f, 4.5f, 7);
            frontEnemy_count = 7;
        }
        else if (GameDiff.Equals("Medium"))
        {
            CreateGroups("Group2", "Group2", 6.0f, 3.9f, 7);
            frontEnemy_count = 7;
        }
        else
        {
            CreateGroups("Group2", "Group3", 6.0f, 3.7f, 5);
            frontEnemy_count = 5;
        }
        CancelInvoke();
        StartedFiring = false;
    }

    public void randomFire()
    {
        bool equality = false;
        int num1=0;
        int num2=0;
        int num3=0;
        while (equality == true)
        {
            num1 = Random.Range(7, 14);
            num2 = Random.Range(7, 14);
            num3 = Random.Range(7, 14);
            if(num1 == num2 || num2 == num3 || num1 == num3)
            {
                equality = true;
            }
            else
            {
                equality = false;
            }
        }

        if (frontEnemy_count <= 3)
        {
            while (equality == true)
            {
                num1 = Random.Range(0, 14);
                num2 = Random.Range(0, 14);
                num3 = Random.Range(0, 14);
                if(num1 == num2 || num2 == num3 || num1 == num3)
                {
                    equality = true;
                }
                else
                {
                    equality = false;
                }
            }
        }

        GameObject ship1 = GameObject.Find("Enemy" + num1.ToString());
        GameObject ship2 = GameObject.Find("Enemy" + num2.ToString());
        GameObject ship3 = GameObject.Find("Enemy" + num3.ToString());

        if (ship1 != null)
        {
            ship1.GetComponent<EnemySpaceship>().EnemyFire(LaserID);
            LaserID++;
        }

        if (ship2 != null)
        {
            ship2.GetComponent<EnemySpaceship>().EnemyFire(LaserID);
            LaserID++;
        }

        if (ship3 != null)
        {
            ship3.GetComponent<EnemySpaceship>().EnemyFire(LaserID);
            LaserID++;
        }

    }

    void CreateGroups(string grup_adi1, string grup_adi2, float y1, float y2, int count)
    {
        GameObject Group1Prefab = (GameObject)Resources.Load(grup_adi1, typeof(GameObject));
        EnemyGroup1 = Instantiate(Group1Prefab, new Vector3(0f, y1, -1.89f), Quaternion.identity);
        for (int i = 0; i < 7; i++)
        {
            GameObject.Find(grup_adi1 + "-" + i.ToString()).name = "Enemy" + EnemyCount.ToString();
            EnemyCount++;
        }
        GameObject Group2Prefab = (GameObject)Resources.Load(grup_adi2, typeof(GameObject));
        EnemyGroup2 = Instantiate(Group2Prefab, new Vector3(0f, y2, -1.89f), Quaternion.identity);
        for (int i = 0; i < count; i++)
        {
            GameObject tempShip = GameObject.Find(grup_adi2 + "-" + i.ToString());
            tempShip.name = "Enemy" + EnemyCount.ToString();
            tempShip.GetComponent<EnemySpaceship>().isFront = true;
            EnemyCount++;
        }
    }

    public void EndGame()
    {
        PlayerPrefs.SetString("Difficulty", GameDiff);
        PlayerPrefs.Save();
        Time.timeScale = 0f;
        GameObject.Destroy(EnemyGroup1);
        GameObject.Destroy(EnemyGroup2);
        gameOver.SetActive(true);
        tryAgain.SetActive(true);
        yesButton.SetActive(true);
        noButton.SetActive(true);
    }
}
