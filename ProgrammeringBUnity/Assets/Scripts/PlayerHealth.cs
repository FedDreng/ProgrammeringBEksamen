using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;
    [SerializeField] Sprite[] HealthBar;
    [SerializeField] GameObject healthBarUI;

    private void Start()
    {
        HealthUpdate();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerHealth--;
            HealthUpdate();
        }
    }

    void HealthUpdate()
    {
        switch (playerHealth)
        {
            case 0:
            healthBarUI.GetComponent<Image>().sprite = HealthBar[playerHealth];
                break;

            case 1:
                healthBarUI.GetComponent<Image>().sprite = HealthBar[playerHealth];
                break;

            case 2:
                healthBarUI.GetComponent<Image>().sprite = HealthBar[playerHealth];
                break;

            case 3:
                healthBarUI.GetComponent<Image>().sprite = HealthBar[playerHealth];
                break;
        }
    }
}
