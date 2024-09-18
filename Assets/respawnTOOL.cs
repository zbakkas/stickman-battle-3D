using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnTOOL : MonoBehaviour
{
    public GameObject[] tools;
    private respawnOnNavmesh responinnav;
    public float timer;
    float timer2;
    // Start is called before the first frame update
    void Start()
    {
        responinnav = gameObject.GetComponent<respawnOnNavmesh>();
        respantols();
        timer2 = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer = timer - 1 * Time.deltaTime;
        }
        if (timer <= 0)
        {
            respantols();
            timer = timer2;
        }
    }

    public void respantols()
    {
        for (int x = 0; x < tools.Length; x++)
        {
            for (int i = 0; i < Random.Range(1, 3); i++)
            {
                Vector3 randomPosition = responinnav.GetRandomNavMeshPosition();
                randomPosition.y =  randomPosition.y + 0.5f;
                Instantiate(tools[x], randomPosition, Quaternion.identity);
            }
        }
        
      
    }
}
