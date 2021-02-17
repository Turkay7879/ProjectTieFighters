using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceship : MonoBehaviour
{
    public float laserSpeed = 10.0f;
    public Rigidbody2D rb;
    public float Speed = 2.00f; //magnitude of speed can be changed
    public float MoveTime = 2.00f;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(EnemyMove(0));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))   // F ye basýnca düþmanlarýn hepsi ateþ eder
        {
            Invoke("EnemyFire", 0);
        }
    }

    public IEnumerator EnemyMove(float time)
    {   // MoveTime ve Speed orantýlý olmalýdýr. Aksi halde düþmanlar ekranýn dýþýna çýkabilir.
        StartingMove:
        rb.velocity = Vector2.left * Speed;
        yield return new WaitForSeconds(MoveTime);
        rb.velocity = Vector2.right * Speed;
        yield return new WaitForSeconds(MoveTime * 2);
        rb.velocity = Vector2.left * Speed;
        yield return new WaitForSeconds(MoveTime);
        goto StartingMove; 
    }

    public void EnemyFire()
    {
        GameObject laser2 = (GameObject)Resources.Load("Laser2", typeof(GameObject));
        GameObject enemylaser = Instantiate(laser2, new Vector3(transform.position.x, transform.position.y - 1.075f, 0), Quaternion.identity);
        enemylaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserSpeed);
    }
}
