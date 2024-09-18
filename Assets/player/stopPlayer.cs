using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopPlayer : MonoBehaviour
{
    float speed;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       
         
       


    }

    public void staaarte()
    {
      speed=  gameObject.GetComponentInParent<movPlauer>().speed ;
       gameObject.GetComponentInParent<movPlauer>().speed = 0;
    }
    public void endee()
    {
        gameObject.GetComponentInParent<movPlauer>().speed = speed;

        ////////////////////
        gameObject.GetComponentInParent<levelPlayer>().tchiklivel();
        ////////
        
    }
}
