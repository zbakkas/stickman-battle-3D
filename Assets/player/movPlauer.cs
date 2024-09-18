using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movPlauer : MonoBehaviour
{


    public DynamicJoystick _joystick;
    public CharacterController ch;
    public float speed;

    public Transform mish;
    float jump;
    public Animator anim;

    public Transform enemey;

    public AudioClip run;
    public AudioSource audioo;
    private void FixedUpdate()
    {


        ///
        //   an.SetFloat("X", Input.GetAxisRaw("Vertical"));
        // an.SetFloat("Y", Input.GetAxisRaw("Horizontal"));

        // Vector2 vulompv = new Vector2(_joystick.Horizontal, _joystick.Vertical);
        // vulompv.Normalize();
        //

        if (!ch.isTrigger)
        {
           jump--;
        }
        Vector3 velocity = new Vector3(_joystick.Horizontal * speed,jump, _joystick.Vertical* speed);
        ch.Move(velocity * Time.deltaTime);


        if ((_joystick.Horizontal != 0 || _joystick.Vertical != 0) &&speed>0)
        {
           
            anim.SetBool("run", true);
           Vector3 Vmovment1 = new Vector3(_joystick.Horizontal * speed, 0, _joystick.Vertical * speed);
            Vector3 lookdirr = new Vector3(Vmovment1.x, Vmovment1.y, Vmovment1.z);
            mish.rotation = Quaternion.LookRotation(lookdirr);
            audioo.clip = run;
          
            if (audioo.isPlaying )
            {


            }
            else
            {
                audioo.Play();
            }
        }
        else
        {
           if(audioo.clip == run)
            {
                audioo.clip = null;
            }
            
            anim.SetBool("run", false);

            if (enemey != null)
            {
                // Calculate the direction from the enemy to the player
                Vector3 directionToPlayer = enemey.position - transform.position;
                directionToPlayer.y = 0f; // Set the Y component to zero to ignore vertical rotation

                // Calculate the target rotation based on the direction
                Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

                // Smoothly rotate the enemy towards the player
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 9 * Time.deltaTime);
            }
            
        }
    }


}
