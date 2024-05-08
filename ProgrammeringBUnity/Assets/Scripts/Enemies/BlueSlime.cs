using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSlime : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        health = 2;
        Damage = 1;
        enemyType = "BlueSlime";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Fuck my life");
            collision.gameObject.GetComponent<PlayerHealth>().playerHealth = collision.gameObject.GetComponent<PlayerHealth>().playerHealth - Damage;
            collision.gameObject.GetComponent<PlayerHealth>().HealthUpdate();
        }
    }
}
