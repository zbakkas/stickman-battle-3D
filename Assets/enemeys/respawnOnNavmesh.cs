using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class respawnOnNavmesh : MonoBehaviour
{
   // public GameObject objectToRespawn;  // The object to respawn
   // public float respawnDelay = 5f;     // Delay between respawns

    private NavMeshTriangulation navMeshData;  // NavMesh data
    private Bounds navMeshBounds;               // Bounds of the NavMesh

    private void Start()
    {
        // Start the respawn coroutine
        //StartCoroutine(RespawnObject());
    }
    /*
    private IEnumerator RespawnObject()
    {
        while (true)
        {
            // Wait for the specified delay before respawning
            yield return new WaitForSeconds(respawnDelay);

            // Generate a random position within the NavMesh bounds
            Vector3 randomPosition = GetRandomNavMeshPosition();

            // Instantiate the object at the random position
            Instantiate(objectToRespawn, randomPosition, Quaternion.identity);
        }
    }
    */
    public Vector3 GetRandomNavMeshPosition()
    {
        // Get the NavMesh data
        navMeshData = NavMesh.CalculateTriangulation();

        // Get the bounds of the NavMesh
        navMeshBounds = CalculateNavMeshBounds(navMeshData);

        // Generate a random position within the NavMesh bounds
        Vector3 randomPoint = new Vector3(
            Random.Range(navMeshBounds.min.x, navMeshBounds.max.x),
            Random.Range(navMeshBounds.min.y, navMeshBounds.max.y),
            Random.Range(navMeshBounds.min.z, navMeshBounds.max.z)
        );

        // Sample the closest point on the NavMesh
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, navMeshBounds.size.magnitude * 0.1f, NavMesh.AllAreas))
        {
            return hit.position;
        }

        // If a valid point couldn't be found, return the original random point
        return randomPoint;
    }

    private Bounds CalculateNavMeshBounds(NavMeshTriangulation navMeshData)
    {
        Bounds bounds = new Bounds(navMeshData.vertices[0], Vector3.zero);
        for (int i = 1; i < navMeshData.vertices.Length; i++)
        {
            bounds.Encapsulate(navMeshData.vertices[i]);
        }
        return bounds;
    }
}
