using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rsowanEnemeys : MonoBehaviour
{

    public GameObject[] enemesarray;
    public int totalEnemies = 10;
    public int levelplayer;
    public levelPlayer lv;
    public int numperEnemey;

    private respawnOnNavmesh responinnav;


    float[] vv;
    public int[] uniqueNumbers, counts;
    public int min, equall, max;
    public bool kil;


    // Start is called before the first frame update
    void Start()
    {

         responinnav = gameObject.GetComponent<respawnOnNavmesh>();
        
          SpawnEnemies(enemesarray[0], Mathf.RoundToInt(totalEnemies * 0.5f));

        for(int i=0;i< Mathf.RoundToInt(totalEnemies * 0.5f);i++)
       {
           SpawnEnemies(enemesarray[Random.Range(1, 4)], 1);
       }





   // CountObjectsWithSameTag();

    }

    // Update is called once per frame
    void Update()
    {
        levelplayer = lv.levell;

        GameObject[] objectsz = GameObject.FindGameObjectsWithTag("enemey");
        numperEnemey = objectsz.Length;


     

    }

    private void LateUpdate()
    {
        GameObject[] objectsz = GameObject.FindGameObjectsWithTag("enemey");
        if (min >= totalEnemies-10)////////////////////////////////////////
        {
            for (int i = 0; i < objectsz.Length; i++)
            {
                if (objectsz[i].GetComponent<enemeyKiller>().levelEnemy < levelplayer)
                {

                    Destroy(objectsz[i]);
                    break;
                }
            }
            CountObjectsWithSameTag();
        }
        if (kil)
        {
            CountObjectsWithSameTag();
            kil = false;
        }

       
    }
    private void SpawnEnemies(GameObject enemyPrefab, int numEnemies)////enemey1==>5mrat
    {
        for (int i = 0; i < numEnemies; i++)
        {
            // Instantiate the enemy prefab at a random position
            //Vector3 spawnPosition = new Vector3(Random.Range(-15f, 15f), 0f, Random.Range(-10f, 10f));
            Vector3 randomPosition = responinnav.GetRandomNavMeshPosition();
            Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        }
    }





    
    public void CountObjectsWithSameTag()
    {
        
            
        
        
        GameObject[] objects = GameObject.FindGameObjectsWithTag("enemey");

        Dictionary<int, int> countDict = new Dictionary<int, int>();

        vv = new float[objects.Length];
        for (int i = 0; i < objects.Length; i++)
        {
           vv[i]=  objects[i].GetComponent<enemeyKiller>().levelEnemy;
        }
        //return objects.Length;

      

        foreach (int num in vv)
        {
            if (countDict.ContainsKey(num))
            {
                countDict[num]++;
            }
            else
            {
                countDict[num] = 1;
            }
        }

        uniqueNumbers = new int[countDict.Count];
        counts = new int[countDict.Count];
        int index = 0;
        foreach (KeyValuePair<int, int> kvp in countDict)
        {

            uniqueNumbers[index] = kvp.Key;
            counts[index] = kvp.Value;
            index++;
        }


        newrespown();
    }

    public void newrespown()
    {
        min = 0;
        equall = 0;
        max = 0;
        for(int i = 0; i < uniqueNumbers.Length; i++)
        {
            if (uniqueNumbers[i] < levelplayer)
            {
                min = min + counts[i];
              
            }
            else if (uniqueNumbers[i] == levelplayer)
            {
                equall = equall + counts[i];
               
            }
            else if (uniqueNumbers[i] > levelplayer)
            {
                max = max + counts[i];
                
            }

        }

        ////////////////////////////////
        

        if (min< Mathf.RoundToInt(totalEnemies * 0.4f) && levelplayer>1)///////min
        {
            for (int ii = 0; ii < (Mathf.RoundToInt(totalEnemies * 0.4f) - min); ii++)
            {
                SpawnEnemies(enemesarray[Random.Range(0, levelplayer)], 1);
            }
        }
        /* if(equall < Mathf.RoundToInt(totalEnemies * 0.05f))///////egoul
         {
             for (int ii = 0; ii < Mathf.RoundToInt(totalEnemies * 0.3f) - equall; ii++)
             {
                SpawnEnemies(enemesarray[levelplayer - 1], 1);
                 Debug.Log(levelplayer - 1);
             }
         }*/
        if (levelplayer<= enemesarray.Length - 5)
        {
            if (max < Mathf.RoundToInt(totalEnemies * 0.6f))//////higth
            {
                for (int ii = 0; ii < Mathf.RoundToInt(totalEnemies * 0.5f) - max; ii++)
                {
                    SpawnEnemies(enemesarray[Random.Range(levelplayer + 1, levelplayer + 5)], 1);
                }
            }
        }
        else
        {
            if (max < Mathf.RoundToInt(totalEnemies * 0.6f))//////higth
            {
                for (int ii = 0; ii < Mathf.RoundToInt(totalEnemies * 0.5f) - max; ii++)
                {
                    SpawnEnemies(enemesarray[Random.Range(levelplayer + 1, enemesarray.Length)], 1);
                }
            }
        }
       
       
        
    }


}
