using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;
    private Animator anim;
    [SerializeField] Sprite[] HealthBar;
    [SerializeField] GameObject healthBarUI;

    private void Start()
    {
        HealthUpdate();
        anim = GetComponent<Animator>();
    }

   // i funktionen bliver der bestemt hvilket healthbar_UI billede der skal bruges, an på hvor meget liv spilleren har.
    public void HealthUpdate()
    {
        switch (playerHealth)
        {
            default:
            healthBarUI.GetComponent<Image>().sprite = HealthBar[0];
                // hvis spilleren har 0 liv, starter "døds animationen".
                anim.SetTrigger("Dead");
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
