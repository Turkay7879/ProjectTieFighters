using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceship : MonoBehaviour
{
    public float Speed = 10.0f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
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
        // AddRelativeForce(), y ekseni pozisyonunu da etkiliyor?
        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);
        position.x = Mathf.Clamp01(position.x);
        transform.position = Camera.main.ViewportToWorldPoint(position);
    }

    void Fire()
    {

    }

    
}
