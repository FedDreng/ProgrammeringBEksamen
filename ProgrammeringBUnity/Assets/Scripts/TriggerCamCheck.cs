using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCamCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            this.gameObject.GetComponentInParent<MoveCamAndSpawnEnemies>().MoveCam(Int32.Parse(this.gameObject.name));
        }
    }
}
