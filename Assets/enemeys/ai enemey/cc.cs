using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class cc : MonoBehaviour
{

    public static Vector3 R_point(Vector3 start_p, float radius)
    {
        Vector3 dir = Random.insideUnitSphere * radius;
        dir += start_p;
        NavMeshHit hit;
        Vector3 final_p = Vector3.zero;
        if (NavMesh.SamplePosition(dir, out hit, radius, 1))
        {
            final_p = hit.position;
        }

        return final_p;
    }
}
