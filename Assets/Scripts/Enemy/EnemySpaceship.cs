using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceship : MonoBehaviour
{
    public float laserSpeed = 10.0f;
    public Rigidbody2D rb;
    public float Speed = 2.00f; 
    public float MoveTime = 2.00f;
    private bool isCollided = false;
    public bool isFront = false;
    GameManagement Management;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(EnemyMove(0));
        Management = GameObject.Find("GameManagement").GetComponent<GameManagement>();
    }

    void Update()
    {
        if (!Management.GameDiff.Equals("Easy"))
        {
            transform.position += Vector3.down * Time.deltaTime * 0.50f;
        }
    }

    public IEnumerator EnemyMove(float time)
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
        GameObject laser2 = (GameObject)Resources.Load("Laser2", typeof(GameObject));
        if (this.gameObject.tag.Equals("Enemy1") && (isFront || !isCollided))
        {
            GameObject enemylaser = Instantiate(laser2, new Vector3(transform.position.x, transform.position.y - 1.075f, 0), Quaternion.identity);
            enemylaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserSpeed);
            enemylaser.name = "EnemyLsr" + ID.ToString();
        }
        
        if (this.gameObject.tag.Equals("Enemy2") && (isFront || !isCollided)) { 
            GameObject enemylaser = Instantiate(laser2, new Vector3(transform.position.x, transform.position.y - 1.244f, 0), Quaternion.identity);
            enemylaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserSpeed);
            enemylaser.name = "EnemyLsr" + ID.ToString();
        }
        
        if (this.gameObject.tag.Equals("Enemy3") && (isFront || !isCollided))
        {
            GameObject enemylaser = Instantiate(laser2, new Vector3(transform.position.x - 0.8235f, transform.position.y - 1.31994f, 0), Quaternion.identity);
            GameObject enemylaser2 = Instantiate(laser2, new Vector3(transform.position.x + 0.8235f, transform.position.y - 1.31994f, 0), Quaternion.identity);
            enemylaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserSpeed);
            enemylaser.name = "EnemyLsr" + ID.ToString();
            enemylaser2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserSpeed);
            enemylaser.name = "EnemyLsr" + (ID+1).ToString();
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
