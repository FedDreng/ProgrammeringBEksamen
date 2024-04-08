using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed;

    Rigidbody2D rb;

    float Vertical;
    float Horizontal;
    float CharacterDirX;
    float CharacterDirY;

    Vector2 movement;

    Animator anim;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        CharacterDirection();
        AnimationUpdate();

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
        movement = new Vector2(Horizontal, Vertical).normalized;

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = movement * speed;
    }

    void AnimationUpdate()
    {
        anim.SetFloat("X_walk", rb.velocity.x);
        anim.SetFloat("Y_walk", rb.velocity.y);

        anim.SetFloat("X_idle", CharacterDirX);
        anim.SetFloat("Y_idle", CharacterDirY);

        if (rb.velocity.magnitude > 0)
        {
            anim.SetBool("isWalking", true);
        }

        else
        {
            anim.SetBool("isWalking", false);
        }

        if (rb.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (rb.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    void CharacterDirection()
    {
        if (Horizontal > 0)
        {
            CharacterDirX = 1;
            CharacterDirY = 0;
        }
        else if (Horizontal < 0)
        {
            CharacterDirX = -1;
            CharacterDirY = 0;
        }

        if (Vertical > 0)
        {
            CharacterDirY = 1;
            CharacterDirX = 0;
        }
        else if (Vertical < 0)
        {
            CharacterDirY = -1;
            CharacterDirX = 0;
        }
    }
}