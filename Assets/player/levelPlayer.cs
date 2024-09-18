using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class levelPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public int levell;
    public float xp=1;
    public TextMeshPro t;
    public Slider slider;
    public GameObject[] prefapLivels;
    private movPlauer mov;
    public ParticleSystem adliv;

    public AudioClip livleup;
    public AudioSource audioo;


    // Update is called once per frame
    private void Start()
    {
        slider.maxValue = levell;
        /////////////
        mov = gameObject.GetComponent<movPlauer>();
        for (int i =0;i<prefapLivels.Length;i++)
        {
            prefapLivels[i].SetActive(false);
        }

        prefapLivels[levell-1].SetActive(true);
        mov.anim = prefapLivels[levell - 1].GetComponent<Animator>();

      
    }
    void Update()
    {
        
        

       // levell = (int)xp;
        t.text = levell.ToString();


        
    }
   
    public void tchiklivel()
    {
        if (slider.value == slider.maxValue)
        {
            slider.value = 0;
            levell++;
            adliv.Play();
            audioo.clip = livleup;
            audioo.Play();
            slider.maxValue = levell;
            /////////////
            for (int i = 0; i < prefapLivels.Length; i++)
            {
                prefapLivels[i].SetActive(false);
            }

            prefapLivels[levell - 1].SetActive(true);
            mov.anim = prefapLivels[levell - 1].GetComponent<Animator>();
        }
    }
}
