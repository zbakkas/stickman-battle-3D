using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class enemeyKiller : MonoBehaviour
{
    public int levelEnemy ;
    public TextMeshPro t;
    public Animator anim;
    public CapsuleCollider  b2;

    public AudioClip kilenemeyy,kilplayeer;
    public AudioSource audioo;
    // Start is called before the first frame update
    void Start()
    {

        audioo = GameObject.Find("sound").GetComponent<AudioSource>();
        t.text = levelEnemy.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<NavMeshAgent>().speed == 0)
        {
            anim.SetBool("run", false);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.tag == "Player")
      {
            if (other.GetComponent<levelPlayer>().levell >= levelEnemy && other.GetComponent<movPlauer>().anim.GetBool("dead")==false)
            {

               

                other.GetComponent<movPlauer>().enemey = gameObject.transform;
                other.GetComponent<movPlauer>().anim.SetTrigger("punch");
                audioo.clip = kilenemeyy;
                audioo.Play();

              
                // other.GetComponent<levelPlayer>().xp = other.GetComponent<levelPlayer>().xp + (levelEnemy / 4f);//totalkiler
                other.GetComponent<levelPlayer>().slider.value = other.GetComponent<levelPlayer>().slider.value + (levelEnemy / 4f);//totalkiler
                Destroy(gameObject,1.5f);
                GameObject.Find("ESPAWN").GetComponent<rsowanEnemeys>().kil = true;
                gameObject.GetComponent<NavMeshAgent>().speed = 0;
                Invoke("f", 0.3f);
                /////
                Destroy(b2);
                Destroy(gameObject.GetComponent<Rigidbody>());
                Destroy(gameObject.GetComponent<CapsuleCollider>());

            }
            //////Dead
            if (other.GetComponent<levelPlayer>().levell < levelEnemy&& !other.GetComponent<UIplayer>().prtiction && other.GetComponent<movPlauer>().anim.GetBool("dead") == false)
            {
                
                //Destroy(other.gameObject, 0.09f);
                gameObject.GetComponent<NavMeshAgent>().speed = 0;
                other.GetComponent<movPlauer>().speed = 0;
                anim.SetTrigger("punch");

                audioo.clip = kilplayeer;
                audioo.Play();

                StartCoroutine(ff(other));
                Destroy(gameObject, 1.5f);
                Destroy(b2);
                Destroy(gameObject.GetComponent<Rigidbody>());
                Destroy(gameObject.GetComponent<CapsuleCollider>());
                //////
                other.GetComponent<UIplayer>().deadd = true;
            }

        }
    }


    private void f()
    {
        anim.SetBool("dead", true);
    }
    IEnumerator  ff( Collider x)
    {
        yield return new WaitForSeconds(0.3f);
        x.GetComponent<movPlauer>().anim.SetBool("dead", true);
    }

   
}
