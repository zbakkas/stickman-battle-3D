using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class home : MonoBehaviour
{

    public GameObject n, l;
    // Start is called before the first frame update
    void Start()
    {
        n.SetActive(false);
        l.SetActive(true);
        
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("QUALITY", 2));
        if (PlayerPrefs.GetInt("QUALITY") == 2)
        {
            n.SetActive(false);
            l.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("QUALITY") == 0)
        {
            n.SetActive(true);
            l.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoToGame()
    {
        SceneManager.LoadScene(2);
    }


    public void NORMAL()
    {
        QualitySettings.SetQualityLevel(2);
        n.SetActive(false);
        l.SetActive(true);
        PlayerPrefs.SetInt("QUALITY", 2);
        PlayerPrefs.Save();
    }

    public void low()
    {
        QualitySettings.SetQualityLevel(0);
        n.SetActive(true);
        l.SetActive(false);
        PlayerPrefs.SetInt("QUALITY", 0);
        PlayerPrefs.Save();
    }



}
