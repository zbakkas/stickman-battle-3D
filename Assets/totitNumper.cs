using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class totitNumper : MonoBehaviour
{
    public Transform nump,cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera (1)").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookdirr = new Vector3(0,0 , cam.position.y);
        nump.rotation = Quaternion.LookRotation(lookdirr);
    }
}
