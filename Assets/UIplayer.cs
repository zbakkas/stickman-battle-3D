using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIplayer : MonoBehaviour
{
    private movPlauer playermovv;
    private levelPlayer levP;
    private float sped;
    public bool prtiction;
    public ParticleSystem dead, prodactionn,speedd;
    public GameObject deadui;
    public bool deadd;
    public TextMeshProUGUI lvleplayeer,naxtLevelPlayer;

    public AudioClip deathh, colisionn;
    public AudioSource audioo;
    public GameObject handds;

    AdsControl adsint;
    AdManager adsreword;
    baneer adBaner;
    public GameObject butonReword;

    // Start is called before the first frame update
    void Start()
    {
        adsint = GameObject.Find("MANAGER ADS").GetComponent<AdsControl>();
        adsreword = GameObject.Find("MANAGER ADS").GetComponent<AdManager>();
        adBaner = GameObject.Find("MANAGER ADS").GetComponent<baneer>();
         adBaner.RequestBanner();
        adsreword.uii = gameObject.GetComponent<UIplayer>();
        deadui.SetActive(false);
        deadd = false;
        playermovv = gameObject.GetComponentInParent<movPlauer>();
       levP=  gameObject.GetComponentInParent<levelPlayer>();
        sped = playermovv.speed;
        prtiction = false;

        protictiononigame();
        //////////
        int soundOn = PlayerPrefs.GetInt("soundOn", 1);
        if (soundOn == 0)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
        /////////
        int oneGame = PlayerPrefs.GetInt("oneGame", 0);
        if (oneGame == 0)
        {
            handds.SetActive(true);
            PlayerPrefs.SetInt("oneGame", 1);
            PlayerPrefs.Save();
            Destroy(handds, 4f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (deadd)
        {
            
            StartCoroutine(deadco());
            deadd = false;
        }

        if (deadui.activeSelf)
        {
            if (adsreword.adClosed == true)
            {
                contonigame();
            }

            if (!adsreword.rewardedAd.CanShowAd())
            {
                butonReword.SetActive(false);
            }
            else
            {
                butonReword.SetActive(true);
            }

           
        }



        lvleplayeer.text = levP.levell.ToString();
        naxtLevelPlayer.text = (levP.levell+1).ToString();
    }


    public void shoooAdsReword()
    {
        adsreword.load_rewardedAd();
    }
    public void contonigame()//////
    {
        
        deadui.SetActive(false);
        playermovv.speed = sped;
        playermovv.anim.SetBool("dead", false);
        levP.prefapLivels[levP.levell - 1].transform.localRotation= Quaternion.Euler(0,0,0);
        dead.Play();
        StartCoroutine(proctionOnDeath());
       
    }


    public void protictiononigame()//////
    {
        prodactionn.Play();
        StartCoroutine(proctionOngame());
    }

    public void speeed()/////////////////
    {
        StartCoroutine(AddSpedonOngame());
    }

    IEnumerator proctionOnDeath()
    {
        prtiction = true;
        yield return new WaitForSeconds(1.5f);
        prtiction = false;
    }
    IEnumerator proctionOngame()
    {
        prtiction = true;
        yield return new WaitForSeconds(5f);
        prtiction = false;
    }
    IEnumerator AddSpedonOngame()
    {
        speedd.Play();
        playermovv.speed = sped * 1.4f;
        yield return new WaitForSeconds(5f);
        playermovv.speed = sped ;
    }






    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "protcion")
        {
            protictiononigame();
            Destroy(other.gameObject);
            audioo.clip = colisionn;
            audioo.Play();
        }
        if (other.gameObject.tag == "speed")
        {
            speeed();
            Destroy(other.gameObject);
            audioo.clip = colisionn;
            audioo.Play();
        }
    }

    IEnumerator deadco()
    {
        
          adBaner.DestroyAd();
        yield return new WaitForSeconds(1.5f);
        deadui.SetActive(true);
        audioo.clip = deathh;
        audioo.Play();
        adsint.showAds();
    }




    public void rstart()
    {
        SceneManager.LoadScene(2);
    }
    public void gotohome()
    {
        adBaner.DestroyAd();
        SceneManager.LoadScene(1);
    }
}
