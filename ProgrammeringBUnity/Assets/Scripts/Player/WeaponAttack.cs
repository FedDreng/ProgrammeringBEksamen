using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().health--;

            if (collision.gameObject.GetComponent<Enemy>().health <= 0)
            {
                Destroy(collision.gameObject);
            }

            Debug.Log("i hit " + collision.gameObject.GetComponent<Enemy>().enemyType);
        }
    }
}
