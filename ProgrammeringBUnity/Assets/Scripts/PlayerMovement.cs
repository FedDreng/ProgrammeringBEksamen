using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed;

    Rigidbody2D rb;

    float Vertical;
    float Horizontal;
    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 4.5f;
        }
        else
        {
            speed = 3f;
        }

        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        movement = new Vector2 (Horizontal, Vertical).normalized;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = movement * speed;
    }

}