using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceship : MonoBehaviour
{
    public float Speed = 10.0f;
    Vector2 position;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed, 0);
    }

    void Fire()
    {

    }
}
