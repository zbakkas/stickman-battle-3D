using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
    public GameObject tot, s1, s2;    
    // Start is called before the first frame update
    void Start()
    {
        tot.SetActive(false);
        int soundOn = PlayerPrefs.GetInt("soundOn", 1);
        if (soundOn == 0)
        {
            s1.SetActive(false);
            s2.SetActive(true);
            AudioListener.volume = 0;
        }
        else
        {
            s1.SetActive(true);
            s2.SetActive(false);
            AudioListener.volume = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void onn()
    {
        if (tot.activeSelf)
        {
            tot.SetActive(false);
        }
        else
        {
            tot.SetActive(true);
        }
    }

    /// //////////////////////////////////

    public void soundOFF()
    {
        s1.SetActive(false);
        s2.SetActive(true);

        PlayerPrefs.SetInt("soundOn", 0);
        PlayerPrefs.Save();
        AudioListener.volume = 0;
    }

    public void soundON()
    {
        s1.SetActive(true);
        s2.SetActive(false);

        PlayerPrefs.SetInt("soundOn", 1);
        PlayerPrefs.Save();
        AudioListener.volume = 1;
    }

}
