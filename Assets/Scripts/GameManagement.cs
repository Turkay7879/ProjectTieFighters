using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public string Difficulty;
    public float EnemySpeed = 2.5f;
    public int Lives = 3, EnemyCount;
    GameObject EnemyGroup;

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
            Invoke("CreateEnemies", 2.0f);
        }
            
    }

    public void CreateEnemies()
    {
        GameObject Group1Prefab = (GameObject)Resources.Load("Group1", typeof(GameObject));
        EnemyGroup = Instantiate(Group1Prefab, new Vector3(0f, 6f, -1.89f), Quaternion.identity);
        EnemyCount = 7;
        CancelInvoke();
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
}
