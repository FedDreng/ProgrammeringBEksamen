using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FriendAIPathfinding : MonoBehaviour
{
    private bool TalkingToPlayerHasChanged = false;
    public bool TalkingToPlayer = false;

    //Variabler tilg�nglig i unity scenen, dog IKKE public
    [SerializeField] int WalkSpeed;
    [SerializeField] int WaitTime;
    [SerializeField] Vector3[] Waypoints;

    [SerializeField] GameObject ChatPrefab;


    private void Awake()
    {
        //Starter pathfinding n�r objektet "v�gner" eller starter
        StartCoroutine(MoveNPCFunc());
    }


    void Update()
    {
        if (TalkingToPlayer)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                print("did thing!");
                TalkingToPlayer = false;
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().canAttack = true;
                Destroy(transform.GetChild(1).gameObject);
            }
        }

        if (TalkingToPlayerHasChanged)
        {
            if (!TalkingToPlayer)
            {
                StartCoroutine(MoveNPCFunc());
                TalkingToPlayerHasChanged = false;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        //Alt inde i denne funktion sker n�r at de highlighter objektet i unity hierachy

        for (int i = 0; i < Waypoints.Length; i++)
        {
            //Alt der sker inde i dette forloop/if statement er bare at vi g�r igennem alle waypoint punkter og tegner dem til unity editoren
            //Udover det s� bliver punkterne ogs� en smule mere synlige for hver iteration/hvert punkt t�ttere p� det sidste (det sidste punkt bliver gr�nt)
            if (i == Waypoints.Length - 1)
            {
                Gizmos.color = Color.green;
            } else
            {
                Gizmos.color = new Color(1, 0, 0, (((i + 1.4f / Waypoints.Length) / Waypoints.Length * 1.1f) + 0.2f) / 2 + 0.3f);
            }
            Gizmos.DrawSphere(Waypoints[i], 0.2f);
        }
    }



    IEnumerator MoveNPCFunc()
    {

        while (!TalkingToPlayer)
        {
            for (int i = 0; i < Waypoints.Length; i++)
            {
                if (TalkingToPlayer)
                {
                    break;
                }

                //Vi f�r distancen mellem vores waypoint og vores position
                float Distance = Vector3.Distance(Waypoints[i], transform.position);

                //Formlen for hastighed er f�lgende:
                //v = delta_s / delta_t
                //Vi �ndre formlen til at give forskellen i tid med hastighed og distance:
                //delta_t = delta_s / v
                float TimeToWalk = Distance / WalkSpeed;

                //Her bruger vi LeanTween fra unity market, som g�r at spilleren bev�ger sig til et punkt over en bestemt m�ngde tid (tweening)
                transform.LeanMoveLocal(Waypoints[i], TimeToWalk);

                //Sidst venter vi indtil spilleren er ankommet ved at bruge vores TimeToWalk variabel, og tilf�jer en ekstra ventetid til at st� stille
                yield return new WaitForSeconds(TimeToWalk);
                yield return new WaitForSeconds(WaitTime);

            }
        }

        //Hvis ovesnt�ende while loop stopper kan vi antage at spilleren snakker med AI
        TalkingToPlayerHasChanged = true;

        //(Unity forum sagde at yield return null skulle g�re s�dan unity ikke crashede)
        yield return null;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E) && TalkingToPlayer == false)
            {
                print("chatted w/ player");
                TalkingToPlayer = true;
                Instantiate(ChatPrefab, this.transform);
            }
        }
    }
}
