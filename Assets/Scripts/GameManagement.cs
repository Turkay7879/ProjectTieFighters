using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public string Difficulty;
    public float EnemySpeed = 2.5f;
    public int Lives = 3, EnemyCount;
    GameObject EnemyGroup1, EnemyGroup2;
    private float FireDelay = 0.75f, FireInterval = 1.00f;
    private bool StartedFiring = false;
    public int frontEnemy_count;
    // Start is called before the first frame update
    void Start()
    {
        EnemyCount = 0;
        Difficulty = GetComponent<Difficulty>().GetDifficulty();
        if (Difficulty.Equals("Easy"))
            EasyMode();
        else if (Difficulty.Equals("Medium"))
            MediumMode();
        else
            HardMode();
    }

    // Update is called once per frame
    void Update()
    {
        if(Lives == 0)
        {
            Time.timeScale = 0;
        }

        if (EnemyCount == 0)
        {
            if (Difficulty.Equals("Easy"))
            {
                GameObject.Destroy(EnemyGroup1);
                GameObject.Destroy(EnemyGroup2);
                //GameManagement.Destroy(EnemyGroup2);
            }
               
            Invoke("CreateEnemies", 2.0f);
        }

        if (!StartedFiring)        // düþmanlarýn hepsi ayný anda periodik bir þekilde ateþ eder
        {
           
            InvokeRepeating("randomFire", FireDelay, FireInterval);
            StartedFiring = true;
            
        }
    }

    public void CreateEnemies()
    {   
        if (Difficulty.Equals("Easy"))
        {
            CreateGroups("Group1", "Group1", 7.5f, 6.0f, 7);
            frontEnemy_count = 7;
        }
        else if (Difficulty.Equals("Medium"))
        {
            CreateGroups("Group2", "Group2", 7.0f, 4.9f, 7);
            frontEnemy_count = 7;
        }
        else
        {
            CreateGroups("Group2", "Group3", 7.0f, 4.7f, 5);
            frontEnemy_count = 5;
        }
        CancelInvoke();
        StartedFiring = false;
    }

    public void EasyMode()
    {
        if (EnemyCount == 0) {
            // Oyunun en baþýndaysak veya tüm düþmanlar yok edildiyse yeni düþman grubu oluþturulmalý
            CreateEnemies();
        }
    }

    public void MediumMode()
    {
        if (EnemyCount == 0)
        {
            // Oyunun en baþýndaysak veya tüm düþmanlar yok edildiyse yeni düþman grubu oluþturulmalý
            CreateEnemies();
        }
    }

    public void HardMode()
    {
        if (EnemyCount == 0)
        {
            // Oyunun en baþýndaysak veya tüm düþmanlar yok edildiyse yeni düþman grubu oluþturulmalý
            CreateEnemies();
        }
    }

    public void randomFire()
    {
        int num1 = Random.Range(7, 14);
        int num2 = Random.Range(7, 14);
        int num3 = Random.Range(7, 14);

        if (frontEnemy_count <= 3)
        {
            num1 = Random.Range(0, 14);
            num2 = Random.Range(0, 14);
            num3 = Random.Range(0, 14);
        }

        GameObject ship1 = GameObject.Find("Enemy" + num1.ToString());
        GameObject ship2 = GameObject.Find("Enemy" + num2.ToString());
        GameObject ship3 = GameObject.Find("Enemy" + num3.ToString());

        if (ship1 != null)
        {
            ship1.GetComponent<EnemySpaceship>().EnemyFire();
        }

        if (ship2 != null)
        {
            ship2.GetComponent<EnemySpaceship>().EnemyFire();
        }

        if (ship3 != null)
        {
            ship3.GetComponent<EnemySpaceship>().EnemyFire();
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
}
