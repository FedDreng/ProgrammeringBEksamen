using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Vi laver en integer der styrer fjendens liv
    [SerializeField] int Health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Hvis vores fjende kommer i kontakt med en collider med tagget "Weapon", mister den 1 liv.
        // Hvis vores fjende ikke har flere liv bliver gameobjectet fjernet.
        if (collision.CompareTag("Weapon"))
        {
            Health--;

            if(Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
