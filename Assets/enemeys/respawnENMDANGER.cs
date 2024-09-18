using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnENMDANGER : MonoBehaviour
{
    public GameObject[] enemesarray;
    private respawnOnNavmesh responinnav;
    public int namperenemey;
    private rsowanEnemeys animyArray;
    public float timer;
    private float timer2;
    public GameObject fix;
    private Vector3[] vv;

    public AudioClip watning;
    public AudioSource audioo;
    public GameObject warning;
    // Start is called before the first frame update
    void Start()
    {
        responinnav = gameObject.GetComponent<respawnOnNavmesh>();
        animyArray = gameObject.GetComponent<rsowanEnemeys>();
        timer2 = timer;

        warning.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0 )
        {
            timer= timer-1*Time.deltaTime;
        }
        if (timer<=0)
        {
            warning.SetActive(true);
            audioo.clip = watning;
            audioo.Play();
            if(animyArray.levelplayer<enemesarray.Length)
            {
                SpawnEnemies(fix, namperenemey);
                int nnnn = Random.Range(animyArray.levelplayer + 5, animyArray.levelplayer + 10);
                
                StartCoroutine(rr(enemesarray[nnnn], namperenemey));
                
                    
            }
            else
            {
                SpawnEnemies(fix, namperenemey);
                int nnnn = Random.Range(animyArray.levelplayer , enemesarray.Length);
                StartCoroutine(rr(enemesarray[nnnn], namperenemey));
            }
           
            timer = timer2;
        }
    }


    private void SpawnEnemies(GameObject fixPrefab, int numEnemies)////enemey1==>5mrat
    {

        vv = new Vector3[numEnemies];
        for (int i = 0; i < numEnemies; i++)
        {
            // Instantiate the enemy prefab at a random position
            //Vector3 spawnPosition = new Vector3(Random.Range(-15f, 15f), 0f, Random.Range(-10f, 10f));
            Vector3 randomPosition = responinnav.GetRandomNavMeshPosition();
            Instantiate(fixPrefab, randomPosition, Quaternion.identity);
            vv[i] = randomPosition;
        }


    }
    public void responenemey(GameObject enemeybre, int numEnemies)
    {
        for (int i = 0; i < numEnemies; i++)
        {
            // Instantiate the enemy prefab at a random position
            //Vector3 spawnPosition = new Vector3(Random.Range(-15f, 15f), 0f, Random.Range(-10f, 10f));
            Vector3 randomPosition = responinnav.GetRandomNavMeshPosition();
            Instantiate(enemeybre, vv[i], Quaternion.identity);
            
        }
    }


    IEnumerator rr(GameObject pe,int intt)
    {
        yield return new WaitForSeconds(1.3f);
        
       
       responenemey(pe, intt);
        warning.SetActive(false);
        audioo.clip = null;
        vv = new Vector3[0];
    }
}
