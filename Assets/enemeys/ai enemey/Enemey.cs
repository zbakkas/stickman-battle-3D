using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class Enemey : MonoBehaviour
{
    public float radus=20;
   public bool debugbool;
    NavMeshAgent my_agent;
    Vector3 nexte_p;
    private enemeyKiller enK;

    private Transform player;
    private void Start()
    {
        
        my_agent = GetComponent<NavMeshAgent>();
        nexte_p = transform.position;
        player = GameObject.Find("player").transform;
        enK = gameObject.GetComponent<enemeyKiller>();
    }

    private void Update()
    {
        if (Vector3.Distance(nexte_p, transform.position) <= 1.5f&&my_agent.speed>0)
        {
            nexte_p = cc.R_point(transform.position, radus);
            my_agent.SetDestination(nexte_p);

        }
        else if (my_agent.speed <=0&&!enK.anim.GetBool("dead"))
        {
            Vector3 directionToPlayer =   player.position -transform.position ;
            directionToPlayer.y = 0f; // Set the Y component to zero to ignore vertical rotation

            // Calculate the target rotation based on the direction
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

            // Smoothly rotate the enemy towards the player
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 9 * Time.deltaTime);

        }
    }



    private void OnDrawGizmos()
    {
        if (debugbool)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position,nexte_p);
        }
    }


}