using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpaceship : MonoBehaviour
{
    public float laserSpeed = 10.0f;
    public Rigidbody2D rb;
    public float Speed = 2.00f; 
    public float MoveTime = 2.00f;
    private bool isCollided = false;
    public bool isFront = false;
    private GameManagement Management;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Management = GameObject.Find("GameManagement").GetComponent<GameManagement>();
        StartCoroutine(EnemyMove());
    }

    void Update()
    {
        if (!Management.GameDiff.Equals("Easy"))
        {
            transform.position += Vector3.down * Time.deltaTime * 0.50f;
        }
    }

    // Pause ekrani icin Time.timeScale = 0.0f yapildiginda bu coroutine iptal oluyor, duzeltilecek
    public IEnumerator EnemyMove()
    {  
            StartingMove:
            rb.velocity = Vector2.left * Speed;
            yield return new WaitForSeconds(MoveTime);
            rb.velocity = Vector2.right * Speed;
            yield return new WaitForSeconds(MoveTime * 2);
            rb.velocity = Vector2.left * Speed;
            yield return new WaitForSeconds(MoveTime);
            goto StartingMove; 
    }


    public void EnemyFire(int ID)
    {
        if (gameObject.tag.Equals("Enemy1") && (isFront || !isCollided))
        {
            GameObject laser = (GameObject)Resources.Load("Prefabs\\Laser1", typeof(GameObject));
            GameObject enemylaser = Instantiate(laser, new Vector3(transform.position.x, transform.position.y - 1.326f, 0), Quaternion.identity);
            enemylaser.name = "EnemyLsr" + ID.ToString();
            enemylaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserSpeed); 
        }
        
        if (gameObject.tag.Equals("Enemy2") && (isFront || !isCollided)) {
            GameObject laser2 = (GameObject)Resources.Load("Prefabs\\Laser2", typeof(GameObject));
            GameObject enemylaser = Instantiate(laser2, new Vector3(transform.position.x, transform.position.y - 1.344f, 0), Quaternion.identity);
            enemylaser.name = "EnemyLsr" + ID.ToString();
            enemylaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserSpeed);
        }
        
        if (gameObject.tag.Equals("Enemy3") && (isFront || !isCollided))
        {
            GameObject laser3 = (GameObject)Resources.Load("Prefabs\\Laser3", typeof(GameObject));
            GameObject enemylaser = Instantiate(laser3, new Vector3(transform.position.x - 0.421f, transform.position.y - 0.974f, 0), Quaternion.identity);
            GameObject enemylaser2 = Instantiate(laser3, new Vector3(transform.position.x + 0.421f, transform.position.y - 0.974f, 0), Quaternion.identity);
            enemylaser.name = "EnemyLsr" + ID.ToString();
            enemylaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserSpeed);
            enemylaser2.name = "EnemyLsr" + (ID + 1).ToString();
            enemylaser2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserSpeed);
        }
        isCollided = false;
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy1") || collision.CompareTag("Enemy2") || collision.CompareTag("Enemy3"))
        {
            isCollided = true;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy1") || collision.CompareTag("Enemy2") || collision.CompareTag("Enemy3"))
        {
            isCollided = true;
        }
    }
}
