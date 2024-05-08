using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Vi sætter alle variablerne til vores bevægelse af spilleren.
    private float Vertical;
    private float Horizontal;
    private float speed;

    private Vector2 movement;
    private Vector2 movementDir;

    //Vi laver variabler til de components vi skal bruge fra vores gameobject.
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer spriteRenderer;

    int playerHealth;

    // vi laver 2 float variabler der skal styre hvor lang tid der skal gå mellem hvert angreb.
    [SerializeField] float timeBetweenAttack;
    private float attackTimeCounter;

    // Start is called before the first frame update
    void Start()
    {
        //Vi henter componenterne fra vores gameobject til deres variabler
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerHealth = gameObject.GetComponent<PlayerHealth>().playerHealth;
    }

    private void Update()
    {
        //Hvis spilleren holder LeftShift nede, vil karakteren få en ny "speed" værdi og bevæge sig hurtigere
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 4.5f;
        }
        else
        {
            speed = 3f;
        }

        //attackTimeCounter får en værdi der er ligmed så lang tid der er gået.
        attackTimeCounter += Time.deltaTime;

        /*hvis man klikker på venstreklik, bliver attackfunktionen spillet
        hvis attacTimeCounter er højere eller ligmed timeBetween Attack */
        if (Input.GetKeyDown(KeyCode.Mouse0) && attackTimeCounter >= timeBetweenAttack)
        {   
            Attack();
        }

        // vi laver en normaliseret vektor baseret på hvilken retning spilleren prøver at bevæge sig
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        movement = new Vector2(Horizontal, Vertical).normalized;

        // Hvis spilleren ikke står stille tager vi retningen af spilleren og gemmer i en anden variabel, så vi kan se hvilken retning spilleren burde pege i
        if (movement != Vector2.zero)
        {
            movementDir = movement;
        }

        //vi opdatere vores animation af spilleren
        AnimationUpdate();  
    }

    // Vi sætter en velocity på vores spiller til at være deres retning ganget med "speed" variablen der styrer vores hastighed
    void FixedUpdate()
    {
        rb.velocity = movement * speed;
    }

    //Attack() funktionen får sætter en trigger til at være sand, så spilleren slår
    void Attack()
    {
        attackTimeCounter = 0;
        anim.SetTrigger("Attack");
    }

    //FreezePlayer() funktionen låser spilleren, så man ikke kan bevæge sig.
    public void FreezePlayer()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        rb.velocity = Vector2.zero;
    }

    //Death() funktionen loader scenen "Level" for at starte spillet forfra.
    public void Death()
    {
        SceneManager.LoadScene("Level");
    }

    // AnimationUpdate() funktionen styrer hvilken animation der burde spille.
    void AnimationUpdate()
    {
        // vi sætter 2 floats i vores animator til at være ligmed retningen af vores spiller i x og y værdien.
        anim.SetFloat("X_Dir", movementDir.x);
        anim.SetFloat("Y_Dir", movementDir.y);

        // vi tjekker om vores spiller bevæger sig, for at finde ud af om gå animationen skal spille.
        if (rb.velocity.magnitude > 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        // vi tjekker hvilken retning spilleren bevæger sig for at beslutte om vores sprite skal flippes.
        if (movementDir.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (movementDir.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

}