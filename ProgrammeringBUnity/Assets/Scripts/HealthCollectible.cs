using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<PlayerHealth>().playerHealth <= 2)
        {
            collision.gameObject.GetComponent<PlayerHealth>().playerHealth++;
            collision.gameObject.GetComponent<PlayerHealth>().HealthUpdate();
            Destroy(this.gameObject);
        }
    }
}
