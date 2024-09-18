using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LODING : MonoBehaviour
{
    public float timeRestart;
    
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.value =0;
        slider.maxValue = timeRestart;
        Invoke("gotohome", timeRestart);
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = slider.value + 1 * Time.deltaTime;
    }

    public void gotohome()
    {
        SceneManager.LoadScene(1);
    }
}
