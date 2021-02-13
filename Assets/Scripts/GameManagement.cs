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
        // Ge�ici, kullan�c�n�n se�imine b�rak�lacak
        Difficulty = "Easy";
        //Difficulty = "Medium";
        //Difficulty = "Hard";
        GameObject Group1Prefab = (GameObject)Resources.Load("Group1", typeof(GameObject));
        EnemyGroup = Instantiate(Group1Prefab, new Vector3(0f, 6f, -1.89f), Quaternion.identity); // �rnek koordinatlar
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
        // Instantiate ile d��manlar� olu�tur
        // y ve x koordinatlar� aras�nda minimum 1.5f fark olmal� (Birbirleriyle �ak��mamalar� i�in)
        // x koordinatlar� aras�ndaki fark d��man say�s�na ba�l� de�i�ebilir
        // Max. s�n�r y = 7.5, daha fazlas� ekran�n d���na ��kabilir (Ekran s�n�r� collider� ile �ak��ma durumu)
        // z koordinat� -1.89, fix
    }

    public void EasyMode()
    {
        if (EnemyCount == 0) {
            // Oyunun en ba��ndaysak veya t�m d��manlar yok edildiyse yeni d��man grubu olu�turulmal�
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
