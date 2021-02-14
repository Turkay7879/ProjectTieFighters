using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public string Difficulty;
    public float EnemySpeed = 2.5f;
    public int Lives = 3, EnemyCount;
    GameObject EnemyGroup;
    private float FireDelay = 0.75f, FireInterval = 1.00f;
    private bool StartedFiring = false;

    // Start is called before the first frame update
    void Start()
    {
        // Geçici, kullanýcýnýn seçimine býrakýlacak
        Difficulty = "Easy";
        //Difficulty = "Medium";
        //Difficulty = "Hard";
        GameObject Group1Prefab = (GameObject)Resources.Load("Group1", typeof(GameObject));
        EnemyGroup = Instantiate(Group1Prefab, new Vector3(0f, 6f, -1.89f), Quaternion.identity); // Örnek koordinatlar
        EnemyCount = 7;
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyCount == 0)
        {
            GameObject.Destroy(EnemyGroup);
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
        GameObject Group1Prefab = (GameObject)Resources.Load("Group1", typeof(GameObject));
        EnemyGroup = Instantiate(Group1Prefab, new Vector3(0f, 6f, -1.89f), Quaternion.identity);
        EnemyCount = 7;
        CancelInvoke();
        StartedFiring = false;
        // Instantiate ile düþmanlarý oluþtur
        // y ve x koordinatlarý arasýnda minimum 1.5f fark olmalý (Birbirleriyle çakýþmamalarý için)
        // x koordinatlarý arasýndaki fark düþman sayýsýna baðlý deðiþebilir
        // Max. sýnýr y = 7.5, daha fazlasý ekranýn dýþýna çýkabilir (Ekran sýnýrý colliderý ile çakýþma durumu)
        // z koordinatý -1.89, fix
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

    }

    public void HardMode()
    {

    }

    public void randomFire()
    {
        int num1 = Random.Range(0, 7);
        int num2 = Random.Range(0, 7);
        int num3 = Random.Range(0, 7);

        GameObject ship1 = GameObject.Find("Group1-" + num1.ToString());
        GameObject ship2 = GameObject.Find("Group1-" + num2.ToString());
        GameObject ship3 = GameObject.Find("Group1-" + num3.ToString());


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

}
